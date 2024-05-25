using QingYi.Core.Temp;

internal class TDes
{
    public static void TDesDecrypt(string inputFilePath, string outputFilePath)
    {
        string k1 = "2buy7gt6";
        string k2 = "m89bb58j";
        string k3 = "7gf69bc4";

        string n1 = GetTempFolder.Get() + ".n1";
        string n2 = GetTempFolder.Get() + ".n2";

        DesDecrypt(inputFilePath, n2, k3);

        DesDecrypt(n2, n1, k2);

        DesDecrypt(n1, outputFilePath, k1);
    }

    // 使用DES解密算法解密文件
    public static void DesDecrypt(string inputFilePath, string outputFilePath, string key)
    {
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