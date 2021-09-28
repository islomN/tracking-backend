using System.Net;

namespace Tracking.Admin.Infrastructure.ActionResults
{
    public class SuccessActionResult: ExtendedObjectResult
    {
        public SuccessActionResult(object value = null, HttpStatusCode httpStatusCode = HttpStatusCode.OK) : base(value, httpStatusCode)
        {
            
        }
        
        public SuccessActionResult(HttpStatusCode httpStatusCode = HttpStatusCode.NoContent) : base(null, httpStatusCode)
        {
            
        }
        
        public SuccessActionResult() : base(null,  HttpStatusCode.NoContent)
        {
            
        }
    }
}