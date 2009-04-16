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

            bool bDbExisted = File.Exists(@"Dict.db");
            if (!bDbExisted)
                SQLiteConnection.CreateFile(@"Dict.db");

            SQLiteCon.ConnectionString = @"Data Source=Dict.db; Password=Hmong";
            SQLiteCon.Open();

            if (!bDbExisted)
            {
                InsertTableListRows();
            }
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

        private bool InsertTableListRows()
        {
            SQLiteCommand cmd = new SQLiteCommand(SQLiteCon);
            SQLiteTransaction trans = SQLiteCon.BeginTransaction();

            for (int a = 0; a < 50000; a++)
            {
                cmd.CommandText = @"INSERT INTO `TableList` (`ID`, `CnName`, `EnName`, `HmName`, `TableName`) values(NULL, '反对', 'fdl', 'fds', 'fdsa" + a.ToString() + "')";
                cmd.ExecuteNonQuery();
            }

            trans.Commit();

            return true;
        }
        
    }
}
