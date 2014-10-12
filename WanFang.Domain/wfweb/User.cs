using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface IUser_Info
    {
        int UserID { get; set; }
        string UserName { get; set; }
        string LoginId { get; set; }
        string Password { get; set; }
        int PermissionType { get; set; }
        string DeptType { get; set; }
        string CostName { get; set; }
        string CostCode { get; set; }
        string Permission { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_User")]
    [Rest.Core.PetaPoco.PrimaryKey("UserID")]
    public class User_Info //: IUser_Info
    {
        #region private fields
        /// <summary>
        /// 使用者ID
        /// </summary>
        public int UserID { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// 登入帳號
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 科別
        /// </summary>
        public int PermissionType { get; set; }
        /// <summary>
        /// 診別
        /// </summary>
        public string DeptType { get; set; }
        /// <summary>
        /// 權限
        /// </summary>
        public string CostName { get; set; }
        /// <summary>
        /// 最後更新日期
        /// </summary>
        public string CostCode { get; set; }
        /// <summary>
        /// 密鑰
        /// </summary>
        public string Permission { get; set; }
        /// <summary>
        /// 最後更新日期
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public User_Info()
        {
        }
        #endregion
    }

    public class User_Filter
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int? PermissionType { get; set; }
        public string DeptType { get; set; }
        public string CostName { get; set; }
        public string CostCode { get; set; }
        public string Permission { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above User_Info field for search criteria
    }
    #endregion
}