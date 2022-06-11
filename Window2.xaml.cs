using HandyControlProject3.Myclass;
using System;
using System.Windows;

namespace HandyControlProject3
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Connection_Query connection = MainWindow.connection;
        public Window2()
        {
            InitializeComponent();
            userN.Text = MainWindow.user.ToString().ToUpper();
        }

        public void resetDesign()
        {
            Bcategorie.Style = Bcategorie.TryFindResource("menuButton") as Style;
            produits.Style = produits.TryFindResource("menuButton") as Style;
            Bdashboard.Style = Bdashboard.TryFindResource("menuButton") as Style;
            Buser.Style = Buser.TryFindResource("menuButton") as Style;
            Bvendu.Style = Bvendu.TryFindResource("menuButton") as Style;
            Bvente.Style = Bvente.TryFindResource("menuButton") as Style;


        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            connection.CloseConnection();

            Close();
        }

        private void produits_Click(object sender, RoutedEventArgs e)
        {
            resetDesign();
            produits.Style = produits.TryFindResource("menuButtonActive") as Style;
            frame1.Navigate(new System.Uri("Pages/Produit.xaml", UriKind.Relative));



        }

        private void Bcategorie_Click(object sender, RoutedEventArgs e)
        {

            resetDesign();

            Bcategorie.Style = Bcategorie.TryFindResource("menuButtonActive") as Style;
            frame1.Navigate(new System.Uri("Pages/Categorie.xaml", UriKind.Relative));




        }

        private void Buser_Click(object sender, RoutedEventArgs e)
        {
            resetDesign();

            Buser.Style = Buser.TryFindResource("menuButtonActive") as Style;
            frame1.Navigate(new System.Uri("Pages/User.xaml", UriKind.Relative));
        }

        private void Bvente_Click(object sender, RoutedEventArgs e)
        {
            resetDesign();

            Bvente.Style = Bvente.TryFindResource("menuButtonActive") as Style;
            frame1.Navigate(new System.Uri("Pages/Vente.xaml", UriKind.Relative));
        }

        private void Bvendu_Click(object sender, RoutedEventArgs e)
        {
            resetDesign();

            Bvendu.Style = Bvendu.TryFindResource("menuButtonActive") as Style;
            frame1.Navigate(new System.Uri("Pages/Vendu.xaml", UriKind.Relative));
        }

        private void Bdashboard_Click(object sender, RoutedEventArgs e)
        {
            resetDesign();
            Bdashboard.Style = Bdashboard.TryFindResource("menuButtonActive") as Style;
            frame1.Navigate(new System.Uri("Pages/Dashboard.xaml", UriKind.Relative));

        }
    }
}
