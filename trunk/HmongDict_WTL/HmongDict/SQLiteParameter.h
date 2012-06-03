#pragma once

#include "config.h"

namespace sqlite3provider
{
	class SQLiteParameter
	{
	public:
		explicit SQLiteParameter(const SQLiteCommand& command);
		SQLiteParameter(const SQLiteParameter& other);
		~SQLiteParameter(void);

	private:
		SQLiteParameter& operator=(const SQLiteParameter& );

	public:
		void bind(const int index);
		void bind(const int index, const int& value);
		void bind(const int index, const __int64& value);
		void bind(const int index, const double& value);
		void bind(const int index, const std::string& value);
		void bind(const int index, const std::wstring& value);
		void bind(const int index, const char* value);
		void bind(const int index, const wchar_t* value);
		void bind(const int index, const char* value, int size);
		void bind(const int index, const void* value, int size);

	private:
		void assigned(void) const;
		void verify(const int result);

	private:
		const SQLiteCommand& _command;
		bool _isAssigned;
	};
}