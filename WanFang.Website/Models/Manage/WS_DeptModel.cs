using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Rest.Core.Utility;
using WanFang.Domain.Webservice;

namespace WanFang.Website.Models
{
    [DataContract]
    public class WS_DeptModel : ResultBase
    {
        [DataMember(Name = "list")]
        public List<CostDetailInformation> DeptList { get; set; }
    }
}