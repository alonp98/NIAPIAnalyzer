using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalayzeApi;
using System.Net;

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
            string[] commits = AnalyzeApiExercise.Analyze("Github");
            Assert.IsTrue(commits.Length == 30, "Title list size isn't 30");
        }

        [TestMethod]
        public void ExTestStackOverFlow_step_1()
        {
            string[] titles =  AnalyzeApiExercise.Analyze("Stackoverflow");
            Assert.IsTrue(titles.Length == 30, "Title list size isn't 30");

        }

        [TestMethod]
        public void Ex_negative_test_step_1()
        {
            string[] titles = AnalyzeApiExercise.Analyze("Negative");
            Assert.IsTrue(titles == null);
        }

        [TestMethod]
        public void ExTestGithub_step_2()
        {
            string[] commits = AnalyzeApiExercise.Analyze("Github",1);
            Assert.IsTrue(commits.Length == 30, "commits list size isn't 30");
            foreach(string item in commits)
            {
                Assert.IsTrue(!item.Contains(" "),"Item containts space!!");
            }
        }

        [TestMethod]
        public void ExTestGithub_negative_step_2()
        {
            string[] commits = AnalyzeApiExercise.Analyze("Github", 5);
            Assert.IsTrue(commits == null);
           
        }

        [TestMethod]
        public void ExTestStackOverFlow_step_2()
        {
            string[] titles = AnalyzeApiExercise.Analyze("Stackoverflow", 1);
            Assert.IsTrue(titles.Length == 30, "titles list size isn't 30");
            foreach (string item in titles)
            {
                Assert.IsTrue(!item.Contains(" "), "Item containts space!!");
            }
        }

        [TestMethod]
        public void ExTestStackOverFlow_negative_step_2()
        {
            string[] commits = AnalyzeApiExercise.Analyze("Stackoverflow", 5);
            Assert.IsTrue(commits == null);

        }

        [TestMethod]
        public void negative_step_2()
        {
            string[] commits = AnalyzeApiExercise.Analyze("asd", 5);
            Assert.IsTrue(commits == null);

        }

        [TestMethod]
        public void stackoverflow_api_valid()
        {
            StackOverFlowApiHandler client = new StackOverFlowApiHandler();
            var response = client.getStackOverFlowResponse();
 
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [TestMethod]
        public void github_api_valid()
        {
            GithubApiHandler client = new GithubApiHandler();
            var response = client.getGithubResponse();

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }
    }
}
