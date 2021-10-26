using MvvmCross;
using MvvmCross.ViewModels;
using FlightSchedule.Core.Services;
using FlightSchedule.Core.ViewModels;

namespace FlightSchedule.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IFlightScheduleService, FlightScheduleService>();

            RegisterAppStart<FlightsViewModel>();
        }
    }
}