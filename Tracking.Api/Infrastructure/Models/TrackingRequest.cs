using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Tracking.Api.Infrastructure.Attributes;

namespace Tracking.Api.Infrastructure.Models
{
    public class TrackingRequest
    {
        [Required]
        [FromQuery(Name = "secret")]
        public string Secret { get; set; }
        
        [IpV4Address]
        [FromQuery(Name = "client_ip")]
        public string ClientIP { get; set; }
        
        [Subdomain]
        [FromQuery(Name = "domain")]
        public string Domain { get; set; }
        
        [Required]
        [FromQuery(Name = "os")]
        public string OS { get; set; }
        
        [Required]
        [StringLength(32)]
        [FromQuery(Name = "client_id")]
        public string ClientId { get; set; }
        
        [IpV4Address]
        [FromHeader(Name = "Site-IP")]
        public string SiteIP { get; set; }
    }
}