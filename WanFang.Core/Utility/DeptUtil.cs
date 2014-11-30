using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanFang.Domain.Constancy;
using Rest.Core.Utility;

namespace WanFang.Core.Utility
{
    public class DeptUtil
    {
        private static Dictionary<string, string> _AllDept;
        public static Dictionary<string, string> GetDept()
        {
            if (_AllDept == null || _AllDept.Count == 0)
            {
                Dictionary<string, string> rtn = new Dictionary<string, string>() { };
                foreach (WS_Dept_type item in (WS_Dept_type[])Enum.GetValues(typeof(WS_Dept_type)))
                {
                    rtn.Add(item.ToString(), EnumHelper.GetEnumDescription<WS_Dept_type>(item));
                }
                rtn = rtn.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                _AllDept = rtn;
            }
            return _AllDept;
        }
    }
}
