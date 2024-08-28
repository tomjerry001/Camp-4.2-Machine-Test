using System.Collections.Generic;
using System.Threading.Tasks;
using Airline_Management_System.Model;

namespace FlyWithMe.Service
{
    public interface IFlightService
    {
        Task<List<Flight>> GetAllFlightsAsync();
        Task<Flight> GetFlightByIdAsync(int flightId);
        Task AddFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);

       
    }
}
