# OP Analyzer

## Step 1:
Created an API which takes input from StackOverFlow \ Github API and returns the following:
1. If "Stackoverflow" is given as datasourceName, it will return as an output all the titles from the API.
2. If "Github" is given as datasourceName, it will return as an output all the messages attached to the commits.

## Step 2:
Extended the API functionality, and added a function that can take a predefined analysisFlowId, and will run the analysis on the returned data from step 1.
For this exercise, the analysis example was as following:
- From the data that step 1 returned, do as following:
> 1. Remove all items that containes under 5 charachters.
> 2. Remove all spaces from items.
> 3. Return the filtered answer.

## Tests:
For this projects, the <i>ApiTests.cs</i> is making Unit and API tests on the code.

