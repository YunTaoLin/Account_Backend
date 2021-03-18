using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Account_api.Models
{
    public class Event
    {
        /// <summary>
        /// 活動ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 活動標題
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 活動連結
        /// </summary>
        [Required]
        public string Link { get; set; }
        /// <summary>
        /// 活動描述
        /// </summary>
        public string Des { get; set; }

        /// <summary>
        /// 圖片連結
        /// </summary>
        [Required]
        public string Image { get; set; }
    }
}
