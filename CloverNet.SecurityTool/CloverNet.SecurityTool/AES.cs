using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CloverNet.SecurityTool
{
    public partial class SecurityTool
    {
        public static class AES
        {
            //默认密钥向量   
            private static byte[] _key1 = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            public static string Encrypt(string originalStr, string secretKey)
            {
                //分组加密算法  
                SymmetricAlgorithm des = Rijndael.Create();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(originalStr);//得到需要加密的字节数组      
                                                                          //设置密钥及密钥向量  
                des.Key = Encoding.UTF8.GetBytes(secretKey);
                des.IV = _key1;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                byte[] cipherBytes = ms.ToArray();//得到加密后的字节数组  
                cs.Close();
                ms.Close();
                return Convert.ToBase64String(cipherBytes);
            }

            public static string Decrypt(string secretStr, string secretKey)
            {
                var secretbytes = Convert.FromBase64String(secretStr);

                SymmetricAlgorithm des = Rijndael.Create();
                des.Key = Encoding.UTF8.GetBytes(secretKey);
                des.IV = _key1;
                byte[] decryptBytes = new byte[secretbytes.Length];
                MemoryStream ms = new MemoryStream(secretbytes);
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
                cs.Read(decryptBytes, 0, decryptBytes.Length);
                cs.Close();
                ms.Close();
                return Encoding.UTF8.GetString(decryptBytes);
            }

        }
    }
}