using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Tracking.Admin.Infrastructure.ActionResults
{
    public class ExtendedObjectResult: ObjectResult
    {
        protected ExtendedObjectResult(object value, HttpStatusCode statusCode):base(value)
        {
            StatusCode = (int)statusCode;
        }
    }
}