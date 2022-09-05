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

        private async void Button_Clicked(object sender, EventArgs e)
        {
			if(!Application.Current.Properties.ContainsKey("email"))
            {
				DisplayAlert("Error", "Please login before purchase flight tickets.", "OK");
				return;
            }

			string data = ((Button)sender).BindingContext.ToString();
			LoginService service = new LoginService();

			int ScheduleID = int.Parse(data);
			var whichSchedule = vm.ScheduleList.Where(x => x.ID == ScheduleID).FirstOrDefault();
			Booking booking = new Booking();
			booking.Amount = (decimal)whichSchedule.Price;
			booking.FlightScheduleID = ScheduleID;
			booking.Email = Application.Current.Properties["email"].ToString();

			string result = await service.MakeBooking(booking);

			if(result.ToLower().Contains("success"))
            {
				Application.Current.MainPage.Navigation.PushAsync(new ItemsPage());
			}

		}
	}
}