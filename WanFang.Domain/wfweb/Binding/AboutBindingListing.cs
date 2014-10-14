using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    public class AboutBindingListing : AboutContent_Info
    {
        /// <summary>
        /// 關於萬芳-類別名稱
        /// </summary>
        public int AboutName { get; set; }
        /// <summary>
        /// 關於萬芳-系列名稱
        /// </summary>
        public int AboutCategoryName { get; set; }
    }
}