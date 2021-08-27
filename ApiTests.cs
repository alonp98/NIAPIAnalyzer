using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalayzeApi;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ApiUnitTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void StackOverFlow_valid()
        {
            //Post api request

            StackOverFlowApiHandler apiHandler = new StackOverFlowApiHandler();
            string response = apiHandler.ExecuteRequestAndGetResponse();

            //Assert response not empty
            Assert.IsTrue(response.Length > 0);

            //get title list
            var titleList = StackOverFlowApiHandler.parseResponseAndGetTitles(response);

            //Assert number of titles
            Assert.IsTrue(titleList.Count == 30);
            //Assert.IsTrue(titleList[0].Equals("Why are Bootstrap tabs displaying tab-pane divs with incorrect widths when using highcharts?"));
            ///Assert.IsTrue(titleList[29].Equals("creating highchart with ajax json data"));
        }

        [TestMethod]
        public void StackOverFlow_negative()
        {
            var titleList = StackOverFlowApiHandler.parseResponseAndGetTitles("{asdasdasdasdasdasdasdA}");
            Assert.IsTrue(titleList.Count == 0);
        }


        [TestMethod]
        public void ExTestGithub_step_1()
        {
            string[] commits = AnalayzipApiExcerise.Analyze("Github");
            Assert.IsTrue(commits.Length == 30, "Title list size isn't 30");
        }

        [TestMethod]
        public void ExTestStackOverFlow_step_1()
        {
            string[] titles =  AnalayzipApiExcerise.Analyze("Stackoverflow");
            Assert.IsTrue(titles.Length == 30, "Title list size isn't 30");

        }

        [TestMethod]
        public void Ex_negative_test_step_1()
        {
            string[] titles = AnalayzipApiExcerise.Analyze("Negative");
            Assert.IsTrue(titles == null);
        }

        [TestMethod]
        public void ExTestGithub_step_2()
        {
            string[] commits = AnalayzipApiExcerise.Analyze("Github",1);
            Assert.IsTrue(commits.Length == 30, "commits list size isn't 30");
            foreach(string item in commits)
            {
                Assert.IsTrue(!item.Contains(" "),"Item containts space!!");
            }
        }

        [TestMethod]
        public void ExTestGithub_negative_step_2()
        {
            string[] commits = AnalayzipApiExcerise.Analyze("Github", 5);
            Assert.IsTrue(commits == null);
           
        }

        [TestMethod]
        public void ExTestStackOverFlow_step_2()
        {
            string[] titles = AnalayzipApiExcerise.Analyze("Stackoverflow", 1);
            Assert.IsTrue(titles.Length == 30, "titles list size isn't 30");
            foreach (string item in titles)
            {
                Assert.IsTrue(!item.Contains(" "), "Item containts space!!");
            }
        }

        [TestMethod]
        public void ExTestStackOverFlow_negative_step_2()
        {
            string[] commits = AnalayzipApiExcerise.Analyze("Stackoverflow", 5);
            Assert.IsTrue(commits == null);

        }

        [TestMethod]
        public void negative_step_2()
        {
            string[] commits = AnalayzipApiExcerise.Analyze("asd", 5);
            Assert.IsTrue(commits == null);

        }



    }
}
