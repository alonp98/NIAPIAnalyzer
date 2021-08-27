using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalayzeApi
{
    class StackOverFlowApiHandler
    {
        private static readonly String URL = "https://api.stackexchange.com/2.2/tags/highcharts/faq?site=stackoverflow";

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
                result =  JsonConvert.DeserializeObject<Rootobject>(response).items.Select(a => a.title).ToList();
            }
            catch (Exception ignoreException)
            {

            }
            return result;
        }

    }
}
