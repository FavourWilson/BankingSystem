using Banking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public interface IBalance
    {
        IEnumerable<Balance> GetBalances();
        Balance Add(Balance newCustomerBalance);
        Balance Update(Balance balance);
        Balance GetAcctBalanceByAcctNum(Balance customerAcctNumber);
        Balance GetBalance(int id);

    }
}
