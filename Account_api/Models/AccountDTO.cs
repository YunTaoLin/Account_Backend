using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account_api.Models
{
    public class AccountDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 型態(1:收入，2:支出)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 金額(正數)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        public string Classify { get; set; }

        /// <summary>
        /// 消費/入帳日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 查詢用開始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 查詢用結束日期
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
