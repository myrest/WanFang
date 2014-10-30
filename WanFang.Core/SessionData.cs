using System;
using System.Linq;
using System.Web;
using WanFang.Core.Constancy;
using WanFang.Domain.Constancy;
using System.Collections.Generic;

namespace WanFang.Core
{
    public class SessionData
    {
        public static readonly string TradingSessionKey = SessionKeys.Trading.ToString();

        public Trading trading
        {
            get
            {
                return (Trading)HttpContext.Current.Session[TradingSessionKey];
            }
            set
            {
                HttpContext.Current.Session[TradingSessionKey] = value;
            }
        }

        public void Logout()
        {
            Trading ordTrading = (Trading)HttpContext.Current.Session[TradingSessionKey];
            Trading newTrading = new Trading();
            this.trading = newTrading;
        }

        public void ClearALL()
        {
            this.trading = null;
            HttpContext.Current.Session.Clear();
        }
    }

    [Serializable]
    public class Trading
    {
        public Trading()
        {
            LoginId = default(string);
            UserID = 0;
        }

        public string LoginId { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public bool IsDeptOnly { get; set; }

        public WS_Dept_type? Dept { get; set; }

        public Dictionary<string, string> UploadFiles { get; set; }

        public List<string> Permissions { get; set; }

    }
}