using System.Collections.Generic;
using Pricer_v3.Data;

namespace Pricer_v3
{
    public class MonitorItem
    {
        public int Id { get; set; }
        public string Url { get; set; }
        
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        
        public string Site { get; set; }

        public int UserId { get; set; }
        
        //public string XPath { get; set; }
        
        public double FirstPrice { get; set; }
        public double LastPrice { get; set; }
    }
}