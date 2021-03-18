using Account_api.BLL;
using Account_api.DAL;
using Account_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Account_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountService AccountService { get; set; }
        public AccountController(DbContextOptions<DataContext> options)
        {
            AccountService = new AccountService(options);
        }
        [Authorize]
        [HttpPost("addAccount")]
        public IActionResult addAccount(AccountDTO account)
        {
            var result = AccountService.AddAccount(User.Identity.Name, account);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("AccountList")]
        public IActionResult AccountList(AccountDTO account)
        {
            var result = AccountService.GetAccounts(User.Identity.Name,account);
            return Ok(result);
        }
    }
}
