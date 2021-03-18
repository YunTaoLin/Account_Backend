using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Account_api.Models
{
    /// <summary>
    /// 會員Model
    /// </summary>
    public class MemberDTO
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Line平台ID
        /// </summary>
        public string UID { get; set; }
        /// <summary>
        /// 會員姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 每月預算
        /// </summary>
        public decimal Budget { get; set; }

        /// <summary>
        /// 創建日期
        /// </summary>
        public DateTime CreDate { get; set; }
    }
}
