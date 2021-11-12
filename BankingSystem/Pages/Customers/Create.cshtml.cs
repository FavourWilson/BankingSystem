using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Banking.Model;
using Banking.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using BankingSystem.Helpers;

namespace BankingSystem.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly Banking.Services.AppDbContext _context;
        
        public CreateModel(Banking.Services.AppDbContext context,ICustomer customer)
        {
            _context = context;
            Customer = customer;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer_Details Customers{ get; set; }

        [BindProperty]
        public Account_Details AcctDetails { get; set; }
        public ICustomer Customer { get; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Customers), Encoding.UTF8, "application/json");
                using(var response = await client.PostAsync("https://localhost:44319/api/Customer/add-Customers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Customers = JsonConvert.DeserializeObject<Customer_Details>(apiResponse);
                }
            }
             
            return RedirectToPage("./Index");
        }
    }
}
