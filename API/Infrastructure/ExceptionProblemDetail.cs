using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API.Infrastructure
{
    public class ExceptionProblemDetail : ProblemDetails
    {
        public ExceptionProblemDetail(Exception exception)
        {
            Title = exception.Message;
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.StackTrace;
        }
    }
}
