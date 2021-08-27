using AnalayzeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiUnitTests
{
    class AnalayzipApiExcerise
    {
        public static string[] Analyze(string datasourceName)
        {
            if (datasourceName.Equals("Stackoverflow"))
            {
                StackOverFlowApiHandler apiHandler = new StackOverFlowApiHandler();
                string response = apiHandler.ExecuteRequestAndGetResponse();
                List<String> titleList = StackOverFlowApiHandler.parseResponseAndGetTitles(response);
                return titleList.ToArray();
 
            } else if (datasourceName.Equals("Github")) {
                GithubApiHandler githubApiHandler = new GithubApiHandler();
                string response = githubApiHandler.ExecuteRequestAndGetResponse();
                List<String> commitsList = GithubApiHandler.parseResponseAndGetTitles(response);
                return commitsList.ToArray();
            }
            return null;
        }

        public static string[] Analyze(string datasourceName, long analysisFlowId)
        {
            string[] res = Analyze(datasourceName);
            if(res != null)
            {
                switch (analysisFlowId)
                {
                   case 1:
                        {
                            List<string> filteredList = new List<string>();
                            foreach(var item in res)
                            {
                                if(item.Length >=5)
                                {
                                    filteredList.Add(Regex.Replace(item, @"\s", ""));
                                }
                            }
                            return filteredList.ToArray();
                        }
                    default:
                        {
                            return null;
                        }

                }
            }   
            return null;
        }
    }
}
