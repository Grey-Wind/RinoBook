namespace encrypt.Encrypt
{
    internal class Aes
    {
        // 16 bytes long key for AES encryption
        private static readonly byte[] key = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        // 16 bytes long initialization vector
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("5fr6rfuknf69g6fd");

        public static void AesEncrypt(string inputFilePath, string outputFilePath)
        {
            using AesManaged aesAlg = new();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            // Read the contents of the file to be encrypted
            byte[] fileBytes = File.ReadAllBytes(inputFilePath);

            // Create a MemoryStream to store the encrypted data
            using MemoryStream msEncrypt = new();

            // Create the encryptor to perform the stream transform
            using ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create CryptoStream that transforms a stream using the encryption
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);

            // Write encrypted data to the CryptoStream
            csEncrypt.Write(fileBytes, 0, fileBytes.Length);
            csEncrypt.FlushFinalBlock();

            // Get the encrypted bytes from the MemoryStream
            byte[] encryptedBytes = msEncrypt.ToArray();

            // Write the encrypted bytes to the output file
            File.WriteAllBytes(outputFilePath, encryptedBytes);
        }
    }
}
