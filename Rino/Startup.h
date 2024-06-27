#pragma once

#include "Rino.h"

class Config
{
	public:
		static void WriteDefaultConfig();
		static std::string ReadConfig(std::string name);
};
