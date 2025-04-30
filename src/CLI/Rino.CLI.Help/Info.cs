using System;

namespace Rino.CLI.Help
{
    /// <summary>
    /// 输出错误的类
    /// </summary>
    public class Info : IPrint
    {
        public static void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ResetColor();

        }
        public static void WriteLine(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
