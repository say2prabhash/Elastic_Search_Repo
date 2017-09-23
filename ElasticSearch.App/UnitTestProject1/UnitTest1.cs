using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticSearch;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Operations operation = new Operations();
            SampleData data = new SampleData();
            data.Id ="100";
            data.Name = "Prabhash";
            operation.Index(data);
        }
    }
}
