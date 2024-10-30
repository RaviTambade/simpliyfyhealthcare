using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    //POCO : Plain Old CLR object
    public class Customer
    {
            public int Id { get; set; }  //auto property
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string  Email { get; set; }
            public string Contact { get;set; }
     
    }
}
