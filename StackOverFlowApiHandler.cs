using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalayzeApi
{
    class StackOverFlowApiHandler
    {
        private static readonly String URL = "https://api.stackexchange.com/2.2/tags/highcharts/faq?site=stackoverflow";

        // get response from stackoverflow api
        public string ExecuteRequestAndGetResponse()
        {
            HttpHandler handler = new HttpHandler(URL);
            return handler.Execute();
     
        }
        // this function will return a list of all the titles from the stackoverflow api
        public static List<String> parseResponseAndGetTitles(string response)
        {
            List<String> result = new List<string>();
            try
            {
                result =  JsonConvert.DeserializeObject<Rootobject>(response).items.Select(a => a.title).ToList();
            }
            catch (Exception ignoreException)
            {

            }
            return result;
        }

        // get only the response from stackoverflow api (for api test)
        public IRestResponse getStackOverFlowResponse()
        {
            var client = new RestClient(URL);
            IRestResponse response = client.Execute(new RestRequest(Method.GET));

            return response;
        }

    }
}
