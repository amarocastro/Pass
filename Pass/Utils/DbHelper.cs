using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Pass.Utils
{
    public static class DbHelper
    {
        private static SqliteConnection db;
        private static string db_path = "Filename=db.sql";

        public static void InitializeDB()
        {
            using (db = new SqliteConnection(db_path))
            {
                db.Open();

                String table_cmd = "CREATE TABLE IF NOT EXISTS accounts_data (userID INTEGER PRIMARY KEY, " +
                    "name VARCHAR(255), login VARCHAR(255), email VARCHAR(255), password VARCHAR(255), note VARCHAR";
                SqliteCommand createTable = new SqliteCommand(table_cmd, db);

                createTable.ExecuteReader();
            }
        }

        public static void new_Item_DB()
        {

        }

        public static void delete_Item_DB()
        {

        }

        public static void getSelected_Item_DB()
        {

        }

        public static void getAll_Item_DB()
        {

        }


    }
}
