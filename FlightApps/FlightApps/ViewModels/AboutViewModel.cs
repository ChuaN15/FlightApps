using FlightApps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlightApps.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ObservableCollection<Cabin> CabinList { get; }

        public Cabin SelectedCabin { get; }
        public AboutViewModel()
        {
            CabinList = new ObservableCollection<Cabin>();
            CabinList.Add(new Cabin(1, "Economy"));
            CabinList.Add(new Cabin(2, "Business"));
            CabinList.Add(new Cabin(3, "First Class"));

            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}