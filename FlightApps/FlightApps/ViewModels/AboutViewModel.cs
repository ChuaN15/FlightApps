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

        private string departureTitle = "Retrieving...";
        public string DepartureTitle
        {
            get => departureTitle;
            set => SetProperty(ref departureTitle, value);
        }

        private Cabin selectedCabin;
        public Cabin SelectedCabin
        {
            get => selectedCabin;
            set => SetProperty(ref selectedCabin, value);
        }

        private Airport departureAirport;
        public Airport DepartureAirport
        {
            get => departureAirport;
            set => SetProperty(ref departureAirport, value);
        }

        private Airport arrivalAirport;
        public Airport ArrivalAirport
        {
            get => arrivalAirport;
            set => SetProperty(ref arrivalAirport, value);
        }



        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }

        private DateTime endDate = DateTime.Now.AddDays(7);
        public DateTime EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
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