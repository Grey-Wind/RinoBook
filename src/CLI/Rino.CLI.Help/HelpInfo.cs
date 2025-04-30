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
            string allText = @"
rino <command>

Usage:
rino new <project name>
rino new <project name> <project path>
rino build
rino -v
rino --verison
rino -h
rino -h <command>
rino --help
rino --help <command>
";
            Console.WriteLine(allText);
            Console.WriteLine();
            Console.WriteLine($"rino-cli@{RinoCliVerison}");
        }
    }
}
