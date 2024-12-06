using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Entities
{
    [Table("VsCards")]
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string Pass { get; set; }

        public string CVV { get; set; }

        public string AccountId { get; set; }

        public string CardType { get; set; }

        public double CardLimit { get; set; }

        public string CardNumber { get; set; }

        public string ExpiryDate { get; set; }
    }
}
