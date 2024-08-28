using System.Collections.Generic;
using System.Threading.Tasks;
using Airline_Management_System.Model;
using Airline_Management_System.Repository;

namespace FlyWithMe.Service
{
    public class FlightServiceImpl : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightServiceImpl(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _flightRepository.ListAllFlightsAsync();
        }

        public async Task<Flight> GetFlightByIdAsync(int flightId)
        {
            return await _flightRepository.GetFlightByIdAsync(flightId);
        }

        public async Task AddFlightAsync(Flight flight)
        {
            await _flightRepository.AddFlightAsync(flight);
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            await _flightRepository.UpdateFlightAsync(flight);
        }

       
    }
}
