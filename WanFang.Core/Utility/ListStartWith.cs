using System.Linq;

namespace WanFang.Core.Utility
{
    public class ListStartWith
    {
        public static bool HasAlias(string source, string finding)
        {
            string rtn = source.Split(new char[1] { ',' }).ToList().Where(x => x.Trim().ToLower().StartsWith(finding)).FirstOrDefault();
            return (!string.IsNullOrEmpty(rtn));
        }
    }
}