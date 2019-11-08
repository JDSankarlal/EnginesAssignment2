#include "MetricsLogger.h"

int MetricsLogger::TestFunction()
{
	return 1;

}

void MetricsLogger::WriteInputToText(const char* input)
{
	std::fstream inputWrite;

	inputWrite.open("MetricsText", std::fstream::out);

	inputWrite << input; 

	inputWrite.close();

}

