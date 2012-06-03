#pragma once

#include "config.h"

namespace sqlite3provider
{
	class SQLiteTransaction
	{
		friend class SQLiteConnection;

	public:
		SQLiteTransaction(const SQLiteTransaction& other);
		~SQLiteTransaction(void);

	private:
		SQLiteTransaction(const SQLiteConnection& );
		SQLiteTransaction& operator=(const SQLiteTransaction& );

	public:
		void commit(void);
		void rollback(void);

	private:
		const SQLiteConnection& _connection;
	};
}