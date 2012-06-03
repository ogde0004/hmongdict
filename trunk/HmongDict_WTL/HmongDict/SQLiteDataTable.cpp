#include "stdafx.h"
#include "sqlite3.h"
#include "SQLiteDataTable.h"
#include "SQLiteConnection.h"
#include "SQLiteException.h"

using namespace sqlite3provider;

SQLiteDataTable::SQLiteDataTable(void) : 
	_rows(0), 
	_columns(0)
{

}

SQLiteDataTable::SQLiteDataTable(const SQLiteConnection& connection, const string& commandText) : 
	_rows(0), 
	_columns(0)
{
	assign(connection, commandText);
}

SQLiteDataTable::SQLiteDataTable(const SQLiteDataTable& other) : 
	_rows(other._rows), 
	_columns(other._columns), 
	_data(other._data)
{
	
}

SQLiteDataTable& SQLiteDataTable::operator=(const SQLiteDataTable& other)
{
	_rows = other._rows;
	_columns = other._columns;
	_data = other._data;

	return *this;
}

SQLiteDataTable::~SQLiteDataTable(void)
{
	_data.clear();
}

int SQLiteDataTable::rows(void) const
{
	return _rows;
}

int SQLiteDataTable::columns(void) const
{
	return _columns;
}

string SQLiteDataTable::getFieldName(const int column)
{
	if (column < 0 || column >= _columns)
	{
		out_of_range("Index out of range.");
	}

	return _data[column];
}

string SQLiteDataTable::getFieldValue(const int row, const int column)
{
	if (column < 0 || column >= _columns)
	{
		out_of_range("Index out of range.");
	}

	if (row < 0 || row >= _rows)
	{
		out_of_range("Index out of range.");
	}

	return _data[_columns * (row + 1) + column];
}

void SQLiteDataTable::assign(const SQLiteConnection& connection, const string& commandText)
{
	connection.isOpened();

	char** result;
	if (sqlite3_get_table(connection._db, commandText.c_str(), &result, &_rows, &_columns, NULL) != SQLITE_OK)
	{
		throw SQLiteException(connection);
	}

	for (int i = 0; i < _columns * (_rows + 1); i++)
	{
		if (result[i])
		{
			_data.push_back(result[i]);
		}
		else
		{
			_data.push_back("NULL");
		}
	}

	sqlite3_free_table(result);
}