using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;

namespace BachKhoa_AppSanXuat
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    /// 
 
    public partial class LoginScreen : Window
    {

        public LoginScreen()
        {
            InitializeComponent();
        }

        OracleConnection con = new OracleConnection();

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string conString = $"User Id={txtuserName.Text}; Password={txtPassword.Text}; Data Source=bachkhoa-datastructurecourse.ctdrbnxbnuv7.us-east-2.rds.amazonaws.com:1521/XEPDB1; Pooling = false;";
            Console.WriteLine(conString);
            con.ConnectionString = conString;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                if (con.State == ConnectionState.Open)
                {
                    App.Current.Properties["conString"] = conString;
                    App.Current.Properties["con"] = con;
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
