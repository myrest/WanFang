using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Rest.Core.Utility;

namespace WanFang.Website.Models
{
    [DataContract]
    public class UploadFileResult : ResultBase
    {
        [DataMember(Name = "fn")]
        public string FileName { get; set; }

        [DataMember(Name = "ft")]
        public string FileType { get; set; }

        [DataMember(Name = "fs")]
        public string FileSize { get; set; }

        [DataMember(Name = "tmpfn")]
        public string TempFileName { get; set; }

        [DataMember(Name = "isimg")]
        public bool IsImage { get; set; }
    }
}