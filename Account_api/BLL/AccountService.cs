using Account_api.DAL;
using Account_api.Models;
using Account_api.Models.system;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Account_api.Models.system.ExecuteResult;

namespace Account_api.BLL
{
    public class AccountService
    {
        private DataContext DataContext { get; set; }
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="options"></param>
        public AccountService(DbContextOptions<DataContext> options)
        {
            DataContext = new DataContext(options);
        }

        /// <summary>
        /// 新增一筆帳務
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public ExecuteResult AddAccount(string UID,AccountDTO account)
        {
            var member = DataContext.Members.FirstOrDefault(x => x.UID == UID);
            if(member != null)
            {
                try
                {
                    DataContext.Accounts.Add(new Account()
                    {
                        MemberId = member.Id,
                        Date = account.Date,
                        Price = account.Price,
                        Classify = account.Classify,
                        Type = account.Type
                    });
                    DataContext.SaveChanges();
                    return new ExecuteResult() { Status = (char)Code.Y };
                }
                catch
                {
                    return new ExecuteResult() { ErrMsg = "新增失敗", Status = (char)Code.N };
                }
             }
            else
            {
                return new ExecuteResult() { ErrMsg = "找無此會員", Status = (char)Code.N };
            }
        }
   
        /// <summary>
        /// /回傳該Member帳務
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<Account> GetAccounts(string UID,AccountDTO account)
        {
            var member = DataContext.Members.FirstOrDefault(x => x.UID == UID);
            if (member != null && account.StartDate != null && account.EndDate != null)
            {
                var entity = DataContext.Accounts
              .Where(x => x.MemberId == member.Id && x.Date >= account.StartDate && x.Date <= account.EndDate)
              .ToList();
                return entity;
            }
            else if(member != null)
            {
                var entity = DataContext.Accounts
                 .Where(x => x.MemberId == member.Id)
                 .ToList();
                    return entity;
            }
            else
            {
                return new List<Account>();
            }
        }

        /// <summary>
        /// 刪除一筆帳務
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public ExecuteResult DeteleAccount(string UID, int Id)
        {
            var member = DataContext.Members.FirstOrDefault(x => x.UID == UID);
            if (member != null)
            {
                try
                {
                    var target = DataContext.Accounts.FirstOrDefault(x => x.Id == Id);
                    DataContext.Accounts.Remove(target);
                    DataContext.SaveChanges();
                    return new ExecuteResult() { Status = (char)Code.Y };
                }
                catch
                {
                    return new ExecuteResult() { ErrMsg = "新增失敗", Status = (char)Code.N };
                }
            }
            else
            {
                return new ExecuteResult() { ErrMsg = "找無此會員", Status = (char)Code.N };
            }
        }
    }
}
