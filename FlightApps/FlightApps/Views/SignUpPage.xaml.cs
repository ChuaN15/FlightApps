using FlightApps.ViewModels;
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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void Male_Tapped(object sender, EventArgs e)
        {
            femaleCheckBox.IsChecked = false;
        }

        private void Female_Tapped(object sender, EventArgs e)
        {
            maleCheckBox.IsChecked = false;
        }

        private void ShowPassword_Tapped(object sender, EventArgs e)
        {
            maleCheckBox.IsChecked = false;
        }
    }
}