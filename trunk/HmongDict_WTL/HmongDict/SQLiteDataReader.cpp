#include "stdafx.h"
#include "sqlite3.h"
#include "SQLiteDataReader.h"
#include "SQLiteException.h"
#include "SQLiteConnection.h"
#include "SQLiteCommand.h"
#include "SQLiteDbType.h"

using namespace sqlite3provider;

SQLiteDataReader::SQLiteDataReader(SQLiteCommand& command) : 
	_command(command)
{
	_fieldCount = sqlite3_column_count(_command._stmt);
}

SQLiteDataReader::~SQLiteDataReader(void)
{
	close();
}

bool SQLiteDataReader::read(void) const
{
	return _command.step();
}

void SQLiteDataReader::close(void)
{
	_command.~SQLiteCommand();
}

int SQLiteDataReader::getFieldCount(void) const
{
	return _fieldCount;
}

string SQLiteDataReader::getFieldName(const int index) const
{
	verify(index);

	return sqlite3_column_name(_command._stmt, index);
}

SQLiteDbType SQLiteDataReader::getFieldDbType(const int index) const
{
	verify(index);

	return (SQLiteDbType)sqlite3_column_type(_command._stmt, index);
}

string SQLiteDataReader::getDataTypeName(const int index) const
{
	verify(index);

	return sqlite3_column_decltype(_command._stmt, index);
}

bool SQLiteDataReader::isDbNull(const int index) const
{
	return getFieldDbType(index) == DT_NULL;
}

int SQLiteDataReader::getInt32(const int index) const
{
	verify(index);

	return sqlite3_column_int(_command._stmt, index);
}

__int64 SQLiteDataReader::getInt64(const int index) const
{
	verify(index);

	return sqlite3_column_int64(_command._stmt, index);
}

double SQLiteDataReader::getFloat(const int index) const
{
	verify(index);
	
	return sqlite3_column_double(_command._stmt, index);
}

string SQLiteDataReader::getString(const int index) const
{
	verify(index);

	return string((const char*)sqlite3_column_text(_command._stmt, index), 
		sqlite3_column_bytes(_command._stmt, index));
}

string SQLiteDataReader::getString16(const int index) const
{
	verify(index);

	return string((const char*)sqlite3_column_text16(_command._stmt, index), 
		sqlite3_column_bytes(_command._stmt, index));
}

stringstream SQLiteDataReader::getBLOB(const int index) const
{
	verify(index);

	return stringstream((const char*)sqlite3_column_blob(_command._stmt, index), 
		sqlite3_column_bytes(_command._stmt, index));;
}

inline void SQLiteDataReader::verify(const int index) const
{
	if (index < 0 || index >= _fieldCount)
	{
		throw out_of_range("Index out of range");
	}
}