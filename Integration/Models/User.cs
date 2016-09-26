using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integration.Models
{
    public class User
    {
        public string name { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public string hash_id { set; get; }
    }
}