using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberDatabase.Model
{
    class Database
    {
        public Database()
        {
            initializeDatabase();
        }

        private void initializeDatabase()
        {
            if (!File.Exists("Member.db"))
            {
                SQLiteConnection.CreateFile("Member.db");
                string sql = "create table members (firstname varchar(40) not null, lastname varchar(40) not null, birthday integer, accession integer, active integer)";
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);

                command.ExecuteNonQuery();
            }
        }

        public List<Member> content()
        {
            List<Member> importedContend = new List<Member>();
            string sql = "select * from members;";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string firstName = Convert.ToString(reader["firstname"]);
                string lastName = Convert.ToString(reader["lastname"]);
                int? birthday = null;
                if (reader["birthday"] != DBNull.Value)
                {
                    birthday = Convert.ToInt32(reader["birthday"]);
                }
                int? accession = null;
                if (reader["accession"] != DBNull.Value)
                {
                    accession = Convert.ToInt32(reader["accession"]);
                }
                bool active = true;
                if (reader["active"] != DBNull.Value)
                {
                    active = Convert.ToBoolean(reader["active"]);
                }
                importedContend.Add(new Member { firstName = firstName, lastName = lastName, birthday = birthday, accession = accession, active = active });
            }
            return importedContend;
        }
    }
}
