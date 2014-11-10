using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface INhi_Qa_Info
    {
        int Nhi_QaId { get; set; }
        string nhi_title { get; set; }
        string Description { get; set; }
        string nhi_con { get; set; }
        DateTime nhi_date { get; set; }
        int hit { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Nhi_Qa")]
    [Rest.Core.PetaPoco.PrimaryKey("Nhi_QaId")]
    public class Nhi_Qa_Info //: INhi_Qa_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int Nhi_QaId { get; set; }
        /// <summary>
        ///  問題標題
        /// </summary>
        public string nhi_title { get; set; }
        /// <summary>
        /// 清單頁簡述(新)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 回覆內容
        /// </summary>
        public string nhi_con { get; set; }
        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime nhi_date { get; set; }
        /// <summary>
        /// 點閱數
        /// </summary>
        public int hit { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public Nhi_Qa_Info()
        {
        }
        #endregion
    }

    public class Nhi_Qa_Filter
    {
        public int? Nhi_QaId { get; set; }
        public string nhi_title { get; set; }
        public string Description { get; set; }
        public string nhi_con { get; set; }
        public DateTime? nhi_date { get; set; }
        public int? hit { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above Nhi_Qa_Info field for search criteria
    }
    #endregion
}