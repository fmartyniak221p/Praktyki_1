using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtNumer_LostFocus(object sender, RoutedEventArgs e)
        {
            string numer = txtNumer.Text;

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string zdjeciePath = System.IO.Path.Combine(baseDir, $"{numer}-zdjecie.jpg");
            string odciskPath = System.IO.Path.Combine(baseDir, $"{numer}-odcisk.jpg");

            if (File.Exists(zdjeciePath))
            {
                imgZdjecie.Source = new BitmapImage(new Uri(zdjeciePath));
            }
            else
            {
                imgZdjecie.Source = null; 
            }

            if (File.Exists(odciskPath))
            {
                imgOdcisk.Source = new BitmapImage(new Uri(odciskPath));
            }
            else
            {
                imgOdcisk.Source = null; 
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImie.Text) || string.IsNullOrWhiteSpace(txtNazwisko.Text))
            {
                MessageBox.Show("Wprowadź dane");
            }
            else
            {
                string kolorOczu = "";
                if (rbNiebieskie.IsChecked == true)
                {
                    kolorOczu = "niebieskie";
                }
                else if (rbZielone.IsChecked == true)
                {
                    kolorOczu = "zielone";
                }
                else if (rbPiwne.IsChecked == true)
                {
                    kolorOczu = "piwne";
                }
                MessageBox.Show($"{txtImie.Text} {txtNazwisko.Text} kolor oczu {kolorOczu}");
            }
        }
    }
}