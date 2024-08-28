using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Airline_Management_System.Model;
using Airline_Management_System.Repository;

namespace FlyWithMe.Repository
{
    public class FlightRepositoryImpl : IFlightRepository
    {
        private readonly string _connectionString;

        public FlightRepositoryImpl(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Flight>> ListAllFlightsAsync()
        {
            var flights = new List<Flight>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("sp_ListAllFlights", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        flights.Add(new Flight
                        {
                            FlightId = reader.GetInt32(0),
                            DepAirport = reader.GetString(1),
                            DepDate = reader.GetDateTime(2),
                            DepTime = reader.GetTimeSpan(3),
                            ArrAirport = reader.GetString(4),
                            ArrDate = reader.GetDateTime(5),
                            ArrTime = reader.GetTimeSpan(6)
                        });
                    }
                }
            }

            return flights;
        }

        public async Task<Flight> GetFlightByIdAsync(int flightId)
        {
            Flight flight = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("sp_GetFlightById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@FlightId", flightId);

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        flight = new Flight
                        {
                            FlightId = reader.GetInt32(0),
                            DepAirport = reader.GetString(1),
                            DepDate = reader.GetDateTime(2),
                            DepTime = reader.GetTimeSpan(3),
                            ArrAirport = reader.GetString(4),
                            ArrDate = reader.GetDateTime(5),
                            ArrTime = reader.GetTimeSpan(6)
                        };
                    }
                }
            }

            return flight;
        }

        public async Task AddFlightAsync(Flight flight)
        {
            // Validate the departure and arrival airport codes
            bool depAirportExists = await AirportExistsAsync(flight.DepAirport);
            bool arrAirportExists = await AirportExistsAsync(flight.ArrAirport);

            if (!depAirportExists || !arrAirportExists)
            {
                string invalidAirports = (!depAirportExists ? flight.DepAirport : "") + (!arrAirportExists ? ", " + flight.ArrAirport : "");
                throw new ArgumentException($"The following airport codes are invalid: {invalidAirports.TrimStart(',').Trim()}.");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("sp_AddFlight", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@DepAirport", flight.DepAirport);
                command.Parameters.AddWithValue("@DepDate", flight.DepDate);
                command.Parameters.AddWithValue("@DepTime", flight.DepTime);
                command.Parameters.AddWithValue("@ArrAirport", flight.ArrAirport);
                command.Parameters.AddWithValue("@ArrDate", flight.ArrDate);
                command.Parameters.AddWithValue("@ArrTime", flight.ArrTime);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("sp_UpdateFlight", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FlightId", flight.FlightId);
                    command.Parameters.AddWithValue("@DepAirport", flight.DepAirport);
                    command.Parameters.AddWithValue("@DepDate", flight.DepDate);
                    command.Parameters.AddWithValue("@DepTime", flight.DepTime);
                    command.Parameters.AddWithValue("@ArrAirport", flight.ArrAirport);
                    command.Parameters.AddWithValue("@ArrDate", flight.ArrDate);
                    command.Parameters.AddWithValue("@ArrTime", flight.ArrTime);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("An error occurred while updating the flight.", ex);
                    }
                }
            }
        }

        private async Task<bool> AirportExistsAsync(string airportCode)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Airport WHERE Code = @Code", connection);
                command.Parameters.AddWithValue("@Code", airportCode);

                await connection.OpenAsync();
                var count = (int)await command.ExecuteScalarAsync();
                return count > 0;
            }
        }
    }
}
