using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VKart.Models;

namespace VKart.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}