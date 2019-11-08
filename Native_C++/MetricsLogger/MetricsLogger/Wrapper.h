#pragma once

#include "PluginSettings.h"
#include "MetricsLogger.h"

#ifdef __cplusplus

extern "C"
{
#endif
	//Functions go here, Josh

	PLUGIN_API int TestFunction();
	PLUGIN_API void WriteInputToText(const char* input);

#ifdef __cplusplus

}

#endif