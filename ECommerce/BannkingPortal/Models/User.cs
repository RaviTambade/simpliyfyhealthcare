using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannkingPortal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNuber { get; set; }
        public string Location { get;set; }

    }
}