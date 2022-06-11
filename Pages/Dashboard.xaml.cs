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
using HandyControlProject3.Myclass;
namespace HandyControlProject3.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        Connection_Query connection = MainWindow.connection;
        public Dashboard()
        {
            InitializeComponent();
            int total_P = connection.ExecuteScalar("select count(*) from Produit");
            int total_o = connection.ExecuteScalar("select count(*) from Vente");
            int total_r = connection.ExecuteScalar("select Sum(total_pay) from vente");
            Tproduit.Number = total_P.ToString();
            Torder.Number = total_o.ToString();
            Trenenue.Number = total_r.ToString()+"DH";
        }
    }
}
