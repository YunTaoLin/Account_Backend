using Account_api.BLL;
using Account_api.DAL;
using Account_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        /// <summary>
        ///注入會員Service
        /// </summary>
        private MemberService MemberService { get; set; }
        public MemberController(DbContextOptions<DataContext> options)
        {
            MemberService = new MemberService(options);
        }
        [Authorize]
        [HttpGet]
        [Route("MemberList")]
        public IActionResult getMemberList()
        {
            var result = MemberService.getMemberList();
            return Ok(result);
        }
        [HttpPost]
        [Route("Member/")]
        [Authorize]
        public IActionResult Member()
        {
            var result = MemberService.getMember(User.Identity.Name);
            return Ok(result);
        }

        [HttpPost]
        [Route("createMember")]
        public IActionResult createMember(MemberDTO member)
        {
            var result = MemberService.createMember(member);
            return Ok(result);
        }

    }
}
