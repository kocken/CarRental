using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email} {TelephoneNumber}";
        }

        public bool IsValid()
        {
            if (FirstName == null || LastName == null || TelephoneNumber == null || Email == null)
            {
                return false;
            }
            return true;
        }
    }
}