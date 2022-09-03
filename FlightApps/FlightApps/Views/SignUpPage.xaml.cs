using FlightApps.Models;
using FlightApps.Services;
using FlightApps.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        SignUpViewModel vm;
        LoginService service = new LoginService();
        public SignUpPage()
        {
            InitializeComponent();
            vm = new SignUpViewModel();
            this.BindingContext = vm;

            maleCheckBox.IsChecked = true;
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
            if(entryPassword.IsPassword)
            {
                entryPassword.IsPassword = false;
                imgPassword.Source = "show_password.png";
            }
            else
            {
                entryPassword.IsPassword = true;
                imgPassword.Source = "hide_password.png";
            }
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

        private void entryPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private async void SignUpButton_Clicked(object sender, EventArgs e)
        {
            DateTime dob;
           
            if (string.IsNullOrEmpty(entryEmail.Text) || string.IsNullOrEmpty(entryPassword.Text)
                || string.IsNullOrEmpty(entryGivenName.Text) || string.IsNullOrEmpty(entryFamilyName.Text) ||
                string.IsNullOrEmpty(entryDOB.Text))
            {
                lblError.Text = "Please fill in all of the fields";
            }
            else if(entryPassword.Text.Length < 6)
            {
                lblError.Text = "Password must be at least 6 characters";
            }
            else if (!DateTime.TryParseExact(entryDOB.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out dob))
            {
                lblError.Text = "DOB is not in correct format";
            }
            else
            {
                lblError.Text = "";
                User user = new User();
                user.DateOfBirth = dob;
                user.Email = entryEmail.Text;
                user.FamilyName = entryFamilyName.Text;
                user.Gender = maleCheckBox.IsChecked ? "Male" : "Female";
                user.GivenName = entryGivenName.Text;
                user.Password = entryPassword.Text;
                vm.Users.Add(user);

                SignUpButton.IsEnabled = false;
                lblError.Text = "Loading...";
                string retrievedData = await service.RegisterUser(user);

                if(retrievedData.ToLower().Contains("success"))
                {
                    Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    lblError.Text = retrievedData;
                }
            }
        }
    }
}