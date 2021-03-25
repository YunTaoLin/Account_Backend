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
    /// <summary>
    /// 會員Service
    /// </summary>
    public class MemberService
    {
        /// <summary>
        /// 載具
        /// </summary>
        private DataContext DataContext { get; set; }
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="options"></param>
        public MemberService (DbContextOptions<DataContext> options)
        {
            DataContext = new DataContext(options);
        }


        /// <summary>
        /// 取得會員列表
        /// </summary>
        /// <returns></returns>
        public List<Member> getMemberList()
        {
            var entity = DataContext.Members.ToList();
            return entity;
        }


        /// <summary>
        /// 使用ID查找單一會員
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Member getMember(string UID)
        {
            var entity = DataContext.Members.FirstOrDefault(x => x.UID == UID);
            return entity;
        }


        /// <summary>
        /// 新增一筆會員
        /// </summary>
        /// <param name="member"></param>
        public ExecuteResult createMember(MemberDTO member)
        {
            var entity = DataContext.Members.FirstOrDefault(x => x.UID == member.UID);
            if(entity == null)
            {
                try
                {
                    DataContext.Members.Add(new Member() { Id = member.Id, Budget = member.Budget, UID = member.UID, CreDate = member.CreDate, Name = member.Name });
                    DataContext.SaveChanges();
                    return new ExecuteResult() { Status = (char)Code.Y };
                }
                catch
                {
                    return new ExecuteResult() { Status = (char)Code.N, ErrMsg= "資料異常" };
                 }
            }
            else
            {
                return new ExecuteResult() { ErrMsg= "此帳號已被註冊過", Status = (char)Code.N };
            }
        }
        /// <summary>
        /// 更新會員資料/預算
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public ExecuteResult updateMember(MemberDTO member)
        {
            var entity = DataContext.Members.FirstOrDefault(x => x.Id == member.Id);
            try
            {
                entity.Budget = member.Budget;
                entity.UID = member.UID;
                entity.Name = member.Name;
                DataContext.SaveChanges();
                return new ExecuteResult() { Status = (char)Code.Y };
            }
            catch
            {
                return new ExecuteResult() { Status = (char)Code.N, ErrMsg="更新失敗" };
            }
        }

        public ExecuteResult deleteMember(Member member)
        {
            var entity = DataContext.Members.FirstOrDefault(x => x.Id == member.Id);
            if(entity != null)
            {
                DataContext.Members.Remove(entity);
                DataContext.SaveChanges();
                return new ExecuteResult() { Status = (char)Code.Y };
            }
            else
            {
                return new ExecuteResult() { Status = (char)Code.N , ErrMsg="找無此會員" };
            }
        }


    }
}
