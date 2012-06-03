#include "stdafx.h"
#include "sqlite3.h"
#include "SQLiteException.h"
#include "SQLiteConnection.h"

using namespace sqlite3provider;

SQLiteException::SQLiteException(const SQLiteConnection& connnection) :
	_message("SQLiteException: Connection[" + connnection.name + "]: " +  sqlite3_errmsg(connnection._db))
{

}

SQLiteException::SQLiteException(const string& message) : 
	_message("SQLiteException: " + message)
{
	
}

SQLiteException::SQLiteException(const SQLiteException& other) : 
	_message(other._message)
{
	
}

SQLiteException::~SQLiteException(void) throw()
{
	
}

const char* SQLiteException::what(void) const throw()
{
	return _message.c_str();
}