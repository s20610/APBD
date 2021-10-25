using System;

namespace Cwiczenie4.Services.Exceptions
{
    public class NotMatchedColumnNameException : Exception
    {
        public NotMatchedColumnNameException()
        {
            Console.WriteLine("No matched column name");
        }
    }
}