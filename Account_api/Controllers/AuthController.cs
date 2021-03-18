using Account_api.BLL;
using Account_api.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Account_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthService AuthService { get; set; }
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="options"></param>
        public AuthController( IConfiguration configuration, DbContextOptions<DataContext> options)
        {
            AuthService = new AuthService(configuration,options);
        }

        // GET api/auth/login
        [HttpGet, Route("login")]
        public IActionResult Login(string UID)
        {
            if(UID != null)
            {
                var result = AuthService.Login(UID);
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
