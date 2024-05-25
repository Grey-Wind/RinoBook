namespace decrypt.decrypt
{
    internal class Des
    {
        // 使用DES解密算法解密文件
        public static void DesDecrypt(string inputFilePath, string outputFilePath)
        {
            string key = "489cfsj3";

            using DESCryptoServiceProvider des = new();
            des.Key = Encoding.UTF8.GetBytes(key);
            des.IV = Encoding.UTF8.GetBytes(key);

            using FileStream inputFileStream = new(inputFilePath, FileMode.Open, FileAccess.Read);
            using FileStream outputFileStream = new(outputFilePath, FileMode.Create, FileAccess.Write);

            using CryptoStream cryptoStream = new(inputFileStream, des.CreateDecryptor(), CryptoStreamMode.Read);

            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                outputFileStream.Write(buffer, 0, bytesRead);
            }
        }
    }
}
