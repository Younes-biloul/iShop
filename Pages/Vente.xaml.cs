using HandyControl.Controls;
using HandyControlProject3.Myclass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using MessageBox = HandyControl.Controls.MessageBox;
namespace HandyControlProject3.Pages
{
    /// <summary>
    /// Interaction logic for Vente.xaml
    /// </summary>
    public partial class Vente : Page
    {
        Connection_Query connection = MainWindow.connection;
        DataTable table;
        double total;
        public Vente()
        {
            InitializeComponent();
            T1.Focus();
            table = new DataTable("Vente");
            table.Columns.Add("Code");
            table.Columns.Add("Produit");
            table.Columns.Add("Prix");
            table.Columns.Add("Quantité");


        }

        private void T1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                SqlDataReader R = connection.DataReader($"select libelle,prix from produit where barcode={T1.Text}");
                while (R.Read())
                {


                    DataRow row = table.NewRow();

                    row["Code"] = T1.Text;
                    row["Produit"] = R.GetString(0);
                    row["Prix"] = Convert.ToString(R.GetValue("prix"));
                    row["Quantité"] = T2.Value.ToString();
                    table.Rows.Add(row);
                    sound();
                    T1.Text = "";

                    T1.Focus();

                }

                R.Close();
                dgv_vente.ItemsSource = table.DefaultView;
                Calculertotal();


            }
            catch
            {

                T1.Focus();
            }

        }

        private void Bsupprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = dgv_vente.SelectedIndex;
                table.Rows[i].Delete();
                Calculertotal();
            }
            catch { T1.Focus(); }

        }

        private void Bavalider_Click(object sender, RoutedEventArgs e)
        {
            Calculertotal();
            try
            {
                string s = connection.ExecuteQueries($"insert into vente values('{DateTime.Now.ToString()}','{MainWindow.codeuser}','{total.ToString()}')");
                if (s == "1")
                {
                    Growl.Success("Valide");
                    table.Rows.Clear();
                }
                else { Growl.Error("Invalid"); }
            }
            catch { MessageBox.Show("Error"); return; }






        }

        private void Btn_change_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (T3.Text != "")
                {
                    Lchange.Content = String.Format("{0:0.00}", (Convert.ToDouble(T3.Text) - total)) + "DH";
                }
            }
            catch { T3.Focus(); }
        }

        public void Calculertotal()
        {
            total = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                total += Convert.ToDouble(table.Rows[i][2].ToString()) * Convert.ToInt32(table.Rows[i][3].ToString());
            }
            Ltotal.Content = total.ToString() + "DH";
        }
        public void sound()
        {
            string path = System.IO.Path.GetFullPath("sound1.wav").Replace(@"bin\Debug\net5.0-windows", "Images");

            SoundPlayer player = new SoundPlayer(path);
            player.Play();
        }


    }
}
