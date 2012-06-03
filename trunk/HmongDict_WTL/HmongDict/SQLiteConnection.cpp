#include "stdafx.h"
#include "sqlite3.h"
#include "SQLiteConnection.h"
#include "SQLiteException.h"
#include "SQLiteCommand.h"
#include "SQLiteTransaction.h"

using namespace sqlite3provider;

SQLiteConnection::SQLiteConnection(const string& name) : 
	name(name), 
	version(SQLITE_VERSION), 
	_db(NULL), 
	_inTransaction(false)
{

}

SQLiteConnection::SQLiteConnection(const SQLiteConnection& other) :
	name(other.name), 
	version(other.version), 
	_db(other._db), 
	_inTransaction(other._inTransaction)
{

}

SQLiteConnection::~SQLiteConnection(void)
{
	if (_db)
	{
		close();
	}
}

void SQLiteConnection::open(void)
{
#ifdef _WW
	if (sqlite3_open_v2(name.c_str(), &_db, 0, NULL) != SQLITE_OK)
#else
	if (sqlite3_open(name.c_str(), &_db) != SQLITE_OK)
#endif // _WW
	{
		throw SQLiteException("Unable to open database.");
	}
	setBusyTimeout(3000);
}

//////////////////////////////////////////////////////////////////////////
// [SQLiteCommand]类作用域应小于[SQLiteConnection]类，否则内存泄露 2009-07-23
// {
//		SQLiteConnection conn......
//		conn.open();
//
//		{
//			SQLiteCommand cmd.....
//		}
//
//		conn.close();
//
void SQLiteConnection::close(void)
{
	sqlite3_close(_db);
	_db = NULL;
}

inline void SQLiteConnection::isOpened(void) const
{
	if (!_db)
	{
		throw SQLiteException("Not open database connection.");
	}
}

void SQLiteConnection::execute(const string& sql, int (*callback)(void*,int,char**,char**), void* argument) const
{
	isOpened();

	if (sqlite3_exec(_db, sql.c_str(), callback, argument, NULL) != SQLITE_OK)
	{
		throw SQLiteException(*this);
	}
}

void SQLiteConnection::setBusyTimeout(const int millisecond) const
{
	isOpened();

	if (sqlite3_busy_timeout(_db, millisecond) != SQLITE_OK)
	{
		throw SQLiteException(*this);
	}
}

SQLiteTransaction SQLiteConnection::beginTransaction(void) const
{
	return SQLiteTransaction(*this);
}




