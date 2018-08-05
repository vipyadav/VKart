using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VKart.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MyPropeMemberShipTypeIdrty { get; set; } // EF will recognize it as Foreign Key
    }
}