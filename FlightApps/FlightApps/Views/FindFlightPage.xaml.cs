using FlightApps.Models;
using FlightApps.Services;
using FlightApps.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightApps.Views
{
    public partial class FindFlightPage : ContentPage
    {
        AboutViewModel vm;
        bool isOneway = false;
        public FindFlightPage()
        {
            InitializeComponent();
            vm = new AboutViewModel();
            this.BindingContext = vm;
        }

        private void StartDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void EndDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void OnewayRecognizer_Tapped(object sender, EventArgs e)
        {
            lblOneWay.FontAttributes = FontAttributes.Bold;
            lblOneWay.FontSize = 24;
            lblRoundTrip.FontAttributes = FontAttributes.None;
            lblRoundTrip.FontSize = 20;
            lblDash.IsVisible = false;
            EndDatePicker.IsVisible = false;
            isOneway = true;
        }

        private void RoundTripRecognizer_Tapped(object sender, EventArgs e)
        {
            lblRoundTrip.FontAttributes = FontAttributes.Bold;
            lblRoundTrip.FontSize = 24;
            lblOneWay.FontAttributes = FontAttributes.None;
            lblOneWay.FontSize = 20;
            lblDash.IsVisible = true;
            EndDatePicker.IsVisible = true;
            isOneway = false;

        }

        private async void FindButton_Clicked(object sender, EventArgs e)
        {
            int passengerAmount = 0;

            if(!int.TryParse(entryPassenger.Text, out passengerAmount) || passengerAmount <= 0)
            {
                DisplayAlert("Error", "Please enter valid amount of passengers.", "OK");
                return;
            }
            else if (vm.SelectedCabin == null || vm.DepartureAirport == null ||
                vm.ArrivalAirport == null)
            {
                DisplayAlert("Error", "Please select all of the options.", "OK");
                return;
            }
            else if(!isOneway)
            {
                if(vm.StartDate > vm.EndDate)
                {
                    DisplayAlert("Error", "Please enter valid end date.", "OK");
                    return;
                }
            }

            var FlightReq = new FlightRequest();
            FlightReq.Departure = vm.DepartureAirport.ShortName;
            FlightReq.Arrival = vm.ArrivalAirport.ShortName;
            FlightReq.CabinType = vm.SelectedCabin.Name;
            FlightReq.EndDate = isOneway ? DateTime.MinValue : vm.EndDate;
            FlightReq.StartDate = vm.StartDate;
            FlightReq.Passenger = passengerAmount;


            DisplayAlert("", "Loading...", "OK");
            LoginService service = new LoginService();
            var schedules = await service.GetDepartureScheduleList(FlightReq);

        }
    }
}