using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalayzeApi
{
    class HttpHandler
    {
        private readonly String mUrl;
        public HttpHandler(String url)
        {
            mUrl = url;
        }

        public string Execute()
        {
            IRestResponse response = new RestClient(mUrl).Execute(new RestRequest(Method.GET));
            return response.Content;
        }

        

    }
}
