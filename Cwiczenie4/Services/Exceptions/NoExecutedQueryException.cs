using System;

namespace Cwiczenie4.Services.Exceptions
{
    public class NoExecutedQueryException : Exception
    {
        public NoExecutedQueryException()
        {
            Console.WriteLine("Query not executed");
        }
    }
}