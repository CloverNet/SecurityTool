namespace CloverNet.SecurityTool
{
    public partial  class SecurityTool
    {
        public static class SHA256
        {
            public static string Encrypt(string originalStr)
            {
                //使用 SHA256 加密算法：
                System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
                byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(originalStr);
                byte[] cryString = sha256.ComputeHash(sha256Bytes);
                string sha256Str = string.Empty;
                for (int i = 0; i < cryString.Length; i++)
                {
                    sha256Str += cryString[i].ToString("X2");
                }
                return sha256Str;
            }
        }
    }
}