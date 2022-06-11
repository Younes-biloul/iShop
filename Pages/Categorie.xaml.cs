using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
using HandyControl.Controls;
using HandyControl.Tools;
using HandyControlProject3.Myclass;
using MessageBox = HandyControl.Controls.MessageBox;

namespace HandyControlProject3.Pages
{
    /// <summary>
    /// Interaction logic for Categorie.xaml
    /// </summary>
    public partial class Categorie : Page
    {

        Connection_Query connection = MainWindow.connection;
        DataTable T;
        public Categorie()
        {
            InitializeComponent();
            setdatagv();



        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        public void vider()
        {
            T1.Text = "";
            T2.Text = "";
            T1.Focus();


        }
        private void dgv_categorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = dgv_categorie.SelectedIndex;
            if (i > -1)
            {
                DataRowView drv = (DataRowView)dgv_categorie.SelectedItem;
                T1.Text = (drv[0]).ToString();
                T2.Text = (drv[1]).ToString();
               
            }
        }
        public void setdatagv()
        {

            T = new DataTable();
            T = connection.ShowDataInGridView("select*from V_categorie");
            dgv_categorie.ItemsSource = T.DefaultView;
        }

        private void Bajouter_Click(object sender, RoutedEventArgs e)
        {
            if (T1.Text != "" && T2.Text != "")
            {
                try
                {
                    connection.ExecuteQueries($"insert into categorie values('{T1.Text}','{T2.Text}')");
                    Growl.Success("la nouvelle Categorie a été ajoutée avec succès");
                    setdatagv();
                    vider();
                }
                catch (Exception ex)
                {
                    MessageBox.Error("le code déjà existé ".ToUpperInvariant());
                    T1.Text = "";
                    T1.Focus();

                }
            }
            else
            {
                Growl.Info("zone de texte ne pas accepter vide".ToUpper());
                T1.Focus();
            }
            
        }
        

        private void Bsupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (T1.Text != "")
            {
                try
                {
                    connection.ExecuteQueries($"delete categorie where code_c='{T1.Text}'");
                    Growl.Success("Supprimer avec succès");
                    setdatagv();
                    vider();
                }
                catch (Exception ex)
                {
                    MessageBox.Error("le code ne pas existé ".ToUpperInvariant());
                    T1.Text = "";
                    T1.Focus();

                }
            }
            else
            {
                Growl.Info("zone de texte ne pas accepter vide".ToUpper());
                T1.Focus();
            }
        }

        private void Bmodifier_Click(object sender, RoutedEventArgs e)
        {

            if (T1.Text != "" && T2.Text != "")
            {
                try
                {
                    connection.ExecuteQueries($"update categorie set libelle='{T2.Text}'  where code_c='{T1.Text}'");
                    Growl.Success("modefier avec succès".ToUpper());
                    setdatagv();
                    vider();
                }
                catch (Exception ex)
                {
                    MessageBox.Error("le code ne pas existé ".ToUpperInvariant());
                    T1.Text = "";
                    T1.Focus();

                }
            }
            else
            {
                Growl.Info("zone de texte ne pas accepter vide".ToUpper());
                T1.Focus();
            }
        }
    }
}
