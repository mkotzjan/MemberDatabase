namespace MemberDatabase
{
    using MemberDatabase.View;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DataGridView.xaml
    /// </summary>
    public partial class DataGridView : Window
    {
        public DataGridView()
        {
            this.InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {
            // Modify the header of the Name column.
            if (e.Column.Header.ToString() == "firstName")
            {
                e.Column.Header = "Vorname";
            }
            else if (e.Column.Header.ToString() == "lastName")
            {
                e.Column.Header = "Nachname";
            }
            else if (e.Column.Header.ToString() == "birthday")
            {
                e.Column.Header = "Geburtstag";
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd'.'MM'.'yyyy";
            }
            else if (e.Column.Header.ToString() == "accession")
            {
                e.Column.Header = "Eintrittsdatum";
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd'.'MM'.'yyyy";
            }
            else if (e.Column.Header.ToString() == "active")
            {
                e.Column.Header = "Aktiv";
            }
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            var win = new AddMemberView();
            win.ShowDialog();
        }
    }
}
