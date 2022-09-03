using FlightApps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FlightApps.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; }


        public SignUpViewModel()
        {
            Users = new ObservableCollection<User>();
        }
    }
}
