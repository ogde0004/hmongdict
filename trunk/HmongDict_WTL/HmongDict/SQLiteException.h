#pragma once

#include "config.h"
#include "SQLiteConnection.h"

namespace sqlite3provider
{
	class SQLiteException : public std::exception 
	{
	public:
		explicit SQLiteException(const SQLiteConnection& connnection);
		explicit SQLiteException(const std::string& message);
		SQLiteException(const SQLiteException& other);
		virtual ~SQLiteException(void) throw();

	public:
		virtual const char* what(void) const throw();

	private:
		std::string _message;
	};
}