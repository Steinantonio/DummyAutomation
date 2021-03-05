using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTestingX1.GoRestPackage.DTOS.GetUser;
using ApiTestingX1.GoRestPackage.Utils.RequestUtils;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using TestX1Dummy.GoRestPackage.DTOS.PostUser;
using static TestX1Dummy.GoRestPackage.DTOS.GetUser.SingleUserResponse;
using static TestX1Dummy.GoRestPackage.DTOS.PostUser.PostUserResponse;

namespace ApiTestingX1.GoRestPackage.Helpers
{
    class RequestBuilder
    {

        public Root GetAllUserRequest(string uri)
        {
            Root userResponse = RestUtils.CallService<Root>(uri, Method.GET);
            return userResponse;
        }

        public MainNode GetSingleUserRequest(string uri)
        {
            MainNode singleUserResponse = RestUtils.CallService<MainNode>(uri, Method.GET);
            return singleUserResponse;
        }

        public MainNode PostUserRequest(string uri, string requestJsonBody)
       {

            MainNode postUserResponse = RestUtils.CallService<MainNode>(uri, Method.POST, requestJsonBody);
            return postUserResponse;

        }

        public MainNode DeleteUser(string uri)
        {

            MainNode deleteUserResponse = RestUtils.CallService<MainNode>(uri, Method.DELETE);
            return deleteUserResponse;

        }
    }
}
