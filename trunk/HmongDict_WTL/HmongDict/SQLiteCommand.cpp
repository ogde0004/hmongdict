#include "stdafx.h"
#include "sqlite3.h"
#include "SQLiteCommand.h"
#include "SQLiteException.h"
#include "SQLiteConnection.h"
#include "SQLiteDataReader.h"
#include "SQLiteParameter.h"
#include "SQLiteDataTable.h"

using namespace sqlite3provider;

SQLiteCommand::SQLiteCommand(const SQLiteConnection& connection) : 
	connection(connection), 
	_stmt(NULL)
{
	
}

SQLiteCommand::SQLiteCommand(const SQLiteConnection& connection, const string& commandText) : 
	connection(connection), 
	_commandText(commandText), 
	_stmt(NULL)
{
	prepare();
}

SQLiteCommand::SQLiteCommand(const SQLiteCommand& other) : 
	connection(other.connection), 
	_commandText(other._commandText), 
	_stmt(other._stmt)
{
	if (!_commandText.empty())
	{
		prepare();
	}
}

SQLiteCommand::~SQLiteCommand(void)
{
	finalize();
}

void SQLiteCommand::setCommandText(const string& commandText)
{
	reset();
	_commandText.assign(commandText);
	prepare();
}

SQLiteParameter SQLiteCommand::createParameter(void)
{
	return SQLiteParameter(*this);
}

int SQLiteCommand::executeNonQuery(void)
{
	step();

	return sqlite3_changes(connection._db);
}

int SQLiteCommand::executeScalar(void)
{
	//_ASSERT_EXPR(0, L"The function has not been implementation. It will be return 0.");
	//_wassert(L"The function has not been implementation. It will be return 0.", __FILEW__, __LINE__);
	assert(0);

	return 0;
}

const SQLiteDataReader SQLiteCommand::executeReader(void)
{
	return SQLiteDataReader(*this);
}

void SQLiteCommand::fill(SQLiteDataTable& dataTable)
{
	dataTable.assign(connection, _commandText);
}

inline void SQLiteCommand::prepare(void)
{
	connection.isOpened();

	if (sqlite3_prepare(connection._db, _commandText.c_str(), -1, &_stmt, NULL) != SQLITE_OK)
	{
		throw SQLiteException(connection);
	}
}

inline bool SQLiteCommand::step(void)
{
	if (_commandText.empty())
	{
		throw SQLiteException("The command text has not be assigned.");
	}

	if (!_stmt)
	{
		throw SQLiteException("The sqlite statement is null.");
	}

	switch(sqlite3_step(_stmt))
	{
	case SQLITE_ROW:
		return true;
	case SQLITE_DONE:
		return false;
	default:
		throw SQLiteException(connection);
	}
}

inline void SQLiteCommand::reset(void)
{
	if (sqlite3_reset(_stmt) != SQLITE_OK)
	{
		throw SQLiteException(connection);
	}
}

inline void SQLiteCommand::finalize(void)
{
	if (_stmt)
	{
		if (sqlite3_finalize(_stmt) != SQLITE_OK)
		{
			throw SQLiteException(connection);
		}
		_stmt = NULL;
	}
}