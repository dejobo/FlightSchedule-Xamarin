using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MvvmCross.ViewModels;
using FlightSchedule.Core.Services;
using System.Collections.Generic;
using FlightSchedule.Core.Models;
using System;
using System.Windows.Input;
using MvvmCross.Commands;

namespace FlightSchedule.Core.ViewModels.Items
{
    public class FlightItemViewModel : MvxNotifyPropertyChanged
    {
        private string _flightNumber;
        public string FlightNumber
        {
            get => _flightNumber;
            set
            {
                _flightNumber = value;
                RaisePropertyChanged(() => FlightNumber);
            }
        }

        private DateTime? _departureTime;
        public DateTime? DepartureTime
        {
            get => _departureTime;
            set
            {
                _departureTime = value;
                RaisePropertyChanged(() => DepartureTime);
            }
        }

        private DateTime? _arrivalTime;
        public DateTime? ArrivalTime
        {
            get => _arrivalTime;
            set
            {
                _arrivalTime = value;
                RaisePropertyChanged(() => ArrivalTime);
            }
        }
    }
}
