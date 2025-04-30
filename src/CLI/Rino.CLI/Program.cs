using System;
using System.Diagnostics;
using System.IO;
using Rino.CLI.Help;
using Rino.NewProject;
using Rino.Utils;

namespace Rino.CLI
{
    // 日诺命令行
    internal class Program
    {
        // 核心方法 不做改动
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Arguments0();
                    break;
                default:
                    ProcessInputCommand(args);
                    break;
            }
        }

        // 无输入参数方法 不做改动
        static void Arguments0()
        {
            // Show help command
            HelpInfo.NoArguments();
        }

        // 处理输入参数的方法
        static void ProcessInputCommand(string[] args)
        {
            switch (args[0].ToLower()) // 判断输入的第一个参数
            {
                // 帮助信息
                case "-h":
                case "--help":
                    HelpInfo.HelpCommand();
                    break;

                // 版本信息
                case "-v":
                case "--version":
                    Console.WriteLine($"rino-cli@{Versions.CLI.RinoCliVerison}");
                    break;

                // 新建项目
                case "new":
                    NewRinoProject(args);
                    break;

                // 构建项目
                case "build":
                    BuildRinoProject(args);
                    break;

                // 参数不正确
                default:
                    Error.UnknowCommand(args[0].ToLower());
                    break;
            }
        }

        private static void NewRinoProject(string[] args)
        {
            try
            {
                if (args != null && args.Length >= 2)
                {
                    string projectName = args[1].ToLower();
                    string projectFolder;
                    RinoProject rino;

                    switch (args.Length)
                    {
                        case 2:
                            projectFolder = Path.Join(Environment.CurrentDirectory, "projects");

                            rino = new()
                            {
                                ProjectName = projectName,
                                ProjectFolder = projectFolder
                            };
                            rino.CreateProject();
                            break;

                        case 3:
                            projectFolder = args[2].ToLower();

                            rino = new()
                            {
                                ProjectName = projectName,
                                ProjectFolder = projectFolder
                            };
                            rino.CreateProject();
                            break;

                        case > 3:
                            Error.WriteLine("The number of parameters is incorrect.");
                            break;

                        default:
                            Error.WriteLine("Abnormal error. Please report to the developer.");
                            break;
                    }
                }
                else
                {
                    Error.WriteLine("The project name was not entered.");
                }
            }
            catch (ArgumentNullException rnnane)
            {
                Error.WriteLine(rnnane.Message);
            }
        }

        private static void BuildRinoProject(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
