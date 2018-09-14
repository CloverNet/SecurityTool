using System;

namespace CloverNet.SecurityTool
{
    public partial class SecurityTool
    {
        public static class Base64
        {
            public static string Encrypt(string originalStr)
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(originalStr);
                return Convert.ToBase64String(bytes);
            }

            public static string Decrypt(string originalStr)
            {
                var bytes = Convert.FromBase64String(originalStr);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }
    }
}