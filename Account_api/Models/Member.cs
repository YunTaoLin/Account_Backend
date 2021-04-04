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
    public class Member
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Line平台ID
        /// </summary>
        [MaxLength(50),Required]
        public string UID { get; set; }
        /// <summary>
        /// 會員姓名
        /// </summary>
        [MaxLength(50), Required]
        public string Name { get; set; }

        /// <summary>
        /// 每月預算
        /// </summary>
        [Column(TypeName = "decimal(18,2)"), Required]
        public decimal Budget { get; set; }

        /// <summary>
        /// 創建日期
        /// </summary>
        [ Column(TypeName = "date"),Required]
        public DateTime CreDate { get; set; }
    }
}
