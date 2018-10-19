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
        public DateTime ReturnTime { get; set; }

        public override string ToString()
        {
            return (ReturnTime != default(DateTime) ? "[RETURNED]" : "[ACTIVE]") +
                $" {Customer.FirstName} {Customer.LastName} " +
                $"{StartTime}-{EndTime} {Car.ToString()}";
        }

        public bool IsStarted()
        {
            return DateTime.Now >= StartTime;
        }
    }
}