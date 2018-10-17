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

        public void AddCar()
        {
            Data.Cars.Add(new Car { });
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
