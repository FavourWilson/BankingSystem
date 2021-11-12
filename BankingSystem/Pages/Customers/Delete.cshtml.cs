using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Banking.Model;
using Banking.Services;

namespace BankingSystem.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly Banking.Services.AppDbContext _context;

        public DeleteModel(Banking.Services.AppDbContext context)
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

            Customer_Details = await _context.customerDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (Customer_Details == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer_Details = await _context.customerDetails.FindAsync(id);

            if (Customer_Details != null)
            {
                _context.customerDetails.Remove(Customer_Details);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
