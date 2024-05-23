namespace encrypt.Encrypt
{
    internal class TDes
    {
        public static string TDesEncrypt(string input)
        {
            string k1 = "2buy7gt6";
            string k2 = "m89bb58j";
            string k3 = "7gf69bc4";

            string _input = Des(input, k1);

            string __input = Des(_input, k2);

            string output = Des(__input, k3);

            return output;
        }

        private static string Des(string input, string key)
        {
            using DESCryptoServiceProvider des = new();
            des.Key = Encoding.UTF8.GetBytes(key);
            des.IV = Encoding.UTF8.GetBytes(key);
            using MemoryStream ms = new();
            using (CryptoStream cs = new(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
            {
                using StreamWriter sw = new(cs);
                sw.Write(input);
            }
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
