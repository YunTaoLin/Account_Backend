using Account_api.DAL;
using Account_api.Models.system;
using Account_api.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Account_api.Models.system.ExecuteResult;

namespace Account_api.BLL
{
    public class AuthService
    {
        private DataContext DataContext { get; set; }
        private readonly IConfiguration _config;
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="options"></param>
        public AuthService(IConfiguration configuration, DbContextOptions<DataContext> options)
        {
            DataContext = new DataContext(options);
            _config = configuration;
        }

        public ExecuteResult Login(string UID)
        {
            var member = DataContext.Members.FirstOrDefault(x => x.UID == UID);
            if (member != null)
            {
                //取得Token
                string Token = JwtTools.getToken(UID, _config["Jwt:Key"], _config["Jwt:Issuer"]);
                return new ExecuteResult() { Token = Token, Status = (char)Code.Y };
            }
            else
            {
                return new ExecuteResult() { ErrMsg = "未註冊", Status = (char)Code.N  };
            }
        }
    }
}
