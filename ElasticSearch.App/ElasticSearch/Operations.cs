using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ElasticSearch
{
    public class Operations
    {
        public bool Index(SampleData data)
        {
            LogEntry log = new LogEntry();
            log.LogRequestTime();
            var myJson = new SampleData
            {
                Name = data.Name,
                Id = data.Id,
            };
            var response = EsClient.InitailizeElasticClient().Index(myJson, i => i
                  .Index("blog")
                  .Type("entry")
                  .Id(data.Id)
                  .Refresh(Elasticsearch.Net.Refresh.True));
            if (response != null)
            {
                log.LogResponseTime();
                log.LogResponse(response.ToString());
                log.LogSessionId();
                log.LogRequestType("Index()");
                log.LogStatus("Sucessfull");
                log.LogIpAddress();
                log.LogDataIntoFile();
                log.LogDataIntoIndex();
                return true;
            }
            log.LogResponseTime();
            log.LogResponse(response.ToString());
            log.LogSessionId();
            log.LogRequestType("Index()");
            log.LogStatus("Failed");
            log.LogIpAddress();
            log.LogDataIntoFile();
            log.LogDataIntoIndex();
            return false;
        }

        public List<SampleData> SearchData(string searchID)
        {
            LogEntry log = new LogEntry();
            log.LogRequestTime();
            List<SampleData> dataList = new List<SampleData>();
            var response = EsClient.InitailizeElasticClient().Search<SampleData>(s=>s
            .Index("blog")
            .Type("entry")
            .Query(q => q.Match(t => t.Field("_id").Query(searchID))));
            if (response != null)
            {
                foreach (var hit in response.Hits)
                {
                    var data = new SampleData();
                    data.Id = hit.Id.ToString();
                    data.Name = hit.Source.Name.ToString();
                    dataList.Add(data);
                }
                log.LogResponseTime();
                log.LogResponse(response.ToString());
                log.LogSessionId();
                log.LogRequestType("SearchData("+searchID+")");
                log.LogStatus("Sucessfull");
                log.LogIpAddress();
                log.LogDataIntoFile();
                log.LogDataIntoIndex();
            }
            log.LogResponseTime();
            log.LogResponse(response.ToString());
            log.LogSessionId();
            log.LogRequestType("SearchData(" + searchID + ")");
            log.LogStatus("Failed");
            log.LogIpAddress();
            log.LogDataIntoFile();
            log.LogDataIntoIndex();
            return dataList;
        }
        public bool DeleteData(string index)
        {
            LogEntry log = new LogEntry();
            log.LogRequestTime();
            var response = EsClient.InitailizeElasticClient().DeleteIndex(index);
            if (response != null)
            {
                log.LogResponseTime();
                log.LogResponse(response.ToString());
                log.LogSessionId();
                log.LogRequestType("DeleteIndex(" + index + ")");
                log.LogStatus("Sucessfull");
                log.LogIpAddress();
                log.LogDataIntoFile();
                log.LogDataIntoIndex();
                return true;
            }
            log.LogResponseTime();
            log.LogResponse(response.ToString());
            log.LogSessionId();
            log.LogRequestType("DeleteIndex("+index+")");
            log.LogStatus("Failed");
            log.LogIpAddress();
            log.LogDataIntoFile();
            log.LogDataIntoIndex();
            return false;
        }
    }
}
