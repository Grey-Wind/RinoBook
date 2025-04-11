using System;

namespace Rino.CLI.Help
{
    /// <summary>
    /// 输出错误的类
    /// </summary>
    public class Error
    {
        public static void UnknowCommand(string command)
        {
            Console.Write("Unknow command ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(command);
            Console.ResetColor();
        }
    }
}
