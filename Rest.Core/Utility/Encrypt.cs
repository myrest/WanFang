using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rest.Core.Utility
{
    public class Encrypt
    {
        public static string RandomStr(int length)
        {
            var Words = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%^&=+\|<>?,/[]{}:;'`~".ToCharArray();
            var lenght = Words.Count();
            Random random = new Random((int)DateTime.Now.Ticks);
            string result = string.Empty;
            for (int i = 0; i < length; i++)
            {
                result += Words[random.Next(lenght)];
            }
            return result;
        }

        public static string EncryptPassword(string password, string salt)
        {
            if (salt == null) return password;
            SHA256 algorithm = SHA256Managed.Create();
            StringBuilder passwordBuilder = new StringBuilder();
            char[] param1 = password.ToCharArray();
            char[] param2 = salt.ToCharArray();
            for (int i = 0; i < Math.Min(param1.Length, param2.Length); i++)
            {
                passwordBuilder.Append(param1[i]);
                passwordBuilder.Append(param2[i]);
            }
            if (param1.Length < param2.Length)
            {
                for (int i = param1.Length; i < param2.Length; i++)
                    passwordBuilder.Append(param2[i]);
            }
            if (param2.Length < param1.Length)
            {
                for (int i = param2.Length; i < param1.Length; i++)
                    passwordBuilder.Append(param1[i]);
            }
            byte[] data = Encoding.UTF8.GetBytes(passwordBuilder.ToString());
            byte[] encrypted = algorithm.ComputeHash(data);
            return Convert.ToBase64String(encrypted);
        }

        public static string EncryptTeamGroupSN(int TeamGroupSN)
        {
            if (TeamGroupSN == 0)
            {
                return "";
            }
            else
            {
                string org = string.Format("SN={0}", TeamGroupSN);
                SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256
                byte[] source = Encoding.Default.GetBytes(org);//將字串轉為Byte[]
                byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
                string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
                result = result.Replace("+", "");
                result = result.Replace("=", "");
                result = result.Replace("/", "");
                string left = result.Substring(0, 3);
                string right = result.Substring(3, 4);
                return string.Format("{0}{1}-{2}", left, TeamGroupSN, right).ToUpper();
            }
        }

        public static int GetEncryptTeamGropuSN(string EncryCode)
        {
            if (!string.IsNullOrEmpty(EncryCode) && EncryCode.Length == 9 && EncryCode.IndexOf('-') > 0)
            {
                string left = EncryCode.Substring(0, 3);
                string right = EncryCode.Split(new char[] { '-' }, 2)[1];
                string num = EncryCode.Substring(3, EncryCode.IndexOf('-') - 3);

                string conf = EncryptTeamGroupSN(Convert.ToInt32(num));
                if (EncryCode == conf)
                {
                    return Convert.ToInt32(num);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}