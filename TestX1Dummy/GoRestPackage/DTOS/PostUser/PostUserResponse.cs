using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestX1Dummy.GoRestPackage.DTOS.PostUser
{
    class PostUserResponse
    {
        public class InnerData
        {
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string status { get; set; }
            public DateTime created_at { get; set; }
            public DateTime updated_at { get; set; }
        }

        public class InnerNode
        {
            public int code { get; set; }
            public object meta { get; set; }
            public InnerData innerData { get; set; }
        }
    }
}
