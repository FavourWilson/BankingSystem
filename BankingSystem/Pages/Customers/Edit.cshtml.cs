using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Banking.Model;
using Banking.Services;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace BankingSystem.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly Banking.Services.AppDbContext _context;
        [BindProperty]
        public Account_Details AcctDetails { get; set; }
        public EditModel(Banking.Services.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer_Details Customer_Details { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Customer_Details), Encoding.UTF8, "application/json");
                using (var response = await client.GetAsync("https://localhost:44319/api/Customer/get-Customers-by-id"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Customer_Details = JsonConvert.DeserializeObject<Customer_Details>(apiResponse);
                }
            }

            if (Customer_Details == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Customer_Details), Encoding.UTF8, "application/json");
                using (var response = await client.PutAsync("https://localhost:44319/api/Customer/update-customers-by-id", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Customer_Details = JsonConvert.DeserializeObject<Customer_Details>(apiResponse);
                }
            }
            try
            {
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_DetailsExists(Customer_Details.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Customer_DetailsExists(int id)
        {
            return _context.customerDetails.Any(e => e.Id == id);
        }
    }
}
