using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface ILogLogin_Info
    {
        int LogLoginId { get; set; }
        string LoginId { get; set; }
        string Password { get; set; }
        int IsPass { get; set; }
        DateTime CreateDateTime { get; set; }
        string LoginIP { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_LogLogin")]
    [Rest.Core.PetaPoco.PrimaryKey("LogLoginId")]
    public class LogLogin_Info //: ILogLogin_Info
    {
        #region private fields
        public int LogLoginId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int IsPass { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string LoginIP { get; set; }
        #endregion

        #region Constructor
        public LogLogin_Info()
        {
        }
        #endregion
    }

    public class LogLogin_Filter
    {
        public int? LogLoginId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int? IsPass { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public string LoginIP { get; set; }
        //You can copy/modify above LogLogin_Info field for search criteria
    }
    #endregion
}