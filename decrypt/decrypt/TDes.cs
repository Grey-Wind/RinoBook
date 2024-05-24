internal class TDes
{
    public static string TDesDecrypt(string input)
    {
        string k1 = "2buy7gt6";
        string k2 = "m89bb58j";
        string k3 = "7gf69bc4";

        string _input = DesDecrypt(input, k3);

        string __input = DesDecrypt(_input, k2);

        string output = DesDecrypt(__input, k1);

        return output;
    }

    private static string DesDecrypt(string input, string key)
    {
        using DESCryptoServiceProvider des = new();
        des.Key = Encoding.UTF8.GetBytes(key);
        des.IV = Encoding.UTF8.GetBytes(key);
        using MemoryStream ms = new(Convert.FromBase64String(input));
        using CryptoStream cs = new(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
        using StreamReader sr = new(cs);
        return sr.ReadToEnd();
    }

}