using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    public class Database
    {
        private static Database connection;
        private static SQLiteConnection dbConnection;

        private Database()
        {
            dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            dbConnection.Open();
        }

        public static SQLiteConnection instance
        {
            get
            {
                if (connection == null)
                {
                    connection = new Database();
                }
                return dbConnection;
            }
        }
    }
}
