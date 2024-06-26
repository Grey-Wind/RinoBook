#include "Strings.h"

#include <map>
#include <string>
#include <iostream>
#include <fstream>
#include <sstream>

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

// 函数：加载INI配置文件
static void LoadConfig(const std::string& filename) {
    std::ifstream file(filename);

    if (!file.is_open()) {
        std::cerr << "Failed to open file for reading: " << filename << std::endl;
        return;
    }

    std::string line;
    while (std::getline(file, line)) {
        std::istringstream iss(line);
        std::string key, value;
        if (std::getline(iss, key, '=') && std::getline(iss, value)) {
            // 去除key和value的空格
            key.erase(key.find_last_not_of(" \t") + 1);
            value.erase(0, value.find_first_not_of(" \t"));

            // 存储到配置map中
            config[key] = value;
        }
    }

    std::cout << "Config loaded from file: " << filename << std::endl;

    // 输出加载的配置信息（可选）
    for (const auto& pair : config) {
        std::cout << pair.first << " = " << pair.second << std::endl;
    }
}

// 写入默认配置
static void WriteDefaultConfig() {
    config["language"] = "zh_cn";
    config["null"] = "null";
    config["null"] = "null";
    config["null"] = "null";

    // 保存配置信息到文件
    SaveConfig(GetConfigFileName());
}
