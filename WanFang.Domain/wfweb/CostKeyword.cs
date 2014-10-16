using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface ICostKeyword_Info
    {
        int CostKeywordId { get; set; }
        string Cost { get; set; }
        string Dept { get; set; }
        string KeyWord { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_CostKeyword")]
    [Rest.Core.PetaPoco.PrimaryKey("CostKeywordId")]
    public class CostKeyword_Info //: ICostKeyword_Info
    {
        #region private fields
        public int CostKeywordId { get; set; }
        public string Cost { get; set; }
        public string Dept { get; set; }
        public string KeyWord { get; set; }
        public int IsActive { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public CostKeyword_Info()
        {
        }
        #endregion
    }

    public class CostKeyword_Filter
    {
        public int? CostKeywordId { get; set; }
        public string Cost { get; set; }
        public string Dept { get; set; }
        public string KeyWord { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above CostKeyword_Info field for search criteria
    }
    #endregion
}