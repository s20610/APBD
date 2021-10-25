using System;

namespace Cwiczenie2.Exceptions
{
    public class NotValidStudentData : Exception
    {

        public NotValidStudentData(string studentData) : base(String.Format("Invalid student data: {0}", studentData))
        {
        }
    }
    
    public class NotEnoughStudentDataException : Exception
    {
        public NotEnoughStudentDataException(string studentData) : base(String.Format("Not enough student data: {0}", studentData))
        {
        }
    }
}