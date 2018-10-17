﻿using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class BusinessLogic
    {
        Data Data = new Data();

        public List<Car> GetCars()
        {
            return Data.Cars;
        }

        public List<Customer> GetCustomers()
        {
            return Data.Customers;
        }

        public List<Booking> GetBookings()
        {
            return Data.Bookings;
        }

        public void AddCar(string registrationNumber, string brand, string model, int year)
        {
            if (registrationNumber == null || registrationNumber.Length != 6 ||
                brand == null || brand.Length == 0 || 
                model == null || model.Length == 0 || 
                year < 1900 || year > DateTime.Now.Year)
            {
                throw new ArgumentException();
            }

            Data.Cars.Add(
                new Car {
                    RegistrationNumber = registrationNumber,
                    Brand = brand,
                    Model = model,
                    Year = year
                }
            );
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

        public List<Car> GetAvailableCars(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == null || toDate == null || fromDate > toDate)
            {
                throw new ArgumentException();
            }

            List<Car> cars = Data.Cars; // all cars
            // the LINQ expression below gets bookings that are during the "fromDate" and "toDate" parameters
            List<Booking> bookings = Data.Bookings.Where(b =>
                (b.StartTime >= fromDate && b.StartTime <= toDate || // if booking start time is within the fromDate to toDate timespan
                b.EndTime >= fromDate && b.EndTime <= toDate) && // if booking end time is within the fromDate to toDate timespan
                b.ReturnTime == null) // if customer have not returned car
                .ToList();
            foreach (Booking b in bookings)
            {
                if (cars.Contains(b.Car)) // failsafe
                {
                    cars.Remove(b.Car);
                }
            }
            return cars; // available cars (with occupied ones from bookings removed)
        }

        public void CreateBooking(Car car, Customer customer, DateTime startTime, DateTime endTime)
        {
            if (car == null || customer == null || startTime == null || endTime == null || startTime > endTime)
            {
                throw new ArgumentException();
            }

            Data.Bookings.Add(
                new Booking {
                    Car = car,
                    Customer = customer,
                    StartTime = startTime,
                    EndTime = endTime
                }
            );
        }

        public void RemoveBooking(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentException();
            }

            Data.Bookings.Remove(booking);
        }
        
        public void ReturnCar(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentException();
            }

            booking.ReturnTime = DateTime.Now; // TODO: double check that list is being updated with return time
        }
    }
}
