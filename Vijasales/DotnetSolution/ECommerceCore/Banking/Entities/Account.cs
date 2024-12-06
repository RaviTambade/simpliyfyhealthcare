using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Entities
{
    [Table("VsAccounts")]
    public class Account
    {
        [Key]
        public int AccountId {  get; set; }
        public string Passcode {  get; set; }
        public int UserId {  get; set; }
        public string AccountNumber {  get; set; }
        public string BankName {  get; set; }
        public string IFSCCode { get; set;}
        public double Balance { get; set;}
    }
}
