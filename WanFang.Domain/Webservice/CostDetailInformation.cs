using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanFang.Domain.Constancy;

namespace WanFang.Domain.Webservice
{
    public class CostDetailInformation : CostInformation
    {
        public string Sick { get; set; }
        public string ECostDesc { get; set; }
        public string ESick { get; set; }
        /// <summary>
        /// 專科分類
        /// </summary>
        public WS_Dept_type DeptType { get; set; }
        /// <summary>
        /// 開放網路掛號
        /// </summary>
        public WS_Opd_flag OpdFlag { get; set; }
        public string WebFlag { get; set; }
    }
}
