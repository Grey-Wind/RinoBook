using System;
using Rino.CLI.Help;

namespace Rino.CLI
{
    // 日诺命令行
    internal class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    // Show help command
                    HelpInfo.NoArguments();
#if DEBUG
                    Console.ReadKey();
#endif
                    break;
                default:
                    {
                        string inputCommand = args[0].ToLower();

                        switch (inputCommand)
                        {
                            case "-h":
                            case "--help":
                                HelpInfo.HelpCommand();
                                break;
                            case "-v":
                            case "--version":
                                Console.WriteLine($"rino-cli@{Versions.CLI.RinoCliVerison}");
                                break;
                            case "new":
                                break;
                            case "build":
                                break;
                            default:
                                break;
                        }

                        break;
                    }
            }
        }
    }
}
