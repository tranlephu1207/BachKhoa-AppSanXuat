using System;
using System.Collections.Generic;
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
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BachKhoa_AppSanXuat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.WriteLine(App.Current.Properties["conString"]);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OracleConnection con = App.Current.Properties["con"] as OracleConnection;
            Console.WriteLine(con.State);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            OracleCommand cmd = con.CreateCommand();
            // cmd.CommandText = "SELECT * FROM USER_TAB_PRIVS where privilege = 'SELECT'";
            cmd.CommandText = "SELECT * FROM sysdba.NguyenVatLieu";

            OracleDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            oda.Fill(dt);
            dataGridview1.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
