using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain.Webservice
{
    /// <summary>
    /// 回傳部門資訊
    /// </summary>
    public class CostInformation
    {
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string CostCode { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string CostName { get; set; }
    }
}