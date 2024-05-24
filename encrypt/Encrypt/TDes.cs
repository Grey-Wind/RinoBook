using QingYi.Core.Temp;

namespace encrypt.Encrypt
{
    internal class TDes
    {
        public static void TDesEncrypt(string inputFilePath, string outputFilePath)
        {
            string k1 = "2buy7gt6";
            string k2 = "m89bb58j";
            string k3 = "7gf69bc4";

            string n1 = GetTempFolder.Get() + ".n1";
            string n2 = GetTempFolder.Get() + ".n2";

            Des(inputFilePath, n1, k1);

            Des(n1, n2, k2);

            Des(n2, outputFilePath, k3);
        }

        // 使用DES加密算法加密文件
        public static void Des(string inputFilePath, string outputFilePath, string key)
        {
            using DESCryptoServiceProvider des = new();
            des.Key = Encoding.UTF8.GetBytes(key);
            des.IV = Encoding.UTF8.GetBytes(key);

            using FileStream inputFileStream = new(inputFilePath, FileMode.Open, FileAccess.Read);
            using FileStream outputFileStream = new(outputFilePath, FileMode.Create, FileAccess.Write);

            using CryptoStream cryptoStream = new(outputFileStream, des.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] buffer = new byte[4096];
            int bytesRead;

            while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                cryptoStream.Write(buffer, 0, bytesRead);
            }
        }
    }
}
