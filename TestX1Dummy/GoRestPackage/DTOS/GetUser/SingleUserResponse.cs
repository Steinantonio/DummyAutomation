using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestX1Dummy.GoRestPackage.DTOS.GetUser
{
    class SingleUserResponse
    {
        public class ResponseData
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string status { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class MainNode
        {
            public int code { get; set; }
            public object meta { get; set; }
            public ResponseData data { get; set; }
        }

    }
}
