using FlightApps.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApps.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        private User user;
        public User User
        {
            get => user;
            set => SetProperty(ref user, value);
        }


    }
}
