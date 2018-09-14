using System;
using System.Security.Cryptography;
using System.Text;

namespace CloverNet.SecurityTool
{
    public partial class SecurityTool
    {
        public static class DES
        {
            public static string Encrypt(string originalStr, string secretKey)
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(originalStr);
                    des.Key = ASCIIEncoding.ASCII.GetBytes(secretKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(secretKey);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    string str = Convert.ToBase64String(ms.ToArray());
                    ms.Close();
                    return str;
                }
            }

            public static string Decrypt(string secretStr, string secretKey)
            {
                byte[] inputByteArray = Convert.FromBase64String(secretStr);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = ASCIIEncoding.ASCII.GetBytes(secretKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(secretKey);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    string str = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                    return str;
                }
            }
        }
    }
}