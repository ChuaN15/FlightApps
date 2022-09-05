using FlightApps.Models;
using FlightApps.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlightApps.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlightSchedulesPage : ContentPage
	{
		ScheduleViewModel vm;
		public FlightSchedulesPage (List<Schedule> schedule)
		{
			InitializeComponent ();
			vm = new ScheduleViewModel();
			this.BindingContext = vm;
			vm.ScheduleList = new ObservableCollection<Schedule>(schedule);
		}
	}
}