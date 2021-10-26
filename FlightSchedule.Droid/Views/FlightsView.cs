using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using FlightSchedule.Core.ViewModels;
using System;
using Android.Widget;

namespace FlightSchedule.UI.Droid.Views
{
    [Activity(Label = "Flight Schedule", Theme = "@style/AppTheme")]
    public class FlightsView : MvxActivity<FlightsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FlightsView);

            var flightDateEditText = FindViewById<EditText>(Resource.Id.flightDateEditText);
            flightDateEditText.Click += delegate
            {
                if (!DateTime.TryParse(flightDateEditText.Text, out var flightDate))
                {
                    flightDate = DateTime.Now;
                }
                DatePickerDialog datePicker = new DatePickerDialog(this, (sender, e) =>
                {
                    flightDateEditText.Text = e.Date.ToShortDateString();
                }, flightDate.Year, flightDate.Month, flightDate.Day);
                datePicker.UpdateDate(flightDate);
                datePicker.Show();
            };
        }
    }
}