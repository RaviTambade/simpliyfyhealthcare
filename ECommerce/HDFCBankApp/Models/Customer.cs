using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDFCBankApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get;set; }
        public string Email { get; set; }
        public string ContactNumber { get;set; }
    }
}