using System.ComponentModel.DataAnnotations;

namespace Tracking.Api.Infrastructure.Attributes
{
    public class SubdomainAttribute: ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var subdomainString = obj?.ToString();
            if (subdomainString == null)
            {
                return false;
            }

            var subdomainElems = subdomainString.Split(".");
            if (subdomainElems.Length <= 2)
            {
                return false;
            }

            foreach (var subdomainElem in subdomainElems)
            {
                if (string.IsNullOrWhiteSpace(subdomainElem))
                {
                    return false;
                }
            }

            return true;
        }
    }
}