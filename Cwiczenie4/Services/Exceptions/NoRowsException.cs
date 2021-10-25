using System;

namespace Cwiczenie4.Services.Exceptions
{
    public class DataNoRowsException : Exception
    {
        public DataNoRowsException()
        {
            Console.WriteLine("No rows in database");
        }
    }
}