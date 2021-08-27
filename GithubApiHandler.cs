using AnalayzeApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUnitTests
{
    class GithubApiHandler
    {
        private static readonly String URL = "https://api.github.com/repos/highcharts/highcharts/commits";

        public string ExecuteRequestAndGetResponse()
        {
            HttpHandler handler = new HttpHandler(URL);
            return handler.Execute();

        }
        public static List<String> parseResponseAndGetTitles(string response)
        {
            List<String> result = new List<string>();
            try
            {
                var githubObj = JsonConvert.DeserializeObject<List<Property>>(response);
                foreach (var item in githubObj)
                {
                    result.Add(item.commit.message);
                }
            }
            catch (Exception ignoreException)
            {

            }
            return result;
        }
    }
}
