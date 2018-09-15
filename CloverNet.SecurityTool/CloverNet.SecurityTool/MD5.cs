using System.Security.Cryptography;
using System.Text;

namespace CloverNet.SecurityTool
{
    public partial class SecurityTool
    {
        public static class MD5
        {
            public static string Encrypt(string originalStr)
            {
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
                byte[] hashedDataBytes;
                hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(originalStr));
                StringBuilder byte2String = new StringBuilder();
                foreach (byte i in hashedDataBytes)
                {
                    byte2String.Append(i.ToString("x2"));
                }
                return byte2String.ToString();
            }
        }
    }

}