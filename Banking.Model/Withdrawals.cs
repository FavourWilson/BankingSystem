using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public class Withdrawals
    {
        [Key]
        public int Id { get; set; }
        public string  AccountNumber { get; set; }
        public double Amount { get; set; }
        public DateTime DepositDate { get; set; }

       
    }
}
