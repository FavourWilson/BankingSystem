using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public class Balance
    {
        public int Id { get; set; }
        public List<Account_Details> Account_Details { get; set; }
        public List<Deposit> Deposits { get; set; }
        public List<Withdrawals> Withdrawals { get; set; }
        public double AccountBalance { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
    }
}
