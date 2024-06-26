#include "Strings.h"

#include <map>
#include <string>
#include <iostream>
#include <fstream>

// 存储配置信息的map
std::map<std::string, std::string> config;

// 函数：保存配置信息到INI文件
static void SaveConfig(const std::string& filename) {
    std::ofstream file(filename);

    if (!file.is_open()) {
        std::cerr << "Failed to open file for writing: " << filename << std::endl;
        return;
    }

    // 遍历map，将配置信息写入文件
    for (const auto& pair : config) {
        file << pair.first << " = " << pair.second << "\n";
    }

    std::cout << "Config saved to file: " << filename << std::endl;
}

static void WriteDefaultConfig() {
    // 设置一些示例配置信息
    config["language"] = "zh_cn";
    config["null"] = "null";
    config["null"] = "null";
    config["null"] = "null";

    // 保存配置信息到文件
    SaveConfig(GetConfigFileName());
}
