using ApiTestingX1.GoRestPackage.DTOS.GetUser;
using ApiTestingX1.GoRestPackage.Helpers;
using ApiTestingX1.GoRestPackage.RestApiEndpoints;
using ApiTestingX1.GoRestPackage.Utils.RequestUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestX1Dummy.GoRestPackage.DTOS.GetUser;
using TestX1Dummy.GoRestPackage.DTOS.PostUser;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using static TestX1Dummy.GoRestPackage.DTOS.GetUser.SingleUserResponse;
using static TestX1Dummy.GoRestPackage.DTOS.PostUser.PostUserResponse;

namespace ApiTestingX1.GoRestPackage.Steps
{
    [Binding]
    public sealed class WhenSteps
    {

        private readonly ScenarioContext context;
        public WhenSteps(ScenarioContext injectedContext) { context = injectedContext; }

        [When(@"I create my find all user request")]
        public void WhenICreateMyRestRequest()
        {
            RequestBuilder restSharpRequestBuilder = new RequestBuilder();

            var response = restSharpRequestBuilder.GetAllUserRequest(context.Get<string>("getUserDetailsUri"));

            context["AllUsersResponseCollection"] = response;
        }

        [When(@"I select a single user from the returned list")]
        public void WhenIselectASingleUserFromTheReturnedList()
        {
            var AllUsersResponse = context.Get<Root>("AllUsersResponseCollection").data;

            List<Data> CollectionList = new List<Data>();

            foreach (var item in AllUsersResponse)
            {
                CollectionList.Add(item);
            }

            Random random = new Random();

            int index = random.Next(CollectionList.Count);

            context["singleUserId"] = CollectionList[index].id;

        }

        [When(@"I send the single user request")]
        public void WhenISendTheSingleUserRequest()
        {
            RequestBuilder restSharpRequestBuilder = new RequestBuilder();

            var singleUserRequestUri = context.Get<string>("getUserDetailsUri") + "/" + context.Get<int>("singleUserId");
            var response = restSharpRequestBuilder.GetSingleUserRequest(singleUserRequestUri);

            context["singleUserResponse"] = response;

        }

        [When(@"I prepare the post user request")]
        public void WhenIPrepareThePostUserRequest()
        {
            var datafilePath = context.Get<string>("rawPath");

            if (context.Get<string>("yamlFileIsTrue").Equals("Massa2.yaml")) // since i am using 2 files i am hard coding but usually i would make a helper to validate extensions using regex
            {

                var reader = new StreamReader(datafilePath);

                var deserializer = new Deserializer();
                var yamlObject = deserializer.Deserialize(reader);

                // now convert the object to JSON
                JsonSerializer js = new JsonSerializer();

                var writer = new StringWriter();
                js.Serialize(writer, yamlObject);
                string dataFile = writer.ToString();

                context["UserPostRequest"] = JsonConvert.DeserializeObject<List<PostUserJsonData>>(dataFile);
            }
            else
            {
                var dataFile = File.ReadAllText(datafilePath);
                context["UserPostRequest"] = JsonConvert.DeserializeObject<List<PostUserJsonData>>(dataFile);
            }
        }

        [When(@"I send my post users request")]
        public void WhenISendMyPostUsersRequest()
        {
            
           RequestBuilder restSharpRequestBuilder = new RequestBuilder();

            List<MainNode> responseList = new List<MainNode>();

            var uri = context.Get<string>("getPostUserUri");

            var bodyData = context.Get<List<PostUserJsonData>>("UserPostRequest");


            foreach (var item in bodyData)
            {
                var stringJsonObject = JsonConvert.SerializeObject(item);

                var response = restSharpRequestBuilder.PostUserRequest(uri, stringJsonObject);

                responseList.Add(response);
            }

            context["PostResponseList"] = responseList;
        }

    }
}
