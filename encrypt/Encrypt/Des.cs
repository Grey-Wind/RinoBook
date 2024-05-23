namespace encrypt.Encrypt
{
    internal class Des
    {
        // 使用DES加密算法加密文本
        public static string EncryptText(string input)
        {
            string key = "489cfsj3";
            using DESCryptoServiceProvider des = new();
            des.Key = Encoding.UTF8.GetBytes(key);
            des.IV = Encoding.UTF8.GetBytes(key);
            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using StreamWriter sw = new(cs);
                sw.Write(input);
            }
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
