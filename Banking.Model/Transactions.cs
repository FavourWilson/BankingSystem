using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Model
{
    public class Transactions
    {
        public int Id  { get; set; }
        public List<Balance>  Balances { get; set; }
        public DateTime TransactionDate { get; set; }

        public List<Deposit> Deposits { get; set; }

        public List<Withdrawals> Withdrawals { get; set; }
        public string SentTo { get; set; }
        public string RecievedFrom { get; set; }

        public double Amount { get; set; }

        public double TotalTransaction { get; set; }
    }
}
