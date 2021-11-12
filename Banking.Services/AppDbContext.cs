using Banking.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Services
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Account_Details> accountDetails { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Customer_Details>  customerDetails { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Transactions>  Transactions { get; set; }

        public DbSet<Withdrawals>  Withdrawals { get; set; }
    }
}
