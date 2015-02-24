using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MemberDatabase
{
    static class Member
    {
        public static void loadMember(DataGrid dataGrid)
        {
            string sql = "select firstname as Vorname, lastname as Nachname, strftime('%d.%m.%Y ', datetime(birthday, 'unixepoch')) as Geburtstag,  strftime('%d.%m.%Y ', datetime(accession, 'unixepoch')) as Beitrittsdatum, graduation as Graduierung from members;";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            command.ExecuteNonQuery();

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable("Mitglieder");

            dataAdapter.Fill(dataTable);

            dataGrid.ItemsSource = dataTable.DefaultView;

            dataAdapter.Update(dataTable);
        }

        public static int addMember(string firstName, string lastName, string birthday, string accession, string graduation)
        {
            int errors = 0;
            string sql = "insert into members (firstname, lastname, birthday, accession, graduation) values ('" + firstName + "', '" + lastName + "', strftime('%s', '" + convertDate(birthday) + "'), strftime('%s', '" + convertDate(accession) + "'), '" + graduation +"')";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            command.ExecuteNonQuery();
            return errors;
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
