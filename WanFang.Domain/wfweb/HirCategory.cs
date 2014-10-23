using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IHirCategory_Info
    {
        int HirCategoryId { get; set; }
        int SortNum { get; set; }
        string CategoryName { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_HirCategory")]
    [Rest.Core.PetaPoco.PrimaryKey("HirCategoryId")]
    public class HirCategory_Info //: IHirCategory_Info
    {
        #region private fields
        public int HirCategoryId { get; set; }
        public int SortNum { get; set; }
        public string CategoryName { get; set; }
        public int IsActive { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public HirCategory_Info()
        {
        }
        #endregion
    }

    public class HirCategory_Filter
    {
        public int? HirCategoryId { get; set; }
        public int? SortNum { get; set; }
        public string CategoryName { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above HirCategory_Info field for search criteria
    }
    #endregion
}