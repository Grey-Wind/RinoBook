global using System.Text;
global using System.Security.Cryptography;
using encrypt.Encrypt;
using Aes = encrypt.Encrypt.Aes;

// 检查参数数量
if (args.Length != 5)
{
    Console.WriteLine("Usage:");
    Console.WriteLine("encrypt -des -file \"inputFilePath\" -output \"outputFilePath\"");
    Console.WriteLine("encrypt -tdes -file \"inputFilePath\" -output \"outputFilePath\"");
    Console.WriteLine("encrypt -aes -file \"inputFilePath\" -output \"outputFilePath\"");
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
        // 使用DES加密算法加密文件内容
        Des.DesEncrypt(inputFile, outputFile);

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
        // 读取输入文件内容
        string inputText = File.ReadAllText(inputFile);

        // 使用DES加密算法加密文件内容
        string encryptedText = TDes.TDesEncrypt(inputText);

        // 将加密后的内容写入输出文件
        File.WriteAllText(outputFile, encryptedText);

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
        string inputText = File.ReadAllText(inputFile);

        string encryptedText = Aes.AesEncrypt(inputText);

        File.WriteAllText (outputFile, encryptedText);

        Console.WriteLine("File encrypted successfully.");
    }
    else
    {
        Console.WriteLine("Input file does not exist.");
        return;
    }
}
