using Banking.Model;
using Banking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer customer;

        public CustomerController(ICustomer customer)
        {
            this.customer = customer;
        }

        [HttpPost("add-Customers")]
        public IActionResult AddCustomers([FromBody] Customer_Details details)
        {
            customer.Add(details);
            return Ok();
        }

        [HttpGet("get-Customers-by-id")]
        public IActionResult GetCustomerById(int id)
        {
            var cus = customer.GetCustomer(id);
            return Ok(cus);
        }

        [HttpPut("update-customers-by-id")]
        public IActionResult updateCustomerDetails(int customerid, [FromBody] Customer_Details details)
        {
            var cus = customer.Update(customerid,details);
            return Ok(cus);
        }

        [HttpGet("get-AllCustomers")]
        public IActionResult GetAllCustomers()
        {
            var allCus = customer.GetCustomers();
            return Ok(allCus);
        }
    }
}
