using Banking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public class CustomerRepository : IBalance
    {
        private readonly AppDbContext context;
        private int acctid;
        private int depositId;
        private int withdrawalsId;

        public Customer_Details details { get; set; }
        public Deposit deposit { get; set; }
        public Withdrawals withdrawals { get; set; }
        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Balance Add(Balance newCustomerBalance)
        {
            
            if(GetCustomerDetails(newCustomerBalance.AccountBalance))
            {
                foreach (var item in details.Account_Details)
                {
                    item.AccountNumber = newCustomerBalance.AccountNumber;
                }
                details.Fullname = newCustomerBalance.AccountName;
                context.Balances.Add(newCustomerBalance);
                context.SaveChanges();
            }
            return newCustomerBalance;
        }

        public Balance GetAcctBalanceByAcctNum(Balance customerAcctNumber)
        {
            throw new NotImplementedException();
        }

        public Balance GetBalance(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Balance> GetBalances()
        {
            throw new NotImplementedException();
        }

        public Balance Update(Balance balance)
        {
            throw new NotImplementedException();
        }


        public bool GetCustomerDetails(double balnce)
        {
             
            
            var dep = context.Deposits.FirstOrDefault(d => d.Id == depositId);
            var withdraw = context.Withdrawals.FirstOrDefault(x => x.Id == withdrawalsId);

            
            
            dep.Amount = deposit.Amount;
            withdraw.Amount = withdrawals.Amount;

            balnce = dep.Amount - withdraw.Amount;

            return true;

        }
    }
}
