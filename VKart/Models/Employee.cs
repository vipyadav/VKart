using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VKart.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsTemporary { get; set; }
        public int Dept_id { get; set; }
    }
}