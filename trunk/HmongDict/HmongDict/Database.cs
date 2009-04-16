using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace HmongDict
{
    class Database
    {
        SQLiteConnection SQLiteCon = null;
        
        public Database()
        {
            SQLiteCon = new SQLiteConnection();

            if (!(File.Exists(@"Dict.db")))
            {
                throw new Exception("Database File not exists");
            }

            SQLiteCon.ConnectionString = @"Data Source=Dict.db; Password=Hmong";
            SQLiteCon.Open();
        }

        /*
        ~Database()
        {
            if (null != SQLiteCon)
            {
                SQLiteCon.Close();
                SQLiteCon.Dispose();
                SQLiteCon = null;
            }
        }
        */

        public SQLiteDataReader Query(string strCmd)
        {
            if (null == SQLiteCon)
            {
                throw new Exception("SQLiteConnection not init yet!");
            }

            SQLiteCommand cmd = new SQLiteCommand(strCmd, SQLiteCon);
            return cmd.ExecuteReader();
        }
    }
}
