using AnalayzeApi;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ApiUnitTests
{
    class AnalyzeApiExercise
    {
        // step 1
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
                List<String> commitsList = GithubApiHandler.parseResponseAndGetMessages(response);
                return commitsList.ToArray();
            }
            return null;
        }

        // step 2
        public static string[] Analyze(string datasourceName, long analysisFlowId)
        {
            // first we will analyze the data as we wanted at step 1
            string[] res = Analyze(datasourceName);
            if(res != null)
            {
                // running the analysis flow
                switch (analysisFlowId)
                {
                   case 1:
                        {
                            // filter the list as we wanted by the analysis
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
