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
                string sql = "create table members (firstname varchar(40) not null, lastname varchar(40) not null, birthday integer, accession integer, active integer, groupid integer, email text, adress text);";
                SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
                command.ExecuteNonQuery();

                sql = "create table exams (date integer);";
                command = new SQLiteCommand(sql, DatabaseConnection.instance);
                command.ExecuteNonQuery();

                sql = "create table seminars (date integer, description text);";
                command = new SQLiteCommand(sql, DatabaseConnection.instance);
                command.ExecuteNonQuery();

                sql = "create table member_exam (examid integer, memberid integer, description text);";
                command = new SQLiteCommand(sql, DatabaseConnection.instance);
                command.ExecuteNonQuery();

                sql = "create table member_seminar (seminarid integer, memberid integer);";
                command = new SQLiteCommand(sql, DatabaseConnection.instance);
                command.ExecuteNonQuery();
            }
        }

        public MemberList content()
        {
            MemberList importedContend = new MemberList();
            string sql = "select rowid, firstname, lastname, strftime('%d.%m.%Y ', datetime(birthday, 'unixepoch')) as birthday,  strftime('%d.%m.%Y ', datetime(accession, 'unixepoch')) as accession, active, groupid, email, adress from members order by active desc, groupid asc, lastname asc, firstname asc;";
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
                int group = Convert.ToInt32(reader["groupid"]);
                string email = Convert.ToString(reader["email"]);
                string adress = Convert.ToString(reader["adress"]);
                member = new Member { firstName = firstName, lastName = lastName, birthday = birthday, accession = accession, active = active, group = group, email = email, adress = adress };
                member.setID(id);
                importedContend.Add(member);
            }
            return importedContend;
        }

        public void add(Member member)
        {
            string sql = "insert into members values ('" + member.firstName + "', '" + member.lastName + "', " + convertDate(member.birthday) + ", " + convertDate(member.accession) + ", '" + Convert.ToInt32(member.active) + "', '" + member.group + "', '" + member.email + "', '" + member.adress + "');";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            command.ExecuteNonQuery();

            sql = @"select last_insert_rowid()";
            command = new SQLiteCommand(sql, DatabaseConnection.instance);
            long memberId = (long)command.ExecuteScalar();

            string convertedDate;
            foreach (DateItem exam in member.exam)
            {
                if (exam.date != null)
                {
                    convertedDate = convertDate(exam.date);
                    sql = "insert into exam(date) select " + convertedDate + " where not EXISTS(SELECT 1 FROM exam WHERE date =  " + convertedDate + ");";
                    command = new SQLiteCommand(sql, DatabaseConnection.instance);
                    command.ExecuteNonQuery();

                    sql = @"select last_insert_rowid()";
                    command = new SQLiteCommand(sql, DatabaseConnection.instance);
                    long examId = (long)command.ExecuteScalar();

                    sql = "insert into member_exam(examid, memberid, description) select " + examId + ", " + memberId + ", '" + exam.information + "';";
                    command = new SQLiteCommand(sql, DatabaseConnection.instance);
                    command.ExecuteNonQuery();
                }
            }

            foreach (DateItem seminar in member.seminar)
            {
                if (seminar.date != null)
                {
                    convertedDate = convertDate(seminar.date);
                    sql = "insert into seminar(date, description) select " + convertedDate + ", '" + seminar.information + "' where not EXISTS(SELECT 1 FROM seminar WHERE date =  " + convertedDate + ");";
                    command = new SQLiteCommand(sql, DatabaseConnection.instance);
                    command.ExecuteNonQuery();

                    sql = @"select last_insert_rowid()";
                    command = new SQLiteCommand(sql, DatabaseConnection.instance);
                    long seminarId = (long)command.ExecuteScalar();

                    sql = "insert into member_seminar(seminarid, memberid) select " + seminarId + ", " + memberId + ";";
                    command = new SQLiteCommand(sql, DatabaseConnection.instance);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static string convertDate(DateTime? date)
        {
            if (date != null)
            {
                string dateString = Convert.ToDateTime(date).ToString("dd'.'MM'.'yyyy");
                string[] parts = dateString.Split(new Char[] { '.' });
                return "strftime('%s', '" + parts[2] + "-" + parts[1] + "-" + parts[0] + "')";
            }
            else
            {
                return "null";
            }
            
            
        }
    }
}
