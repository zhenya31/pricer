using System.Collections.Generic;
using Pricer_v3.Data;

namespace Pricer_v3
{
    public class MonitorItem
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public double LastPrice { get; set; }
    }
}