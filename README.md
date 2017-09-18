####################### RACES #######################

########## Source ##########

The source for the solution is available from following git repository url.

Url = 


########## Solution ##########

The solution is completed using VISUAL STUDIO 2017.

The solution mainly contains two host projects.
Both of them are hosted on IIS EXPRESS.

1. Race.Web.Api -  The races web api
2. Race.Web.Application - The web application with the required web page


########## How to run ##########

1. Download the source from the git repository as mentioned above
2. Open and build is Visual Studio 2017.
3. Run the solution where above both projects must be set as start up projects
4. Go to the web page and click 'Load Race Information' button
5. All the races will be loaded via web api and displayed on web page


########## Notes ##########

1. Tried to use multiple layers to separate concerns
2. For XML processing Linq to XML is used, although XmlSerializer could even be used. I like to avoid XML attributues polluting domain models.
3. Minimum level of web page is completed and proper styling of the web page is avoided.
4. All possible test cases are not covered.
5. Did object state testing with stubs, rather than behaivour testing