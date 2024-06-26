#include "Startup.h"

#include <iostream>

int main(int argc, char* argv[])
{
    if (argc < 2) {
        std::cout << "Use \"Rino.exe -h\" to show how to use the rino book.\n";
        return 1; // 返回错误代码，表示参数不足
    }

    // 检查第一个参数是否为 "-h" 或 "--help"
    if (std::strcmp(argv[1], "-h") == 0 || std::strcmp(argv[1], "--help") == 0) {
        // 如果是帮助参数，则输出帮助信息
        std::cout << "Help information:" << std::endl;
        std::cout << "   -h, --help      Display this help message" << std::endl;

        return 0;
    }

    return 0;
}

