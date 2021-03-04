using ApiTestingX1.GoRestPackage.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingX1.GoRestPackage.RestApiEndpoints
{
    public class UserCadEndpoints
    {
        public string GetUsersEndpoint() // created this just to showcase if we had other endpoints 
        {
            return @"https://gorest.co.in/public-api/users";
        }

        public string GetPostApiEndpoint()
        {
            return "https://gorest.co.in/public-api/users";  
        }
    }
}
