using System.Windows;
using System.Data;
using System.Data.SqlClient;
using PracticalWork10.Model;

namespace PracticalWork10.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        private SqlConnection _connection = null;
        private SqlDataAdapter _adapter = null;
        
        public TableWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _connection = new SqlConnection("@OfficeEntities");
            _connection.Open();
            _adapter = new SqlDataAdapter("SELECT * FROM Clients", _connection);
        }
    }
}
