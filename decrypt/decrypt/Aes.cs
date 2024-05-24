namespace decrypt.decrypt
{
    internal class Aes
    {
        // 16 bytes long key for AES encryption
        private static readonly byte[] key = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        // 16 bytes long initialization vector
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        public static void AesDecrypt(string inputFilePath, string outputFilePath)
        {
            using AesManaged aesAlg = new();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            // Read the contents of the encrypted file
            byte[] encryptedBytes = File.ReadAllBytes(inputFilePath);

            // Create a MemoryStream to store the decrypted data
            using MemoryStream msDecrypt = new(encryptedBytes);

            // Create the decryptor to perform the stream transform
            using ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create CryptoStream that transforms a stream using the decryption
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);

            // Create a MemoryStream to store the decrypted bytes
            using MemoryStream msDecrypted = new();

            // Read the decrypted bytes from the CryptoStream
            csDecrypt.CopyTo(msDecrypted);

            // Get the decrypted bytes from the MemoryStream
            byte[] decryptedBytes = msDecrypted.ToArray();

            // Write the decrypted bytes to the output file
            File.WriteAllBytes(outputFilePath, decryptedBytes);
        }
    }
}
