using FlightApps.Models;
using FlightApps.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlightApps.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<Cabin> CabinList { get; }
        public ObservableCollection<Airport> AirportList { get; }
        public Airport DepartureAirport { get; }
        public Airport ArrivalAirport { get; }

        public Cabin SelectedCabin { get; }
        public AboutViewModel()
        {
            CabinList = new ObservableCollection<Cabin>();
            CabinList.Add(new Cabin(1, "Economy"));
            CabinList.Add(new Cabin(2, "Business"));
            CabinList.Add(new Cabin(3, "First Class"));

            AirportList = new ObservableCollection<Airport>();

            LoginService service = new LoginService();
            var tempList = service.GetAirportList();

            AirportList = new ObservableCollection<Airport>(tempList.Result);

           

            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}