using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public class Customer_Details
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime Dob { get; set; }
        public string HomeAddress { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string NextOfKin { get; set; }

        public List<Account_Details> Account_Details { get; set; }

    }
}
