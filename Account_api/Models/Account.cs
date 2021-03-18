using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Account_api.Models
{
    /// <summary>
    /// 帳務列表
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 資料ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 所屬會員ID
        /// </summary>
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        /// <summary>
        /// 型態("01":收入，"02":支出)
        /// </summary>
        [MaxLength(2), Column(TypeName = "varchar"), Required]
        public string Type { get; set; }

        /// <summary>
        /// 金額(正數)
        /// </summary>
        [Column(TypeName = "decimal"), Required]
        public decimal Price { get; set; }

        /// <summary>
        /// 類別
        /// </summary>
        [MaxLength(10), Column(TypeName = "nvarchar"), Required]
        public string Classify { get; set; }

        /// <summary>
        /// 消費/入帳日期
        /// </summary>
        [Column(TypeName = "date"),Required]
        public DateTime Date { get; set; }
    }
}
