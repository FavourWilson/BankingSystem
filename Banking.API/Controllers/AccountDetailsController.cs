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
    public class AccountDetailsController : ControllerBase
    {
        private readonly IAccountDetails accountDetails;

       
        public AccountDetailsController(IAccountDetails accountDetails)
        {
            this.accountDetails = accountDetails;
        }

        [HttpGet("get-Customeraccount-id")]
        public IActionResult AddAccountDetails(int ID)
        {
            accountDetails.GetAccount(ID);
            return Ok();
        }
    }
}
