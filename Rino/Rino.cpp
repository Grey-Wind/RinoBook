#include "Rino.h"
#include <Windows.h>

namespace fs = std::filesystem;

int main(int argc, char* argv[])
{
    // 设置输出为utf-8
    SetConsoleOutputCP(CP_UTF8);

    std::string filename = "rino_config.ini";

    if (fs::exists(filename)) {
        // 英文
        if (Config::ReadConfig("language") == "en_us") {
            if (argc < 2) {
                std::cout << "Use rino.exe -h to show how to use the rino book." << std::endl;
                return 0;
            }

            // 检查第一个参数是否为 "-h" 或 "--help"
            if (std::strcmp(argv[1], "-h") == 0 || std::strcmp(argv[1], "--help") == 0) {
                // 如果是帮助参数，则输出帮助信息
                std::cout << "Help information:" << std::endl;
                std::cout << "   -h, --help      Display this help message" << std::endl;

                return 0;
            }
        }

        // 中文
        if (Config::ReadConfig("language") == "zh_cn") {
            if (argc < 2) {
                std::cout << "使用 rino.exe -h 以显示日诺的帮助文本" << std::endl;
                return 0;
            }

            // 检查第一个参数是否为 "-h" 或 "--help"
            if (std::strcmp(argv[1], "-h") == 0 || std::strcmp(argv[1], "--help") == 0) {
                // 如果是帮助参数，则输出帮助信息
                std::cout << "帮助:" << std::endl;
                std::cout << "   -h, --help      显示当前帮助信息";

                return 0;
            }
        }

        return 1; 
    }

    // 未检测到配置文件，自动创建配置文件
    else {
        Config::WriteDefaultConfig();
        return 1;
    }

    return 0;
}

