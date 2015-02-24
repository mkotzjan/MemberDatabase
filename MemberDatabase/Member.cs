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
            string sql = "select * from members";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            command.ExecuteNonQuery();

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable("Mitglieder");

            dataAdapter.Fill(dataTable);

            dataGrid.ItemsSource = dataTable.DefaultView;

            dataAdapter.Update(dataTable);
        }
        public static void addMember()
        {
            
        }
    }
}
