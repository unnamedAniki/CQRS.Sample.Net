using System;

namespace Sample.Application
{
    public class BusinessLogicException: Exception
    {
        public BusinessLogicException(string message) : base(message) { }
    }
}
