#include "stdafx.h"
#include "SQLiteTransaction.h"
#include "SQLiteConnection.h"
#include "SQLiteException.h"

using namespace sqlite3provider;

SQLiteTransaction::SQLiteTransaction(const SQLiteConnection& connection) : 
	_connection(connection)
{
	if (_connection._inTransaction)
	{
		throw SQLiteException(_connection);
	}

	_connection.execute("BEGIN TRANSACTION;");
	_connection._inTransaction = true;
}

SQLiteTransaction::SQLiteTransaction(const SQLiteTransaction& other) :
	_connection(other._connection)
{

}

SQLiteTransaction::~SQLiteTransaction(void)
{
	if (_connection._inTransaction)
	{
		try
		{
			rollback();
		}
		catch (...)
		{
			return;
		}
	}
}

void SQLiteTransaction::commit(void)
{
	_connection.execute("COMMIT TRANSACTION;");
	_connection._inTransaction = false;
}

void SQLiteTransaction::rollback(void)
{
	_connection.execute("ROLLBACK TRANSACTION;");
	_connection._inTransaction = false;
}
