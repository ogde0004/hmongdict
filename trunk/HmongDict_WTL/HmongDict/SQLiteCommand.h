#pragma once

#include "config.h"
#include "SQLiteConnection.h"
#include "SQLiteDataReader.h"
#include "SQLiteParameter.h"

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
	class SQLiteCommand
	{
		friend class SQLiteDataReader;
		friend class SQLiteParameter;

	public:
		explicit SQLiteCommand(const SQLiteConnection& connection);
		SQLiteCommand(const SQLiteConnection& connection, const std::string& commandText);
		SQLiteCommand(const SQLiteCommand& other);
		~SQLiteCommand(void);

	private:
		SQLiteCommand& operator=(const SQLiteCommand& );

	public:
		void setCommandText(const std::string& commandText);
		SQLiteParameter createParameter(void);
		int executeNonQuery(void);
		int executeScalar(void);
		const SQLiteDataReader executeReader(void);
		void fill(SQLiteDataTable& dataTable);

	private:
		void prepare(void);
		bool step(void);
		void reset(void);
		void finalize(void);

	public:
		const SQLiteConnection& connection;
		
	private:
		struct sqlite3_stmt* _stmt;
		std::string _commandText;
	};
}