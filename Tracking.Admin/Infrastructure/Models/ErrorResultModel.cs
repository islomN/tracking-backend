namespace Tracking.Admin.Infrastructure.Models
{
    public class ErrorResultModel
    {
        public ErrorResultModel(string message)
        {
            Message = message;
        }
        
        public string Message { get; }
    }
}