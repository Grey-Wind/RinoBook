using System;
using Rino.CLI.Help;

namespace Rino.CLI
{
    // 日诺命令行
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // Show help command
                HelpInfo.NoArguments();
#if DEBUG
                Console.ReadKey();
#endif
            }
            else
            {
                string inputCommand = args[0].ToLower();

                if (inputCommand == "-h" || inputCommand == "--help")
                {
                    HelpInfo.HelpCommand();
                }
            }
        }
    }
}
