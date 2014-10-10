using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WanFang.BLL.WanfangWebService;
using System.Data;
using WanFang.Domain.Webservice;
using WanFang.Domain.Constancy;
using Rest.Core.Utility;

namespace WanFang.BLL
{
    public class WebService_Manage
    {
        private ServiceSoapClient Soap = new ServiceSoapClient();

        /// <summary>
        /// 傳部門資訊
        /// </summary>
        /// <returns></returns>
        public List<CostInformation> GetALLCostcerter()
        {
            var data = Soap.Costcenter();
            if (data.Rows != null && data.Rows.Count > 0)
            {
                List<CostInformation> rtn = new List<CostInformation>() { };
                foreach (DataRow item in data.Rows)
                {
                    rtn.Add(new CostInformation()
                    {
                        CostCode = item["costcode"].ToString(),
                        CostName = item["costdesc"].ToString()
                    });
                }
                return rtn;
            }
            else
            {
                return null;
            }
        }

        public List<CostDetailInformation> GetAllDetailCostcerter(WS_Dept_type type)
        {
            var data = Soap.web_cost_basic(type.ToString());
            if (data.Rows != null && data.Rows.Count > 0)
            {
                List<CostDetailInformation> rtn = new List<CostDetailInformation>() { };
                foreach (DataRow item in data.Rows)
                {
                    rtn.Add(new CostDetailInformation()
                    {
                        CostCode = item["costcode"].ToString(),
                        CostName = item["costdesc"].ToString(),
                        Sick = item["sick"].ToString(),
                        ECostDesc = item["ecostdesc"].ToString(),
                        ESick = item["esick"].ToString(),
                        DeptType = EnumHelper.GetEnumByName<WS_Dept_type>(item["dept_type"].ToString()),
                        OpdFlag = EnumHelper.GetEnumByName<WS_Opd_flag>(item["opd_flag"].ToString()),
                        WebFlag = item["web_flag"].ToString()
                    });
                }
                return rtn;
            }
            else
            {
                return null;
            }

        }
    }
}
