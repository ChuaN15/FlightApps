using FlightApps.Models;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.Email = entryLoginEmail.Text;
            user.Password = entryLoginPassword.Text;


        }
    }
}