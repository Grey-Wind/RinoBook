namespace encrypt.Encrypt
{
    internal class Aes
    {
        // 16 bytes long key for AES encryption
        private static readonly byte[] key = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        // 16 bytes long initialization vector
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        public static string AesEncrypt(string input)
        {
            using AesManaged aesAlg = new();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();
            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using StreamWriter swEncrypt = new(csEncrypt);
                swEncrypt.Write(input);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());        }
    }
}
