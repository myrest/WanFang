using System.Runtime.Serialization;

namespace WanFang.Core.BLLModel
{
    [DataContract]
    public class KeyValue
    {
        [DataMember(Name = "k")]
        public string Key { get; set; }

        [DataMember(Name = "v")]
        public string Value { get; set; }
    }
}