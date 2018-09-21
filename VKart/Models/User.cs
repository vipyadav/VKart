using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VKart.Models
{
    public class User
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}