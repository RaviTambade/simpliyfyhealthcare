using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Respositories
{
    public  class HRManager
    {
        public HRManager() { }
        public static List<Person> GetAllPeople()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person { Age = 20, Name = "Ravi" });
            list.Add(new Person { Age = 22, Name = "Pragati" });
            list.Add(new Person { Age = 21, Name = "Ajinkya" });
            return list;
        }
    }
}
