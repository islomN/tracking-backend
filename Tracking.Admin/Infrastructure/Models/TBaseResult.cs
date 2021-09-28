namespace Tracking.Admin.Infrastructure.Models
{
    public class TBaseResult<T>
    {
        public TBaseResult(bool success, T? result, string message = null)
        {
            Success = success;
            Result = result;
            Message = message;
        }
        
        public TBaseResult(bool success, string message = null)
        {
            Success = success;
            Message = message;
        }
        
        public bool Success { get; }
        public T Result { get; }
        public string Message { get; }
        
    }
}