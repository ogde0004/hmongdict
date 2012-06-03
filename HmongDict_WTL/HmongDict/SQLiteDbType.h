#pragma once

#include "config.h"

namespace sqlite3provider
{
	enum SQLiteDbType
	{
		DT_INTERGER	= 1,
		DT_FLOAT	= 2,
		DT_TEXT	= 3,
		DT_BLOB	= 4,
		DT_NULL	= 5,
	};
}