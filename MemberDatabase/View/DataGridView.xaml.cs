using System.Windows;

namespace MemberDatabase
{
    /// <summary>
    /// Interaction logic for DataGridView.xaml
    /// </summary>
    public partial class DataGridView : Window
    {
        public DataGridView()
        {
            InitializeComponent();
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
            }
            else if (e.Column.Header.ToString() == "accession")
            {
                e.Column.Header = "Eintrittsdatum";
            }
            else if (e.Column.Header.ToString() == "active")
            {
                e.Column.Header = "Aktiv";
            }
        }
    }
}
