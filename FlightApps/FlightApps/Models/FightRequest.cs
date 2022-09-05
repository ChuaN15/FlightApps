using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApps.Models
{
    public class FlightRequest
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Passenger { get; set; }
        public string CabinType { get; set; }
    }
}
