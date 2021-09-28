using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracking.Core.Tables
{
    [Table("tracking")]
    public sealed class Tracking
    {

        public Tracking(string clientId, string clientIp, string clientCountry, string siteIp, string siteCountry, byte operationSystem, string domain)
        {
            ClientId = clientId;
            ClientIp = clientIp;
            ClientCountry = clientCountry;
            Domain = domain;
            SiteIp = siteIp;
            SiteCountry = siteCountry;
            OperationSystemId = operationSystem;
            RequestDate = DateTime.UtcNow;
        }

        public Tracking()
        {
            
        }
        
        [Column("id")]
        public long Id { get; set; }
        
        [Column("client_id")]
        [StringLength(50)]
        public string ClientId { get; set; }
        
        [Column("client_ip")]
        [StringLength(15)]
        public string ClientIp { get; set;  }
        
        [Column("client_country")]
        [StringLength(2)]
        public string ClientCountry { get; set; }
        
        [Column("site_ip")]
        [StringLength(15)]
        public string SiteIp { get; set;  }
        
        [Column("site_country")]
        [StringLength(2)]
        public string SiteCountry { get; set;}
        
        [Column("domain")]
        [StringLength(300)]
        public string Domain { get; set;  }
        
        [Column("operation_system_id")]
        public byte OperationSystemId { get; set; }
        
        [ForeignKey("OperationSystemId")]
        public OperationSystem OperationSystem { get; set; }
        
        [Column("request_date")]
        public DateTime RequestDate { get; set; }
    }
}