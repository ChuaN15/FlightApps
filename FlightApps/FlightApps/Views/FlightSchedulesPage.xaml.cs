using FlightApps.Models;
using System;
using System.Collections.Generic;
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
		public FlightSchedulesPage (Schedule schedule)
		{
			InitializeComponent ();

		}
	}
}