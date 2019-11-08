#pragma once
#include "Wrapper.h"

MetricsLogger metricsLogger;

int TestFunction()
{
	return metricsLogger.TestFunction();
}

void WriteInputToText(char input)
{
	return metricsLogger.WriteInputToText(input);
}

