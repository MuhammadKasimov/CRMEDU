using System.Runtime;
namespace CRMEDU.Api.Exceptions
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {

        }
    }
}
