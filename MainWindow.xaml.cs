using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using HandyControlProject3.Myclass;

namespace HandyControlProject3
{
    public partial class MainWindow
    {
        public static Connection_Query connection;
        
        public static string user;
        public static string codeuser;

        public MainWindow()
        {
            InitializeComponent();
            connection = new Connection_Query();
            connection.OpenConection();
            
            T1.Text = "Admin";
            T2.Password = "123";



        }

        private void bclose_Click(object sender, RoutedEventArgs e)
        {
            connection.CloseConnection();
            this.Close();
        }

        private void bconcter_Click(object sender, RoutedEventArgs e)
        {

            if (togglebtn.IsChecked == true)
            {
                if (T1.Text.ToUpper() == "ADMIN" && T2.Password == "123")
                {
                    codeuser = "admin";
                    user = "ADMIN";
                    Window2 w = new Window2();
                    w.Show();
                    this.Close();
                }
                else
                {
                    HandyControl.Controls.MessageBox.Show("User name or password invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {


                int i = connection.ExecuteScalar($"Select count(*) from Utilisateur where email='{T1.Text}' and password='{T2.Password}'");
                if (i == 1)
                {
                    codeuser=getcodeuser();
                    user = T1.Text.ToUpper();
                    Window3 w = new Window3();
                    w.Show();
                    this.Close();
                }
                else
                {
                    HandyControl.Controls.MessageBox.Show("User name or password invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            
            }

        }
        public string getcodeuser()
        {
            SqlDataReader R = connection.DataReader($"select code from Utilisateur where email='{T1.Text}' and password='{T2.Password}'");
            while (R.Read())
            {
                codeuser = R.GetString(0);
            }R.Close();
            return codeuser;
        }
    }
}
