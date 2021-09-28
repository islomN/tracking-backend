using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Tracking.Admin.Infrastructure.Models
{
    [NotMapped]
    public class CountryReportModel
    {
        public CountryReportModel(string clientCountry, int requests)
        {
            ClientCountry = clientCountry;
            Requests = requests;
        }

        [JsonProperty("clientCountry")]
        [Column("client_country")]
        public string ClientCountry { get; set; }
        
        [JsonProperty("requests")]
        [Column("requests")]
        public int Requests { get; set; } 
        
        [JsonIgnore]
        [Column("count")]
        public int Count { get; set; }
    }
}