using FlightApps.Models;
using FlightApps.Services;
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

        private void Button_Clicked(object sender, EventArgs e)
        {
			if(!Application.Current.Properties.ContainsKey("email") &&
				string.IsNullOrEmpty(Application.Current.Properties["email"].ToString()))
            {
				DisplayAlert("Error", "Please login before purchase flight tickets.", "OK");
            }
			string data = ((Button)sender).BindingContext.ToString();
			LoginService service = new LoginService();

			int ScheduleID = int.Parse(data);
			var whichSchedule = vm.ScheduleList.Where(x => x.ID == ScheduleID).FirstOrDefault();
			Booking booking = new Booking();
			booking.Amount = (decimal)whichSchedule.Price;
			booking.FlightScheduleID = ScheduleID;
			booking.Email = Application.Current.Properties["email"].ToString();

			string result = service.MakeBooking(booking).Result;

			if(result.ToLower().Contains("success"))
            {
				Application.Current.MainPage.Navigation.PushAsync(new ItemsPage());
			}

		}
	}
}