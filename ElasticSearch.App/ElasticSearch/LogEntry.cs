using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch
{
    class LogEntry
    {
        static int sessionNum = 1;
        Log log;
        public LogEntry()
        {
            log = new Log();
        }
        public void LogRequestType(string request)
        {
            log.Request = request;
        }
        public void LogRequestTime()
        {
            log.RequestTime = DateTime.Now.ToString();
        }
        public void LogStatus(string status)
        {
            log.Status = status;
        }
        public void LogSessionId()
        {
            log.SessionId = "Session-" + sessionNum.ToString();
        }
        public void LogResponseTime()
        {
            log.ResponseTime = DateTime.Now.ToString();
        }
        public void LogResponse(string response)
        {
            log.Response = response;
        }
        public void LogIpAddress()
        {
            var hostName = Dns.GetHostName();
            log.IpAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
        }
        public void LogDataIntoFile()
        {
            string logData = "Session Id: " + log.SessionId + Environment.NewLine + "Response Time: " + log.ResponseTime + Environment.NewLine + "IP Address: " + log.IpAddress + Environment.NewLine + "Request Type: " + log.Request + Environment.NewLine
                + "Response Time: " + log.ResponseTime + Environment.NewLine + "Status: " + log.Status + Environment.NewLine + "Response: " + log.Response + Environment.NewLine+Environment.NewLine;
            File.AppendAllText("D:\\Elastic_Search_Repo\\ElasticSearch.App\\LogFile.txt", logData);
        }
    }
}
