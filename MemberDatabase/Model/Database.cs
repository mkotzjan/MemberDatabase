namespace MemberDatabase.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Database
    {
        public Database()
        {
            this.initializeDatabase();
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

        public MemberList content()
        {
            MemberList importedContend = new MemberList();
            string sql = "select rowid, firstname, lastname, strftime('%d.%m.%Y ', datetime(birthday, 'unixepoch')) as birthday,  strftime('%d.%m.%Y ', datetime(accession, 'unixepoch')) as accession, active from members order by lastname, firstname asc;";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            SQLiteDataReader reader = command.ExecuteReader();
            Member member;
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["rowid"]);
                string firstName = Convert.ToString(reader["firstname"]);
                string lastName = Convert.ToString(reader["lastname"]);
                DateTime? birthday = null;
                if (reader["birthday"] != DBNull.Value)
                {
                    birthday = Convert.ToDateTime(reader["birthday"]);
                }
                DateTime? accession = null;
                if (reader["accession"] != DBNull.Value)
                {
                    accession = Convert.ToDateTime(reader["accession"]);
                }
                bool active = true;
                if (reader["active"] != DBNull.Value)
                {
                    active = Convert.ToBoolean(reader["active"]);
                }
                member = new Member { firstName = firstName, lastName = lastName, birthday = birthday, accession = accession, active = active };
                member.setID(id);
                importedContend.Add(member);
            }
            return importedContend;
        }

        public void add(Member member)
        {
            string sql = "insert into members values ('" + member.firstName + "', '" + member.lastName + "', strftime('%s', '" + convertDate(Convert.ToDateTime(member.birthday).ToString("dd'.'MM'.'yyyy")) + "'), strftime('%s', '" + convertDate(Convert.ToDateTime(member.accession).ToString("dd'.'MM'.'yyyy")) + "'), '" + Convert.ToInt32(member.active) + "');";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            command.ExecuteNonQuery();
        }

        private static string convertDate(string date)
        {
            if (date == string.Empty)
            {
                return date;
            }
            string[] parts = date.Split(new Char[] { '.' });
            if (parts.Length != 3)
            {
                return string.Empty;
            }
            date = parts[2] + "-" + parts[1] + "-" + parts[0];
            return date;
        }
    }
}
