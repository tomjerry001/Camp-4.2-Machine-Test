using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlyWithMe.Service;
using FlyWithMe.Repository;
using Airline_Management_System.Model;
using Airline_Management_System.Repository;
using System.Configuration;

namespace FlyWithMe
{
    class Program
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;
        private static readonly IFlightRepository FlightRepository = new FlightRepositoryImpl(ConnectionString);
        private static readonly IFlightService FlightService = new FlightServiceImpl(FlightRepository);

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("                                     -----------------------------------------------------       ");
                Console.WriteLine("                                    |  A I R L I N E   M A N A G E M E N T   S Y S T E M |       ");
                Console.WriteLine("                                     -----------------------------------------------------       ");
                Console.WriteLine("       ");
                Console.WriteLine("       ");
                Console.WriteLine("       ");
                Console.WriteLine("    ------------------------ ");
                Console.WriteLine("    +   FLY   WITH  ME      +");
                Console.WriteLine("    ------------------------ ");
                Console.WriteLine("       ");
                Console.WriteLine("1. List All Flights");
                Console.WriteLine("2. Search Flight By ID");
                Console.WriteLine("3. Add Flight");
                Console.WriteLine("4. Update Flight");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await ListAllFlightsAsync();
                        break;

                    case "2":
                        await SearchFlightByIdAsync();
                        break;

                    case "3":
                        await AddFlightAsync();
                        break;

                    case "4":
                        await UpdateFlightAsync();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static async Task ListAllFlightsAsync()
        {
            Console.WriteLine("Fetching all flights...");
            var flights = await FlightService.GetAllFlightsAsync();

            foreach (var flight in flights)
            {
                Console.WriteLine($"Flight ID: {flight.FlightId}");
                Console.WriteLine($"Departure Airport: {flight.DepAirport}");
                Console.WriteLine($"Departure Date: {flight.DepDate:yyyy-MM-dd}");
                Console.WriteLine($"Departure Time: {flight.DepTime:hh\\:mm\\:ss}");
                Console.WriteLine($"Arrival Airport: {flight.ArrAirport}");
                Console.WriteLine($"Arrival Date: {flight.ArrDate:yyyy-MM-dd}");
                Console.WriteLine($"Arrival Time: {flight.ArrTime:hh\\:mm\\:ss}");
                Console.WriteLine();
            }
        }

        private static async Task SearchFlightByIdAsync()
        {
            Console.Write("Enter Flight ID to search: ");
            if (int.TryParse(Console.ReadLine(), out int flightId))
            {
                var flight = await FlightService.GetFlightByIdAsync(flightId);

                if (flight != null)
                {
                    Console.WriteLine($"Flight ID: {flight.FlightId}");
                    Console.WriteLine($"Departure Airport: {flight.DepAirport}");
                    Console.WriteLine($"Departure Date: {flight.DepDate:yyyy-MM-dd}");
                    Console.WriteLine($"Departure Time: {flight.DepTime:hh\\:mm\\:ss}");
                    Console.WriteLine($"Arrival Airport: {flight.ArrAirport}");
                    Console.WriteLine($"Arrival Date: {flight.ArrDate:yyyy-MM-dd}");
                    Console.WriteLine($"Arrival Time: {flight.ArrTime:hh\\:mm\\:ss}");
                }
                else
                {
                    Console.WriteLine("Flight not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Flight ID.");
            }
        }

        private static async Task AddFlightAsync()
        {
            var flight = new Flight();

            Console.Write("Departure Airport: ");
            flight.DepAirport = Console.ReadLine();

            Console.Write("Departure Date (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime depDate))
            {
                flight.DepDate = depDate;
            }
            else
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.Write("Departure Time (HH:MM:SS): ");
            if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan depTime))
            {
                flight.DepTime = depTime;
            }
            else
            {
                Console.WriteLine("Invalid time format.");
                return;
            }

            Console.Write("Arrival Airport: ");
            flight.ArrAirport = Console.ReadLine();

            Console.Write("Arrival Date (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime arrDate))
            {
                flight.ArrDate = arrDate;
            }
            else
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.Write("Arrival Time (HH:MM:SS): ");
            if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan arrTime))
            {
                flight.ArrTime = arrTime;
            }
            else
            {
                Console.WriteLine("Invalid time format.");
                return;
            }

            await FlightService.AddFlightAsync(flight);
            Console.WriteLine("Flight added successfully.");
        }

        private static async Task UpdateFlightAsync()
        {
            Console.Write("Enter Flight ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int flightId))
            {
                var flight = await FlightService.GetFlightByIdAsync(flightId);

                if (flight != null)
                {
                    Console.Write("New Departure Airport: ");
                    flight.DepAirport = Console.ReadLine();

                    Console.Write("New Departure Date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime depDate))
                    {
                        flight.DepDate = depDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                        return;
                    }

                    Console.Write("New Departure Time (HH:MM:SS): ");
                    if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan depTime))
                    {
                        flight.DepTime = depTime;
                    }
                    else
                    {
                        Console.WriteLine("Invalid time format.");
                        return;
                    }

                    Console.Write("New Arrival Airport: ");
                    flight.ArrAirport = Console.ReadLine();

                    Console.Write("New Arrival Date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime arrDate))
                    {
                        flight.ArrDate = arrDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                        return;
                    }

                    Console.Write("New Arrival Time (HH:MM:SS): ");
                    if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan arrTime))
                    {
                        flight.ArrTime = arrTime;
                    }
                    else
                    {
                        Console.WriteLine("Invalid time format.");
                        return;
                    }

                    await FlightService.UpdateFlightAsync(flight);
                    Console.WriteLine("Flight updated successfully.");
                }
                else
                {
                    Console.WriteLine("Flight not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Flight ID.");
            }
        }
    }
}
