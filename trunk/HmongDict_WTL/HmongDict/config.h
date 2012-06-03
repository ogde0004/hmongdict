#pragma once

//#if !defined(_WIN32)
//#error Non win32 platform
//#endif

#if (defined(MAPLITE_EXPORTS) || defined(_USRDLL)) && defined(_WIN32) && !defined(_LIB)
#define SQLITE3PROVIDER_API __declspec(dllexport)
#elif defined(_MSC_VER) && (_MSC_VER<1200) && !defined(_LIB)
#define SQLITE3PROVIDER_API __declspec(dllimport)
#else
#define SQLITE3PROVIDER_API
#endif

//#define CLASS_UNCOPYABLE(classname) \
//	private: \
//	classname##(const classname##&); \
//	classname##& operator=(const classname##&);

#include <cassert>
#include <vector>
#include <string>
#include <sstream>
#include <iostream>
#include <algorithm>
#include <exception>

namespace sqlite3provider
{
	using namespace std;

	class SQLITE3PROVIDER_API SQLiteException;
	class SQLITE3PROVIDER_API SQLiteParameter;
	class SQLITE3PROVIDER_API SQLiteConnection;
	class SQLITE3PROVIDER_API SQLiteCommand;
	class SQLITE3PROVIDER_API SQLiteDataReader;
	class SQLITE3PROVIDER_API SQLiteDataTable;
	enum SQLiteDbType;
}

