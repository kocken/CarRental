using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class Booking
    {
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
