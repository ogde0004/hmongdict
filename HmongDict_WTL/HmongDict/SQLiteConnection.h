#pragma once

#include "config.h"
#include "SQLiteException.h"
#include "SQLiteCommand.h"
#include "SQLiteTransaction.h"
#include "SQLiteDataReader.h"
#include "SQLiteDataTable.h"

#ifndef _WW
//  #define _WW
#endif

namespace sqlite3provider
{
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
	class SQLiteConnection
	{
		friend class SQLiteException;
		friend class SQLiteCommand;
		friend class SQLiteTransaction;
		friend class SQLiteDataReader;
		friend class SQLiteDataTable;

	public:
		explicit SQLiteConnection(const string& name);
		~SQLiteConnection(void);

	private:
		SQLiteConnection(const SQLiteConnection& );
		SQLiteConnection& operator=(const SQLiteConnection& );

	public:
		void open(void);
		void close(void);

		SQLiteTransaction beginTransaction(void) const;
		void setBusyTimeout(const int millisecond) const;

	private:
		void execute(const string& sql, int (*callback)(void*, int, char**, char**) = NULL, void* argument = NULL) const;
		void isOpened(void) const; 

	public:
		const std::string name;
		const std::string version;

	private:
		struct sqlite3* _db;
		mutable bool _inTransaction;
	};
}
