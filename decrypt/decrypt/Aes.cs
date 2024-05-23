namespace decrypt.decrypt
{
    internal class Aes
    {
        // 16 bytes long key for AES encryption
        private static readonly byte[] key = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        // 16 bytes long initialization vector
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        public static string AesDecrypt(string cipherText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            using AesManaged aesAlg = new();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(cipherTextBytes);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}
