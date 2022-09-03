using FlightApps.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FlightApps.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}