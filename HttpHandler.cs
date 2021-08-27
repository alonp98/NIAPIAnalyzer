using RestSharp;
using System;

namespace AnalayzeApi
{
    class HttpHandler
    {
        private readonly String mUrl;
        public HttpHandler(String url)
        {
            mUrl = url;
        }

        // return the content of the response from api
        public string Execute()
        {
            IRestResponse response = new RestClient(mUrl).Execute(new RestRequest(Method.GET));
            return response.Content;
        }

        

    }
}
