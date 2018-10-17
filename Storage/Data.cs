using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class Data
    {
        public List<Car> Cars = new List<Car>();
        public List<Customer> Customers = new List<Customer>();
        public List<Booking> Bookings = new List<Booking>();

        public Data() // initialization class with start values
        {
            Cars.Add(new Car {
                Brand = "Volvo",
                Model = "S60",
                Year = 2014,
                RegistrationNumber = "DFY 435"
            });
        }
    }
}
