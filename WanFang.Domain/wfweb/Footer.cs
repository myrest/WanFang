using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IFooter_Info
    {
        int FooterId { get; set; }
        string FooterText { get; set; }
        string FooterTextMail { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Footer")]
    [Rest.Core.PetaPoco.PrimaryKey("FooterId")]
    public class Footer_Info //: IFooter_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int FooterId { get; set; }
        /// <summary>
        /// 表尾資料(表尾資料管理)
        /// </summary>
        public string FooterText { get; set; }
        public string FooterTextMail { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public Footer_Info()
        {
        }
        #endregion
    }

    public class Footer_Filter
    {
        public int? FooterId { get; set; }
        public string FooterText { get; set; }
        public string FooterTextMail { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above Footer_Info field for search criteria
    }
    #endregion
}