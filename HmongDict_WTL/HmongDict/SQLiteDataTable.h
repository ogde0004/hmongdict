#pragma once

#include "config.h"
#include "SQLiteConnection.h"

namespace sqlite3provider
{
	class SQLiteDataTable
	{
		friend class SQLiteCommand;

	public:
		SQLiteDataTable(void);
		SQLiteDataTable(const SQLiteConnection& connection, const std::string& commandText);
		SQLiteDataTable(const SQLiteDataTable& other);
		SQLiteDataTable& operator=(const SQLiteDataTable& other);
		~SQLiteDataTable(void);

	public:
		void assign(const SQLiteConnection& connection, const std::string& commandText);

		int rows(void) const;
		int columns(void) const;
		string getFieldName(const int column);
		string getFieldValue(const int row, const int column);

	private:
		vector<std::string> _data;
		int _rows;
		int _columns;
	};
}
