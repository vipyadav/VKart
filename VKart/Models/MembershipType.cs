﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VKart.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public int SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}