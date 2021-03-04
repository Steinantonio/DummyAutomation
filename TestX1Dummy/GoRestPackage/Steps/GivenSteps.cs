using ApiTestingX1.GoRestPackage.Helpers;
using ApiTestingX1.GoRestPackage.RestApiEndpoints;
using Newtonsoft.Json;
using System;
using System.IO;

using TechTalk.SpecFlow;

namespace ApiTestingX1.GoRestPackage.Steps
{
    [Binding]
    public sealed class GivenSteps
    {

        private readonly ScenarioContext context;
        public GivenSteps(ScenarioContext injectedContext) { context = injectedContext; }

        [Given(@"I get the api endpoint (.*)")]
        public void GivenIGetTheApiEndpoint(string requiredEndpoint)
        {
            UserCadEndpoints userCadEndpoints = new UserCadEndpoints();

            if (string.IsNullOrEmpty(requiredEndpoint)) { throw new Exception(); };

            switch (requiredEndpoint)
            {
                case "GetUsers":

                    context["getUserDetailsUri"] = userCadEndpoints.GetUsersEndpoint();

                    break;

                case "CreateUsers":

                    context["getPostUserUri"] = userCadEndpoints.GetPostApiEndpoint();

                    break;

            }

        }

        [Given(@"I get my Data file '(.*)'")]
        public void GivenIGetMyDataFile(string dataFileName)
        {
            var rawPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\GoRestPackage\\DATA\\" + dataFileName;

            if (dataFileName.Equals("Massa2.yaml"))
            {
                context["yamlFileIsTrue"] = dataFileName;
            }
            else
            {
                context["yamlFileIsTrue"] = "false";
            }

            context["rawPath"] = rawPath;
        }

    }
}
