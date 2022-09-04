using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightApps.Views
{
    public partial class FindFlightPage : ContentPage
    {
        public FindFlightPage()
        {
            InitializeComponent();
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
        }

        private void RoundTripRecognizer_Tapped(object sender, EventArgs e)
        {
            lblRoundTrip.FontAttributes = FontAttributes.Bold;
            lblRoundTrip.FontSize = 24;
            lblOneWay.FontAttributes = FontAttributes.None;
            lblOneWay.FontSize = 20;
            lblDash.IsVisible = true;
            EndDatePicker.IsVisible = true;
        }
    }
}