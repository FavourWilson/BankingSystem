using Banking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public interface IDeposit
    {
        IEnumerable<Deposit> GetDeposits();
        Deposit Add(Deposit newDeposit);
        Deposit update(int id, Deposit updateDeposit);
        Deposit GetDeposit(int id);
        Deposit DeleteDeposit(int id);
    }
}
