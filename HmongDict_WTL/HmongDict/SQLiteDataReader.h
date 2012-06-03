#pragma once

#include "config.h"
#include "SQLiteDbType.h"

namespace sqlite3provider
{
	class SQLiteDataReader
	{
		friend class SQLiteCommand;

	public:
		SQLiteDataReader(const SQLiteDataReader& other);
		~SQLiteDataReader(void);

	private:
		explicit SQLiteDataReader(SQLiteCommand& command);
		SQLiteDataReader& operator=(const SQLiteDataReader& );

	public:
		bool read(void) const;
		void close();

		int getFieldCount(void) const;
		string getFieldName(const int index) const;
		SQLiteDbType getFieldDbType(const int index) const;
		string getDataTypeName(const int index) const;
		bool isDbNull(const int index) const;

		int getInt32(const int index) const;
		__int64 getInt64(const int index) const;
		double getFloat(const int index) const;
		std::string getString(const int index) const;
		std::string getString16(const int index) const;
		std::stringstream getBLOB(const int index) const;

	private:
		void verify(const int index) const;

	private:
		SQLiteCommand& _command;
		int _fieldCount;
	};
}
