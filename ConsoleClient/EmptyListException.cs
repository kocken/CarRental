using System;
using System.Collections.Generic;
using System.Text;

namespace TestClient
{
    public class EmptyListException : Exception
    {
        public EmptyListException(string message) : base(message)
        {

        }
    }
}
