using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch
{
    public class Operations
    {
        EsClient _esClient = new EsClient();
        public bool Index(SampleData data)
        {
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
            return true;
        }
        public List<SampleData> SearchData(string searchID)
        {
            List<SampleData> dataList = new List<SampleData>();
            var response = EsClient.InitailizeElasticClient().Search<SampleData>(s => s
            .Index("blog")
            .Type("entry")
            .Query(q => q.Term(t => t.Field("_id").Value(searchID))));               

            foreach (var hit in response.Hits)
            {
                var data = new SampleData();
                data.Id= hit.Id.ToString();
                data.Name = hit.Source.Name.ToString();
                dataList.Add(data);
            }
            return dataList;
        }

    }
}
