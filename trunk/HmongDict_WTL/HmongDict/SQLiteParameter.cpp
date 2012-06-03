#include "stdafx.h"
#include "sqlite3.h"
#include "SQLiteParameter.h"
#include "SQLiteException.h"
#include "SQLiteCommand.h"

using namespace sqlite3provider;

SQLiteParameter::SQLiteParameter(const SQLiteCommand& command) :
	_command(command), 
	_isAssigned(false)
{

}

SQLiteParameter::~SQLiteParameter(void)
{

}

void SQLiteParameter::bind(const int index)
{
	assigned();
	verify(sqlite3_bind_null(_command._stmt, index));
}

void SQLiteParameter::bind(const int index, const int& value)
{
	assigned();
	verify(sqlite3_bind_int(_command._stmt, index, value));
}

void SQLiteParameter::bind(const int index, const __int64& value)
{
	assigned();
	verify(sqlite3_bind_int64(_command._stmt, index, value));
}

void SQLiteParameter::bind(const int index, const double& value)
{
	assigned();
	verify(sqlite3_bind_double(_command._stmt, index, value));
}

void SQLiteParameter::bind(const int index, const string& value)
{
	assigned();
	verify(sqlite3_bind_text(_command._stmt, index, value.c_str(), int(value.length()), SQLITE_TRANSIENT));
}

void SQLiteParameter::bind(const int index, const wstring& value)
{
	assigned();
	verify(sqlite3_bind_text16(_command._stmt, index, value.c_str(), int(value.length()), SQLITE_TRANSIENT));
}

void SQLiteParameter::bind(const int index, const char* value)
{
	assigned();
	verify(sqlite3_bind_text(_command._stmt, index, value, (int)strlen(value), SQLITE_TRANSIENT));
}

void SQLiteParameter::bind(const int index, const wchar_t* value)
{
	assigned();
	verify(sqlite3_bind_text16(_command._stmt, index, value, (int)wcslen(value), SQLITE_TRANSIENT));
}

void SQLiteParameter::bind(const int index, const char* value, int size)
{
	assigned();
	verify(sqlite3_bind_blob(_command._stmt, index, value, size, SQLITE_TRANSIENT));
}

void SQLiteParameter::bind(const int index, const void* value, int size)
{
	assigned();
	verify(sqlite3_bind_blob(_command._stmt, index, value, size, SQLITE_TRANSIENT));
}

inline void SQLiteParameter::assigned(void) const
{
	if (_isAssigned)
	{
		throw SQLiteException("The parameter has been assigned.");
	}
}

inline void SQLiteParameter::verify(const int result)
{
	if (result != SQLITE_OK)
	{
		throw SQLiteException(_command.connection);
	}
	
	_isAssigned = true;
}

