using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApps.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public int FlightScheduleID { get; set; }
        public int PassengerCount { get; set; }

        public string text { get; set; }
        public string description { get; set; }

        public Schedule FlightSchedule { get; set; }
    }
}
