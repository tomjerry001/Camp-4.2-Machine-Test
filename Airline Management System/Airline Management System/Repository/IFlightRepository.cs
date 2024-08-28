using System.Collections.Generic;
using System.Threading.Tasks;
using Airline_Management_System.Model;

namespace Airline_Management_System.Repository
{
    public interface IFlightRepository
    {
        Task<List<Flight>> ListAllFlightsAsync();
        Task<Flight> GetFlightByIdAsync(int flightId);
        Task AddFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);

       
    }
}
