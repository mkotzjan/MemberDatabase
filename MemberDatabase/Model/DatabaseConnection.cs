namespace MemberDatabase.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DatabaseConnection
    {
        private static DatabaseConnection connection;
        private static SQLiteConnection dbConnection;

        private DatabaseConnection()
        {
            dbConnection = new SQLiteConnection("Data Source=Member.db;Version=3;");
            dbConnection.Open();
        }

        public static SQLiteConnection instance
        {
            get
            {
                if (connection == null)
                {
                    connection = new DatabaseConnection();
                }
                return dbConnection;
            }
        }
    }
}
