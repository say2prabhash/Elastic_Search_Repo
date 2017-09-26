using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ElasticSearch;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Adding_Index()
        {
            Operations operation = new Operations();
            SampleData data = new SampleData();
            data.Id = "103";
            data.Name = "Prabhash";
            Assert.IsTrue(operation.Index(data));

        }
        [TestMethod]
        public void Searching_data()
        {
            Operations operation = new Operations();
            List<SampleData> list = operation.SearchData("100");
            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void Deleting_data()
        {
            Operations operation = new Operations();
            Assert.IsTrue(operation.DeleteData("blueprint"));

        }
    }
}
