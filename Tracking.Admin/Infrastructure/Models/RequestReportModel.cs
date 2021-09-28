using System;

namespace Tracking.Admin.Infrastructure.Models
{
    public class RequestReportModel
    {
        public RequestReportModel(string clientId, string clientIp, string clientCountry, DateTime date, string domain, string os, string siteCountry)
        {
            ClientId = clientId;
            ClientIp = clientIp;
            ClientCountry = clientCountry;
            Date = date;
            Domain = domain;
            Os = os;
            SiteCountry = siteCountry;
        }
        public string ClientId { get; }
        
        public string ClientIp { get; }
        
        public string ClientCountry { get; }
        
        public DateTime Date { get; }

        public string Domain { get; }

        public string Os { get; }
        
        public string SiteCountry { get; }
    }
}