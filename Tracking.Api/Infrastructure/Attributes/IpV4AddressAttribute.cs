using System.ComponentModel.DataAnnotations;

namespace Tracking.Api.Infrastructure.Attributes
{
    public class IpV4AddressAttribute: ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var ipString = obj?.ToString();
            if (ipString == null)
            {
                return false;
            }

            var ipRows = ipString.Split(".");
            if (ipRows.Length != 4)
            {
                return false;
            }

            foreach (var t in ipRows)
            {
                var isParse = byte.TryParse(t, out _);
                if (!isParse)
                {
                    return false;
                }
            }

            return true;
        }
    }
}