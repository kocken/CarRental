using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class BusinessLogic
    {
        Data Data = new Data();

        public int TestCount() // just a test for console app
        {
            return 3;
        }

        public void AddCar(string registrationNumber, string brand, string model, int year)
        {
            Data.Cars.Add(new Car { RegistrationNumber = registrationNumber, Brand = brand, Model = model, Year = year });
        }

        public void RemoveCar()
        {

        }

        public void AddCustomer()
        {

        }

        public void ChangeCustomer()
        {

        }

        public void RemoveCustomer()
        {

        }

        // Mikael tar dessa och neråt
        public void ShowBookings()
        {

        }

        public void CreateBooking()
        {

        }

        public void RemoveBooking()
        {

        }
        
        public void ReturnCar()
        {

        }
    }
}
