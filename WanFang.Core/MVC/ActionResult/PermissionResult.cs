using System.Runtime.Serialization;

namespace WanFang.Core.MVC
{
    [DataContract]
    public class RejectResult
    {
        [DataMember(Name = "sysCode")]
        public RejectReason Reason { get; private set; }

        [DataMember(Name = "rd")]
        public string RedirectTo { get; private set; }

        public RejectResult(RejectReason reason, string redirectto)
        {
            Reason = reason;
            RedirectTo = redirectto;
        }
    }

    public enum RejectReason
    {
        UnKnown = 0,
        SessionLost = 100,
        SsoKickOut = 200,
        ServerError = 300,
        PermissionDeny = 400
    }
}