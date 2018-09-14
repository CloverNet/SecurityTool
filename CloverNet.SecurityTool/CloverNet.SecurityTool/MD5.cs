using System.Security.Cryptography;

namespace CloverNet.SecurityTool
{
    public partial class SecurityTool
    {
        public static class MD5
        {
            public static string Encrypt(string originalStr)
            {
                System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fromData = System.Text.Encoding.Unicode.GetBytes(originalStr);
                byte[] targetData = md5.ComputeHash(fromData);
                string byte2String = null;

                for (int i = 0; i < targetData.Length; i++)
                {
                    byte2String += targetData[i].ToString("x");
                }

                return byte2String;
            }
        }
    }

}