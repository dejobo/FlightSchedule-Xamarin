using FlightSchedule.Core.Models.Responses;
using System;
using System.Threading.Tasks;

namespace FlightSchedule.Core.Services
{
    public interface IFlightScheduleService
    {
        Task<FlightsResponse> GetFlights(string origin, string destination, DateTime fromDate, DateTime toDate);
    }
}
