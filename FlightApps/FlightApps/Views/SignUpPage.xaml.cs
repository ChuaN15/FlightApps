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
            maleCheckBox.IsChecked = true;
        }

        private void Female_Tapped(object sender, EventArgs e)
        {
            maleCheckBox.IsChecked = false;
            femaleCheckBox.IsChecked = true;
        }

        private void ShowPassword_Tapped(object sender, EventArgs e)
        {
            maleCheckBox.IsChecked = false;
        }

        private void femaleCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (femaleCheckBox.IsChecked)
            {
                maleCheckBox.IsChecked = false;
            }
        }

        private void maleCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(maleCheckBox.IsChecked)
            {
                femaleCheckBox.IsChecked = false;
            }
        }
    }
}