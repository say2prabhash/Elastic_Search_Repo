using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch
{
    class Log
    {
        public string Request { get; set; }
        public string Response { get; set; }
        public string Status { get; set; }
        public string RequestTime { get; set; }
        public string ResponseTime { get; set; }
        public string SessionId { get; set; }
        public string IpAddress { get; set; }
    }
}
