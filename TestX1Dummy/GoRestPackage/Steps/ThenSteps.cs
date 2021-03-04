using ApiTestingX1.GoRestPackage.DTOS.GetUser;
using ApiTestingX1.GoRestPackage.Helpers;
using ApiTestingX1.GoRestPackage.RestApiEndpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using static TestX1Dummy.GoRestPackage.DTOS.GetUser.SingleUserResponse;

namespace ApiTestingX1.GoRestPackage.Steps
{
    [Binding]
    public sealed class ThenSteps
    {

        private readonly ScenarioContext context;
        public ThenSteps(ScenarioContext injectedContext) { context = injectedContext; }

        [Then(@"I receive the correct status")]
        public void ThenIReceiveTheCorrectStatus()
        {
            var singleUserCollectionResponse = context.Get<MainNode>("singleUserResponse");

            Assert.IsNotNull(singleUserCollectionResponse.data, "The SingleUser Collection is empty check the API response user might not exist");

            Assert.IsTrue(singleUserCollectionResponse.code == 200, "Status code is not OK ( 200 ) check api disponibility or if the user exist");

            Assert.IsTrue(singleUserCollectionResponse.data.name != null, "Single User API return name value null, check the integrity of the API");
        }

        [Then(@"I validate the created users")]
        public void ThenIValidateTheCreatedUsers()
        {
            RequestBuilder restSharpRequestBuilder = new RequestBuilder();

            var postUserFullResponse = context.Get<List<MainNode>>("PostResponseList"); // whole response
            var dataPostResponse = new List<ResponseData>(); // getting just the data from the full response

            List<ResponseData> fetchUsersIdList = new List<ResponseData>(); // new list to populate with the single user search id's for comparison's sake

            foreach (var item in postUserFullResponse)
            {
                var singleUserRequestUri = context.Get<string>("getPostUserUri") + "/" + item.data.id; // string to get single user 

                fetchUsersIdList.Add(restSharpRequestBuilder.GetSingleUserRequest(singleUserRequestUri).data); // fetch every single user, since there's pagination, its faster this way

                dataPostResponse.Add(item.data);
            }

            for (int i = 0; i < dataPostResponse.Count && i < dataPostResponse.Count; i++)
            {
                Assert.AreEqual(dataPostResponse[i].id, fetchUsersIdList[i].id);

                Assert.AreEqual(dataPostResponse[i].name, fetchUsersIdList[i].name);

                Assert.AreEqual(dataPostResponse[i].email, fetchUsersIdList[i].email);
            }
        }

        [Then(@"I delete my created users")]
        public void ThenIDeleteMyCreatedUsers()
        {
            
        }

    }
}
