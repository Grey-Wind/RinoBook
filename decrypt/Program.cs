global using System.Text;
global using System.Security.Cryptography;
using decrypt.decrypt;
using Aes = decrypt.decrypt.Aes;

// 检查参数数量
if (args.Length != 5)
{
    Console.WriteLine("Usage:");
    Console.WriteLine("decrypt -des -file \"inputFilePath\" -output \"outputFilePath\"");
    Console.WriteLine("decrypt -tdes -file \"inputFilePath\" -output \"outputFilePath\"");
    Console.WriteLine("decrypt -aes -file \"inputFilePath\" -output \"outputFilePath\"");
    return;
}

// 解析参数
string algorithm = args[0];
string inputFile = args[2];
string outputFile = args[4];

// 检查是否选择了DES算法
if (algorithm.ToLower() == "-des")
{
    // 检查输入文件是否存在
    if (File.Exists(inputFile))
    {
        Des.DesDecrypt(inputFile, outputFile);

        Console.WriteLine("File encrypted successfully.");
    }
    else
    {
        Console.WriteLine("Input file does not exist.");
        return;
    }
}

// 检查是否选择了3DES算法
if (algorithm.ToLower() == "-tdes")
{
    // 检查输入文件是否存在
    if (File.Exists(inputFile))
    {
        // 使用DES加密算法解密文件内容
        TDes.TDesDecrypt(inputFile, outputFile);

        Console.WriteLine("File encrypted successfully.");
    }
    else
    {
        Console.WriteLine("Input file does not exist.");
        return;
    }
}

// 检查是否选择了AES算法
if (algorithm.ToLower() == "-aes")
{
    if (File.Exists(inputFile))
    {
        Aes.AesDecrypt(inputFile, outputFile);

        Console.WriteLine("File encrypted successfully.");
    }
    else
    {
        Console.WriteLine("Input file does not exist.");
        return;
    }
}
