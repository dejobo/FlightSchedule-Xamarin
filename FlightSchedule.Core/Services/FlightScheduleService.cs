using FlightSchedule.Core.Models;
using FlightSchedule.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightSchedule.Core.Services
{
    public class FlightScheduleService : IFlightScheduleService
    {
        private const string ApiURL = "https://apis.qa.alaskaair.com";
        private const string OcpApimSubscriptionKey = "8420dcb1d57f4c13b47b18a4faf0d990";

        /// <summary>
        /// Gets the list of flights with detailss
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public async Task<FlightsResponse> GetFlights(string origin, string destination, DateTime fromDate, DateTime toDate)
        {
            System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", OcpApimSubscriptionKey);
            var httpResponseMessage = await httpClient.GetAsync($"{ApiURL}/aag/1/guestServices/flights/?fromDate={fromDate.ToString("yyyy-MM-dd")}&toDate={toDate.ToString("yyyy-MM-dd")}&origin={origin}&destination={destination}&nonStopOnly=false");
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var flightResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Responses.FlightsResponse>(content);
            return flightResponse;
        }
    }
}
