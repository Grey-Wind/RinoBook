using System;
using static Rino.Versions.CLI;

namespace Rino.CLI.Help
{
    public class HelpInfo
    {
        /// <summary>
        /// 直接运行 rino.exe 时显示的文本
        /// </summary>
        public static void NoArguments()
        {
            // Show help command
            Console.Write("Use ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("rino -h ");
            Console.ResetColor();
            Console.Write("or ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("rino --help ");
            Console.ResetColor();
            Console.WriteLine("to get help information.");
        }

        /// <summary>
        /// 运行 rino --help 或者 rino -h 显示的文本
        /// </summary>
        public static void HelpCommand()
        {
            Console.WriteLine("rino <command>");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("rino new");
            Console.WriteLine("rino build");
            Console.WriteLine("rino help");
            Console.WriteLine("rino help <command>");
            Console.WriteLine();
            Console.WriteLine($"rino-cli@{RinoCliVerison}");
        }
    }
}
