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
        private ObservableCollection<Airport> airportList;

        public ObservableCollection<Cabin> CabinList { get; }
        public ObservableCollection<Airport> AirportList
        {
            get => airportList;
            set => SetProperty(ref airportList, value);
        }
        public Airport DepartureAirport { get; }
        public Airport ArrivalAirport { get; }
        public Cabin SelectedCabin { get; }

        private string departureTitle = "Retrieving...";
        public string DepartureTitle
        {
            get => departureTitle;
            set => SetProperty(ref departureTitle, value);
        }

        public AboutViewModel()
        {
            CabinList = new ObservableCollection<Cabin>();
            CabinList.Add(new Cabin(1, "Economy"));
            CabinList.Add(new Cabin(2, "Business"));
            CabinList.Add(new Cabin(3, "First Class"));

            AirportList = new ObservableCollection<Airport>();

            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            LoadAirports();
        }

        public async void LoadAirports()
        {
            LoginService service = new LoginService();
            var tempList = await service.GetAirportList();

            AirportList = new ObservableCollection<Airport>(tempList);

            DepartureTitle = "Select";
        }

        public ICommand OpenWebCommand { get; }
    }
}