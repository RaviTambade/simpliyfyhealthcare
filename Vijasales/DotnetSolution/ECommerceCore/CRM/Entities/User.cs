using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Password {  get; set; }
        public string Email { get; set; }
        public string Address {  get; set; }
        public string Role { get; set; }
        public string ContactNumber {  get; set; }
        public string ImageUrl {  get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
