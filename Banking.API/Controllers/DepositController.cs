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
    public class DepositController : ControllerBase
    {
        private readonly IDeposit deposit;

        public DepositController(IDeposit deposit)
        {
            this.deposit = deposit;
        }

        [HttpPost("add-Deposit")]
        public IActionResult AddDeposit([FromBody] Deposit deposits)
        {
            deposit.Add(deposits);
            return Ok();
        }

        [HttpGet("getDeposits-by-Id")]
        public IActionResult GetDepositById(int Depositid)
        {
            var dep = deposit.GetDeposit(Depositid);
            return Ok(dep);
        }

        [HttpPut("Update-Deposits")]
        public IActionResult UpdateDeposit(int id, [FromBody] Deposit deposits)
        {
            var dep = deposit.update(id, deposits);
            return Ok(dep);
        }
        [HttpGet("get-AllDeposit")]
        public IActionResult GetAllDeposits()
        {
            var deps = deposit.GetDeposits();
            return Ok(deps);
        }
    }
}
