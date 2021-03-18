using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account_api.Models.system
{
    public class ExecuteResult
    {
        /// <summary>
        /// 執行結果
        /// </summary>
        public  enum Code
        {
            /// <summary>
            /// 成功
            /// </summary>
            Y = 'Y',
            /// <summary>
            /// 失敗
            /// </summary>
            N='N'
        }
        public char Status { get; set; } = 'N';

        /// <summary>
        /// 異常訊息
        /// </summary>
        public string ErrMsg { get; set; }

        public string Token { get; set; }
    }
}
