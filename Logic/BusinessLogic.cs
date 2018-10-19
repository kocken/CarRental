using Storage;
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

        public List<Booking> GetActiveBookings(bool isStarted)
        {
            return Data.Bookings.Where(b =>
            b.ReturnTime == default(DateTime) && (isStarted ? b.IsStarted() : !b.IsStarted())).ToList();
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
                new Car
                {
                    RegistrationNumber = registrationNumber,
                    Brand = brand,
                    Model = model,
                    Year = year
                }
            );
        }

        public void RemoveCar(Car car)
        {
            if (car == null || !Data.Cars.Contains(car))
            {
                throw new ArgumentException();
            }

            Data.Cars.Remove(car);
        }

        public void AddCustomer(string firstName, string lastName, string telephoneNumber, string email)
        {
            if (firstName == null || lastName == null || telephoneNumber == null || email == null)
            {
                throw new ArgumentException();
            }

            Data.Customers.Add(
                new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    TelephoneNumber = telephoneNumber,
                    Email = email
                }
            );
        }

        public void ChangeCustomer(Customer customer) // change existing object as done in #ReturnCar below
        {

        }

        public void RemoveCustomer(Customer customer)
        {
            if (customer == null || !Data.Customers.Contains(customer))
            {
                throw new ArgumentException();
            }

            Data.Customers.Remove(customer);
        }

        public List<Car> GetAvailableCars(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == null || toDate == null || fromDate > toDate)
            {
                throw new ArgumentException();
            }

            List<Car> cars = Data.Cars.ToList(); // all cars
            // the LINQ expression below gets bookings that are during the "fromDate" and "toDate" parameters
            List<Booking> currentActiveBookings = Data.Bookings.Where(b =>
                (b.StartTime >= fromDate && b.StartTime <= toDate || // if booking start time is within the fromDate to toDate timespan
                b.EndTime >= fromDate && b.EndTime <= toDate || // if booking end time is within the fromDate to toDate timespan
                b.StartTime <= fromDate && b.EndTime >= toDate) && // if booking covers the whole timespan
                b.ReturnTime == default(DateTime)) // if customer have not returned car
                .ToList();
            foreach (Booking b in currentActiveBookings)
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
            List<Car> availableCars = GetAvailableCars(startTime, endTime);
            if (car == null || customer == null || startTime == null || endTime == null || startTime > endTime ||
                !Data.Cars.Contains(car) || !Data.Customers.Contains(customer) ||
                !availableCars.Contains(car)) // makes sure car is available
            {
                throw new ArgumentException();
            }

            Data.Bookings.Add(
                new Booking
                {
                    Car = car,
                    Customer = customer,
                    StartTime = startTime,
                    EndTime = endTime
                }
            );
        }

        public void RemoveBooking(Booking booking)
        {
            if (booking == null || !Data.Bookings.Contains(booking) ||
                DateTime.Now >= booking.StartTime && booking.ReturnTime == default(DateTime)) // booking is active and did not return car
            {
                throw new ArgumentException();
            }

            Data.Bookings.Remove(booking);
        }

        public void ReturnCar(Booking booking)
        {
            if (booking == null || !Data.Bookings.Contains(booking) ||
                booking.ReturnTime != default(DateTime)) // already returned car
            {
                throw new ArgumentException();
            }

            booking.ReturnTime = DateTime.Now;
        }
    }
}