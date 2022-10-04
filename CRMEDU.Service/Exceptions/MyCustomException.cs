using System;
namespace CRMEDU.Service.Exceptions
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {

        }
    }
}