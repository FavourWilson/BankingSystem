using Banking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
    public class AppRepository : IAccountDetails, ICustomer, IDeposit
    {
        private readonly AppDbContext context;
        public string AcctNumber;
        private string numbers;

        public AppRepository(AppDbContext context)
        {
            this.context = context;
            var defaultNumber = 123;
            Random random = new Random();
           
           numbers = random.Next(8904567).ToString();
            
            AcctNumber = String.Concat(defaultNumber, numbers);

           
        }
     

        public Customer_Details Add(Customer_Details _Details)
        {
            foreach (var item in _Details.Account_Details)
            {
                item.AccountNumber = AcctNumber;
            }

                context.customerDetails.Add(_Details);
            context.SaveChanges();
            return _Details;
        }

        public Deposit Add(Deposit newDeposit)
        {
            if (CheckAccountNumber(newDeposit.AccountNumber))
            {
            context.Deposits.Add(newDeposit);
                context.SaveChanges();
                return newDeposit;
            }
            else
            {
                return null;
            }   
        }

        public Account_Details Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Deposit DeleteDeposit(int id)
        {
            throw new NotImplementedException();
        }

        public Account_Details GetAccount(int Id)
        {
            return context.accountDetails.FirstOrDefault(n => n.Id == Id);
        }

        public IEnumerable<Account_Details> GetAccountDetails()
        {
            return context.accountDetails.ToList();
        }

        public  Account_Details GetAccountNumber(string acctNumber)
        {
            return GetAccountDetails().FirstOrDefault(n => n.AccountNumber == acctNumber);
        }

        public bool CheckAccountNumber(string acctNumber)
        {
                        
            if(GetAccountDetails().FirstOrDefault(n => n.AccountNumber == acctNumber) !=null)
            {
                return true;
            }
            else
            {
                return false;
            }
            //return context.accountDetails.FirstOrDefault(n => n.AccountNumber == acctNumber);
        }


        public Customer_Details GetCustomer(int id)
        {
           return context.customerDetails.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Customer_Details> GetCustomers()
        {
            return context.customerDetails.ToList();
        }

        public Deposit GetDeposit(int id)
        {
            return context.Deposits.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Deposit> GetDeposits()
        {
            return context.Deposits.ToList();
        }

        public Account_Details Update(Account_Details updateAccountDetails)
        {
            throw new NotImplementedException();
        }

       

        public Customer_Details Update(int custId, Customer_Details customer)
        {

            var cus = context.customerDetails.FirstOrDefault(n => n.Id == custId);
            if(cus != null)
            {
                cus.Fullname = customer.Fullname;
                cus.EmailAddress = customer.EmailAddress;
                cus.HomeAddress = customer.HomeAddress;
                cus.NextOfKin = customer.NextOfKin;
                cus.PhoneNumber = customer.PhoneNumber;
                cus.Dob = customer.Dob;


                context.customerDetails.Update(cus);
                context.SaveChanges();
                foreach (var item in customer.Account_Details)
                {
                    var AcctDetails = new Account_Details();
                    {
                        AcctDetails.AccountNumber = item.AccountNumber;
                        AcctDetails.AccountType = item.AccountType;
                    }
                    context.accountDetails.Update(AcctDetails);
                    context.SaveChanges();
                }
                
            }

            return customer;
        }

        public Deposit update(int id, Deposit updateDeposit)
        {
            var deposit = context.Deposits.FirstOrDefault(n => n.Id == id);
            if(deposit != null)
            {
                deposit.AccountNumber = updateDeposit.AccountNumber;
                deposit.Amount = updateDeposit.Amount;
                deposit.Depositor = updateDeposit.Depositor;
                deposit.DepositDate = updateDeposit.DepositDate;
                context.Deposits.Update(updateDeposit);
                context.SaveChanges();
            }
            return updateDeposit;
            
        }

        Customer_Details ICustomer.Delete(int id)
        {
            Customer_Details customers  = context.customerDetails.Find(id);
            if (customers != null)
            {
                context.customerDetails.Remove(customers);
                context.SaveChanges();
            }
            return customers;
        }
    }
}
