using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApps.Models
{
    public class User
    {
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
