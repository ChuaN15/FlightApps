using FlightApps.Models;
using FlightApps.Services;
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

        private async void Login_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.Email = entryLoginEmail.Text;
            user.Password = entryLoginPassword.Text;
            LoginButton.IsEnabled = false;
            LoginButton.Text = "Processing...";

            LoginService service = new LoginService();
            User selectedUser = await service.UserLogin(user);

            LoginButton.IsEnabled = true;
            LoginButton.Text = "Continue";
            if (selectedUser == null)
            {
                lblError.Text = "Please enter correct login credentials!";
            }
            else
            {
                lblError.Text = "";
                Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
            }
        }
    }
}