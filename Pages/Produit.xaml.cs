using HandyControl.Controls;
using HandyControl.Tools;
using HandyControlProject3.Myclass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using MessageBox = HandyControl.Controls.MessageBox;

namespace HandyControlProject3.Pages
{
    /// <summary>
    /// Interaction logic for Produit.xaml
    /// </summary>
    public partial class Produit : Page
    {
        Connection_Query connection = MainWindow.connection;

        public Produit()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("fr");
            CmbBox();
            setdatagv();
            T1.Focus();



        }
        public void CmbBox()
        {

            SqlDataReader R = connection.DataReader("select * from categorie");
            while (R.Read())
            {
                ComboBoxItem c = new ComboBoxItem();
                c.Tag = R.GetString(0);
                c.Content = R.GetString(1);
                T7.Items.Add(c);

            }
            R.Close();


        }
        public void setdatagv()
        {
            DataTable T = new DataTable();
            T = connection.ShowDataInGridView("select * from V_Produit");



            dgv_produit.ItemsSource = T.DefaultView;
        }









        private void dgv_produit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = dgv_produit.SelectedIndex;
            if (i > -1)
            {
                DataRowView drv = (DataRowView)dgv_produit.SelectedItem;
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

            T1.Focus();


        }
        private void Bajouter_Click(object sender, RoutedEventArgs e)
        {

            if (T1.Text != "" && T2.Text != "" && T3.Text != "" && T4.Text != "")
            {
                bool b = validation();
                if (b == false)
                {
                    Growl.Error("Errer!");
                    return;
                }

                try
                {

                    connection.ExecuteQueries($"insert into produit values('{T1.Text}','{T2.Text}','{T3.Text}','{T4.Text}','{T5.Text}','{T6.Text}','{T7.SelectedValue}')");
                    Growl.Success("la nouvelle Produit a été ajoutée avec succès");
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

        private void Bmodifier_Click(object sender, RoutedEventArgs e)
        {

            if (T1.Text != "" && T2.Text != "" && T3.Text != "" && T4.Text != "")
            {
                bool b = validation();
                if (b == false)
                {
                    Growl.Error("Errer!");
                    return;
                }

                try
                {

                    connection.ExecuteQueries($"update produit set libelle='{T2.Text}' ,prix='{T3.Text}',stock='{T4.Text}',date_production='{T5.Text}',date_expiration='{T6.Text}',code_categorie='{T7.SelectedValue}' where barcode={T1.Text}");
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
        private void Bsupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (T1.Text != "" )
            {
                try
                {
                    connection.ExecuteQueries($"delete produit where barcode='{T1.Text}'");
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

        private void T1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public bool validation()
        {

            bool b = true;
            try { int.Parse(T1.Text); } catch { T1.Text = ""; T1.Focus(); return false; }
            try { double.Parse(T3.Text); } catch { T3.Text = ""; T3.Focus(); return false; }
            try { int.Parse(T4.Text); } catch { T4.Text = ""; T4.Focus(); return false; }
            // try { DateTime.Parse(T5.Text); } catch { T5.Text = ""; T5.Focus(); return; }
            // try { DateTime.Parse(T6.Text); } catch { T6.Text = ""; T6.Focus(); return; }
            return b;



        }
    }
}
