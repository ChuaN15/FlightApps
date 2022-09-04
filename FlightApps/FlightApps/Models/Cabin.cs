using System;
using System.Collections.Generic;
using System.Text;

namespace FlightApps.Models
{
    public class Cabin
    {
        public Cabin(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
