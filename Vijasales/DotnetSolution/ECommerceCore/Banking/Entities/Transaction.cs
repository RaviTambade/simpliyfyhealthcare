using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Entities
{
    [Table("VsTransactions")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int ToAccountId {  get; set; }   
        public int FromAccountId {  get; set; }
        public double Amount {  get; set; }
        public string TransactionDate {  get; set; }
        public string TransactionId {  get; set; }

    }
}
