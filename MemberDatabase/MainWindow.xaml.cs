using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemberDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            initializeDatabase();
            InitializeComponent();
        }

        private void newMemberClick(object sender, RoutedEventArgs e)
        {
            AddMember addMember = new AddMember();
            addMember.ShowDialog();
            Member.addMember();
        }

        private void initializeDatabase()
        {
            if (!File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");

                string sql = "create table members (firstname varchar(20) not null, lastname varchar(20) not null, birthday integer, accession integer, graduation varchar(20))";

                SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);

                command.ExecuteNonQuery();
            }
        }

        private void mainWindowLoaded(object sender, RoutedEventArgs e)
        {
            string sql = "select * from members";
            SQLiteCommand command = new SQLiteCommand(sql, DatabaseConnection.instance);
            command.ExecuteNonQuery();

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable("Mitglieder");

            dataAdapter.Fill(dataTable);

            DataGrid.ItemsSource = dataTable.DefaultView;

            dataAdapter.Update(dataTable);
        }
    }
}
