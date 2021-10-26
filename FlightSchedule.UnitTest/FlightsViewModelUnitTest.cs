using FlightSchedule.Core.Models.Responses;
using FlightSchedule.Core.Services;
using FlightSchedule.Core.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace FlightSchedule.UnitTest
{
    [TestClass]
    public class FlightsViewModelUnitTest
    {
        private FlightsViewModel _viewModel;
        private Mock<IFlightScheduleService> _flightScheduleServiceMock;

        public FlightsViewModelUnitTest()
        {
            _flightScheduleServiceMock = new Mock<IFlightScheduleService>();
            _viewModel = new FlightsViewModel(_flightScheduleServiceMock.Object);
        }

        [TestMethod]
        public void TestFindCommandWithSampleFlightsData()
        {
            var origin = "SEA";
            var destination = "LAX";
            var flightDate = new DateTime(2021, 7, 25);
            _flightScheduleServiceMock.Setup(m => m.GetFlights(origin, destination, flightDate, flightDate))
                                      .Returns(Task.FromResult(JsonConvert.DeserializeObject<FlightsResponse>(Utils.GetFileContent("FlightsData.txt"))));
            _viewModel.Origin = origin;
            _viewModel.Destination = destination;
            _viewModel.FlightDate = flightDate.ToShortDateString();
            _viewModel.FindCommand.Execute(null);

            Assert.IsTrue(_viewModel.Flights.Count > 0);
            Assert.IsFalse(_viewModel.IsBusy);
        }

        [TestMethod]
        public void TestFindCommandWithNoFlightsData()
        {
            var origin = "";
            var destination = "";
            var flightDate = new DateTime(2021, 7, 25);
            _flightScheduleServiceMock.Setup(m => m.GetFlights(origin, destination, flightDate, flightDate))
                                      .Returns(Task.FromResult(new FlightsResponse()));
            _viewModel.Origin = origin;
            _viewModel.Destination = destination;
            _viewModel.FlightDate = flightDate.ToShortDateString();
            _viewModel.FindCommand.Execute(null);

            Assert.IsTrue(_viewModel.Flights.Count == 0);
            Assert.IsFalse(_viewModel.IsBusy);
        }

        [TestMethod]
        public void TestOrderDepartureTimeWithSampleFlightsData()
        {
            var origin = "SEA";
            var destination = "LAX";
            var flightDate = new DateTime(2021, 7, 25);
            _flightScheduleServiceMock.Setup(m => m.GetFlights(origin, destination, flightDate, flightDate))
                                      .Returns(Task.FromResult(JsonConvert.DeserializeObject<FlightsResponse>(Utils.GetFileContent("FlightsData.txt"))));
            _viewModel.Origin = origin;
            _viewModel.Destination = destination;
            _viewModel.FlightDate = flightDate.ToShortDateString();
            _viewModel.FindCommand.Execute(null);

            var flights = _viewModel.Flights;
            for (int i = 0; i < flights.Count - 1; i++)
            {
                Assert.IsTrue(flights[i].DepartureTime <= flights[i + 1].DepartureTime);
            }
        }
    }
}
