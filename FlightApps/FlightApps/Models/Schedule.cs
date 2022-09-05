using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApps.Models
{
    public class Schedule
    {
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string FlightNo { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public Nullable<decimal> Price { get; set; }
        public int ID { get; set; }
    }
}
