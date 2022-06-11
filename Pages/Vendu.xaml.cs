using HandyControl.Controls;
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
using System.Data;

namespace HandyControlProject3.Pages
{
    /// <summary>
    /// Interaction logic for Vendu.xaml
    /// </summary>
    public partial class Vendu : Page
    {
        Connection_Query connection = MainWindow.connection;
        DataTable T;
        public Vendu()
        {
            InitializeComponent();
            T = new DataTable();
            T = connection.ShowDataInGridView("select*from vente");
            dgv_vendu.ItemsSource = T.DefaultView;
        }

        private void date_Selected(object sender, RoutedEventArgs e)
        {
            Tsearch.Visibility = Visibility.Hidden;

        }

        private void cbbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbbox1.SelectedIndex == 2)
            {
                Tsearch.Visibility = Visibility.Collapsed;
                Sdate.Visibility = Visibility.Visible;
            }
            else
            {
                Sdate.Visibility = Visibility.Collapsed ;

                Tsearch.Visibility = Visibility.Visible;
            }

            }

            private void Bsearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Growl.Success("ok");
            if (cbbox1.SelectedIndex ==0)
            {
                T = new DataTable();
                T = connection.ShowDataInGridView($"select*from vente where numero='{Tsearch.Text}'");
                dgv_vendu.ItemsSource = T.DefaultView;
            }
            if (cbbox1.SelectedIndex == 1)
            {
                T = new DataTable();
                T = connection.ShowDataInGridView($"select*from vente where code_utilisateur='{Tsearch.Text}'");
                dgv_vendu.ItemsSource = T.DefaultView;
            }
            
        }

        private void T1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (cbbox1.SelectedIndex == 2 && T1.Text != "")
            {
                T = new DataTable();
                T = connection.ShowDataInGridView($"select*from vente where date between '{T1.Text+ " 00:00:00"}' and '{T1.Text+ " 23:59:59"}' ");
                dgv_vendu.ItemsSource = T.DefaultView;
            }
        }

        private void T2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbox1.SelectedIndex == 2 && T1.Text != "" && T2.Text != "")
            {
                T = new DataTable();
                T = connection.ShowDataInGridView($"select*from vente where date between '{T1.Text+ " 00:00:00"}' and '{T2.Text+ " 23:59:59"}'");
                dgv_vendu.ItemsSource = T.DefaultView;
            }
        }
    }
}
