 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Banking.Model;
using Banking.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace BankingSystem.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Banking.Services.AppDbContext _context;
        private readonly ICustomer customer;

        public IndexModel(ICustomer customer)
        {
           
            this.customer = customer;
        }
        [BindProperty]
        public List<Customer_Details> Customer_Details { get;set; }
        public ICustomer Customer { get; }
        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Customer_Details), Encoding.UTF8, "application/json");
                using (var response = await client.GetAsync("https://localhost:44319/api/Customer/get-AllCustomers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Customer_Details = JsonConvert.DeserializeObject<List<Customer_Details>>(apiResponse);
                }
            }

        }
    }
}
