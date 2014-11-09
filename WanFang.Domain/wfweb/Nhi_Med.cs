using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WanFang.Domain
{
    /*
    #region interface
    public interface INhi_Med_Info
    {
        int MedicationID { get; set; }
        int SortNum { get; set; }
        DateTime PublishDate { get; set; }
        string CodeOld { get; set; }
        string PCodeOld { get; set; }
        string PNameEngOld { get; set; }
        string PNameOld { get; set; }
        string PNameAndNumOld { get; set; }
        string ScientificNameOld { get; set; }
        string CompanyNameOld { get; set; }
        string ImageOld { get; set; }
        string SuitOld { get; set; }
        string UsageOld { get; set; }
        string SideEffectOld { get; set; }
        string NotificationOld { get; set; }
        string ModifiedContent { get; set; }
        int HitOld { get; set; }
        string Code { get; set; }
        string PCode { get; set; }
        string PNameEng { get; set; }
        string ScientificName { get; set; }
        string PName { get; set; }
        string PNameAndNum { get; set; }
        string CompanyName { get; set; }
        string Image { get; set; }
        string Suit { get; set; }
        string Usage { get; set; }
        string SideEffect { get; set; }
        string Notification { get; set; }
        DateTime LastUpdate { get; set; }
        string LastUpdator { get; set; }
    }
    #endregion
    */

    #region Implementation
    [Rest.Core.PetaPoco.TableName("db_Nhi_Med")]
    [Rest.Core.PetaPoco.PrimaryKey("MedicationID")]
    public class Nhi_Med_Info //: INhi_Med_Info
    {
        #region private fields
        /// <summary>
        /// 流水號
        /// </summary>
        public int MedicationID { get; set; }
        /// <summary>
        /// 順序
        /// </summary>
        public int SortNum { get; set; }
        /// <summary>
        /// 發佈日期
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 健保代號(舊)
        /// </summary>
        public string CodeOld { get; set; }
        /// <summary>
        /// 院內碼(舊)
        /// </summary>
        public string PCodeOld { get; set; }
        /// <summary>
        /// 商品名/含量(原英文品名舊)
        /// </summary>
        public string PNameEngOld { get; set; }
        /// <summary>
        /// 中文品名(舊)
        /// </summary>
        public string PNameOld { get; set; }
        /// <summary>
        /// 商品名/含量_舊
        /// </summary>
        public string PNameAndNumOld { get; set; }
        /// <summary>
        /// 學品名(舊)
        /// </summary>
        public string ScientificNameOld { get; set; }
        /// <summary>
        /// 藥商名稱(舊)
        /// </summary>
        public string CompanyNameOld { get; set; }
        /// <summary>
        /// 圖片上傳(舊)
        /// </summary>
        public string ImageOld { get; set; }
        /// <summary>
        /// 適應症(舊)
        /// </summary>
        public string SuitOld { get; set; }
        /// <summary>
        /// 用法用量(舊)
        /// </summary>
        public string UsageOld { get; set; }
        /// <summary>
        /// 副作用(舊)
        /// </summary>
        public string SideEffectOld { get; set; }
        /// <summary>
        /// 禁忌及其他注意事項(舊)
        /// </summary>
        public string NotificationOld { get; set; }
        /// <summary>
        /// 異動內容
        /// </summary>
        public string ModifiedContent { get; set; }
        /// <summary>
        /// 點閱數(舊系統保留)
        /// </summary>
        public int HitOld { get; set; }
        /// <summary>
        /// 新健保代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 新院內碼
        /// </summary>
        public string PCode { get; set; }
        /// <summary>
        /// 新商品名/含量(原英文品名新)
        /// </summary>
        public string PNameEng { get; set; }
        /// <summary>
        /// 新學品名
        /// </summary>
        public string ScientificName { get; set; }
        /// <summary>
        /// 新中文品名
        /// </summary>
        public string PName { get; set; }
        /// <summary>
        /// 商品名/含量_舊
        /// </summary>
        public string PNameAndNum { get; set; }
        /// <summary>
        /// 新藥商名稱
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 新圖片上傳
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 新適應症
        /// </summary>
        public string Suit { get; set; }
        /// <summary>
        /// 新用法用量
        /// </summary>
        public string Usage { get; set; }
        /// <summary>
        /// 新副作用
        /// </summary>
        public string SideEffect { get; set; }
        /// <summary>
        /// 禁忌及其他注意事項(新)
        /// </summary>
        public string Notification { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        #endregion

        #region Constructor
        public Nhi_Med_Info()
        {
        }
        #endregion
    }

    public class Nhi_Med_Filter
    {
        public int? MedicationID { get; set; }
        public int? SortNum { get; set; }
        public DateTime? PublishDate { get; set; }
        public string CodeOld { get; set; }
        public string PCodeOld { get; set; }
        public string PNameEngOld { get; set; }
        public string PNameOld { get; set; }
        public string PNameAndNumOld { get; set; }
        public string ScientificNameOld { get; set; }
        public string CompanyNameOld { get; set; }
        public string ImageOld { get; set; }
        public string SuitOld { get; set; }
        public string UsageOld { get; set; }
        public string SideEffectOld { get; set; }
        public string NotificationOld { get; set; }
        public string ModifiedContent { get; set; }
        public int? HitOld { get; set; }
        public string Code { get; set; }
        public string PCode { get; set; }
        public string PNameEng { get; set; }
        public string ScientificName { get; set; }
        public string PName { get; set; }
        public string PNameAndNum { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; }
        public string Suit { get; set; }
        public string Usage { get; set; }
        public string SideEffect { get; set; }
        public string Notification { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdator { get; set; }
        //You can copy/modify above Nhi_Med_Info field for search criteria
    }
    #endregion
}