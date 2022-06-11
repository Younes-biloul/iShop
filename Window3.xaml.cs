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
using System.Windows.Shapes;
using HandyControlProject3.Myclass;
namespace HandyControlProject3
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Connection_Query connection = MainWindow.connection;
        public Window3()
        {
            InitializeComponent();
            userN.Text = MainWindow.user.ToString();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            connection.CloseConnection();
            Close();

        }
    }
}
