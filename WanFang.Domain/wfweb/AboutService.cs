using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IAboutService_Info
    {
        int AboutServiceId { get; set; }
        int SortNum { get; set; }
        string Description { get; set; }
        int DisplayType { get; set; }
        string Link { get; set; }
        string ContentBody1 { get; set; }
        string ContentBody2 { get; set; }
        string ContentBody3 { get; set; }
        string Image1 { get; set; }
        string Image2 { get; set; }
        string Image3 { get; set; }
        int Position1 { get; set; }
        int Position2 { get; set; }
        int Position3 { get; set; }
        int IsActive { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_AboutService")]
    [Rest.Core.PetaPoco.PrimaryKey("AboutServiceId")]
    public class AboutService_Info //: IAboutService_Info
    {
        #region private fields
        public int AboutServiceId { get; set; }
        /// <summary>
        /// 順序(新)
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 系列名稱(新)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 上/下架(新)
        /// </summary>
        public int DisplayType { get; set; }
        /// <summary>
        /// 更新日期(新)
        /// </summary>
        public string Link { get; set; }
        public string ContentBody1 { get; set; }
        public string ContentBody2 { get; set; }
        public string ContentBody3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Position1 { get; set; }
        public int Position2 { get; set; }
        public int Position3 { get; set; }
        /// <summary>
        /// 上/下架(新)
        /// </summary>
        public int IsActive { get; set; }
        /// <summary>
        /// 更新日期(新)
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public AboutService_Info()
        {
        }
        #endregion
    }

    public class AboutService_Filter
    {
        public int? AboutServiceId { get; set; }
        public int? SortNum { get; set; }
        public string Description { get; set; }
        public int? DisplayType { get; set; }
        public string Link { get; set; }
        public string ContentBody1 { get; set; }
        public string ContentBody2 { get; set; }
        public string ContentBody3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int? Position1 { get; set; }
        public int? Position2 { get; set; }
        public int? Position3 { get; set; }
        public int? IsActive { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above AboutService_Info field for search criteria
    }
    #endregion
}