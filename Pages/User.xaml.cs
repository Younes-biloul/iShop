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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Controls;
using HandyControlProject3.Myclass;
using MessageBox = HandyControl.Controls.MessageBox;

namespace HandyControlProject3.Pages
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Page
    {
        Connection_Query connection = MainWindow.connection;
        public User()
        {
            InitializeComponent();
            T1.Focus();
            setdatagv();
            
        }

        private void Bsupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (T1.Text != "")
            {
                try
                {
                    connection.ExecuteQueries($"delete utilisateur where code='{T1.Text}'");
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
            if (T1.Text != "" && T2.Text != "" && T3.Text != "" && T6.Text != "" && T7.Text!="")
            {
                bool b = validation();
                if (b == false)
                {
                    Growl.Error("Errer!");
                    return;
                }

                try
                {

                    connection.ExecuteQueries($"update utilisateur set nom='{T2.Text}' ,date_naissance='{T3.Text}',adresse='{T4.Text}',phone='{T5.Text}',email='{T6.Text}',password='{T7.Text}' where code='{T1.Text}'");
                    Growl.Success(" Modefier avec succès");
                    setdatagv();
                    vider();
                }
                catch (Exception ex)
                {
                    MessageBox.Error("le code déjà existé ".ToUpper());
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

        private void Bajouter_Click(object sender, RoutedEventArgs e)
        {
            if (T1.Text != "" && T2.Text != "" && T3.Text != "" && T6.Text != "" && T7.Text != "")
            {
                bool b = validation();
                if (b == false)
                {
                    Growl.Error("Errer!");
                    return;
                }

                try
                {

                    connection.ExecuteQueries($"insert into utilisateur values('{T1.Text}','{T2.Text}','{T3.Text}','{T4.Text}','{T5.Text}','{T6.Text}','{T7.Text}')");
                    Growl.Success("la nouvelle Utilisateur a été ajoutée avec succès".ToUpper());
                    setdatagv();
                    vider();
                }
                catch (Exception ex)
                {
                    MessageBox.Error("le code déjà existé ".ToUpper());
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

        private void dgv_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = dgv_user.SelectedIndex;
            if (i > -1)
            {
                DataRowView drv = (DataRowView)dgv_user.SelectedItem;
                T1.Text = (drv[0]).ToString();
                T2.Text = (drv[1]).ToString();
                T3.Text = (drv[2]).ToString();
                T4.Text = (drv[3]).ToString();
                T5.Text = (drv[4]).ToString();
                T6.Text = (drv[5]).ToString();
                T7.Text = (drv[6]).ToString();
            }
        }
        public void vider()
        {
            T1.Text = "";
            T2.Text = "";
            T3.Text = "";
            T4.Text = "";
            T5.Text = "";
            T6.Text = "";
            T7.Text = "";

            T1.Focus();


        }
        public void setdatagv()
        {
            DataTable T = new DataTable();
            T = connection.ShowDataInGridView("select * from V_utilisateur");
            dgv_user.ItemsSource = T.DefaultView;
        }
        public bool validation()
        {
            bool b = true;
            try { DateTime.Parse(T3.Text); } catch { T5.Text = ""; T3.Focus(); return false; }
            return b;
        }

    }
}
