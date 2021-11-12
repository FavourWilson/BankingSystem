using Banking.Model;
using System;
using System.Collections.Generic;

namespace Banking.Services
{
    public interface IAccountDetails
    {
        IEnumerable<Account_Details> GetAccountDetails();
        Account_Details GetAccount(int Id);
        Account_Details GetAccountNumber(string acctNumber);
        Account_Details Delete(int id);

    }
}
