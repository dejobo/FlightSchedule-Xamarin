using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.ViewModels;
using FlightSchedule.Core.Services;
using System.Collections.Generic;
using FlightSchedule.Core.Models;
using System;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Commands;
using FlightSchedule.Core.ViewModels.Items;

namespace FlightSchedule.Core.ViewModels
{
    public class FlightsViewModel : MvxViewModel
    {
        private readonly IFlightScheduleService _flightScheduleService;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        private string _origin;
        public string Origin
        {
            get => _origin;
            set
            {
                _origin = value;
                RaisePropertyChanged(() => Origin);
            }
        }

        private string _destination;
        public string Destination
        {
            get => _destination;
            set
            {
                _destination = value;
                RaisePropertyChanged(() => Destination);
            }
        }

        private string _flightDate;
        public string FlightDate
        {
            get => _flightDate;
            set
            {
                _flightDate = value;
                RaisePropertyChanged(() => FlightDate);
            }
        }

        private List<FlightItemViewModel> _flights;
        public List<FlightItemViewModel> Flights
        {
            get { return _flights; }
            set
            {
                _flights = value;
                RaisePropertyChanged(() => Flights);
            }
        }

        public ICommand FindCommand
        {
            get
            {
                return new MvxAsyncCommand(async () =>
                {
                    if (!IsBusy)
                    {
                        try
                        {
                            IsBusy = true;
                            var flightDate = DateTime.Parse(FlightDate);
                            var flightsResponse = await _flightScheduleService.GetFlights(Origin, Destination, flightDate, flightDate);
                            var flights = flightsResponse.Flights?.Select(f =>
                            {
                                var departureTime = f.FlightDetails.FlightLegs?.FirstOrDefault()?.ActualDateTimeUTC?.Out;
                                if (departureTime == null)
                                {
                                    departureTime = f.FlightDetails.FlightLegs?.FirstOrDefault()?.EstimatedDateTimeUTC?.Out;
                                }
                                var arrivalTime = f.FlightDetails.FlightLegs?.LastOrDefault()?.ActualDateTimeUTC?.In;
                                if (arrivalTime == null)
                                {
                                    arrivalTime = f.FlightDetails.FlightLegs?.FirstOrDefault()?.EstimatedDateTimeUTC?.In;
                                }
                                return new FlightItemViewModel
                                {
                                    FlightNumber = f.FlightDetails.OperatingFlightNumber,
                                    DepartureTime = departureTime,
                                    ArrivalTime = arrivalTime,
                                };
                            }).ToList();
                            flights.Sort((f1, f2) => f2.DepartureTime == null || f1.DepartureTime < f2.DepartureTime ? -1 : 1);
                            Flights = flights;
                        }
                        catch
                        {
                            Flights = new List<FlightItemViewModel>();
                        }
                        finally
                        {
                            IsBusy = false;
                        }
                    }
                });
            }
        }

        public FlightsViewModel(IFlightScheduleService flightScheduleService)
        {
            _flightScheduleService = flightScheduleService;
            _origin = "SEA";
            _destination = "LAX";
            _flightDate = new DateTime(2021, 7, 25).ToShortDateString();
        }
    }
}