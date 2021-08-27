using AnalayzeApi;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ApiUnitTests
{
    class GithubApiHandler
    {
        private static readonly String URL = "https://api.github.com/repos/highcharts/highcharts/commits";

        // get the response from the github api
        public string ExecuteRequestAndGetResponse()
        {
            HttpHandler handler = new HttpHandler(URL);
            return handler.Execute();

        }

        // get all the messages from the github api as a list
        public static List<String> parseResponseAndGetMessages(string response)
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

        // get only the response from stackoverflow api (for api test)
        public IRestResponse getGithubResponse()
        {
            var client = new RestClient(URL);
            IRestResponse response = client.Execute(new RestRequest(Method.GET));

            return response;
        }
    }
}
