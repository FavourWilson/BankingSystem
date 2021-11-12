using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public class Account_Details
    {

        [Key]
        public int Id { get; set; }
       
        public string AccountNumber { get; set; }

        public AccountType AccountType { get; set; }

    }
}
