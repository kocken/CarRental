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

            Cars.Add(new Car
            {
                Brand = "BMW",
                Model = "X3",
                Year = 2013,
                RegistrationNumber = "ABC378"
            });

            Cars.Add(new Car
            {
                Brand = "Volkswagen",
                Model = "Golf GTE",
                Year = 2018,
                RegistrationNumber = "BCT569"
            });

            Cars.Add(new Car
            {
                Brand = "Toyota",
                Model = "Yaris",
                Year = 2015,
                RegistrationNumber = "HJD248"

            });

            Customers.Add(new Customer
            {
                FirstName = "Robert",
                LastName = "Andersson",
                TelephoneNumber = "0789656489",
                Email = "randersson@yahoo.se"
            });

            Customers.Add(new Customer
            {
                FirstName = "Joakim",
                LastName = "Lars",
                TelephoneNumber = "0765874568",
                Email = "abc@yahoo.se"
            });

            Customers.Add(new Customer
            {
                FirstName = "Joakim",
                LastName = "Lars",
                TelephoneNumber = "0765874568",
                Email = "joaklars@gmail.com"
            });

            Customers.Add(new Customer
            {
                FirstName = "Victor",
                LastName = "Larsson",
                TelephoneNumber = "0798742356",
                Email = "vlarsson@gmail.com"
            });

            Bookings.Add(new Booking
            {
                Customer = Customers[0],
                Car = Cars[0],
                StartTime = new DateTime(2018, 1, 18),
                EndTime = new DateTime(2018, 1, 25),
                ReturnTime = new DateTime(2018, 1, 25)
            });

            Bookings.Add(new Booking
            {
                Customer = Customers[1],
                Car = Cars[1],
                StartTime = new DateTime(2018, 5, 1),
                EndTime = new DateTime(2018, 5, 5),
                ReturnTime = new DateTime(2018, 5, 5)
            });

            Bookings.Add(new Booking
            {
                Customer = Customers[2],
                Car = Cars[2],
                StartTime = new DateTime(2018, 3, 5),
                EndTime = new DateTime(2018, 3, 8),
                ReturnTime = new DateTime(2018, 3, 8)
            });

            Bookings.Add(new Booking
            {
                Customer = Customers[3],
                Car = Cars[3],
                StartTime = new DateTime(2018, 9, 1),
                EndTime = new DateTime(2018, 9, 10),
                ReturnTime = new DateTime(2018, 9, 10)
            });

            Bookings.Add(new Booking
            {
                Customer = Customers[0],
                Car = Cars[0],
                StartTime = new DateTime(2018, 10, 17),
                EndTime = new DateTime(2018, 10, 27),
                ReturnTime = default(DateTime)
            });
        }
    }
}
