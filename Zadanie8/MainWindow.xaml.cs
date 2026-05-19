using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    public class Album
    {
        public string Wykonawca { get; set; }
        public string Tytul { get; set; }
        public int LiczbaUtworow { get; set; }
        public int RokWydania { get; set; }
        public int LiczbaPobran { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<Album> listaAlbumow = new List<Album>();
        private int aktualnyIndeks = 0;

        public MainWindow()
        {
            InitializeComponent();
            ZaladujGrafikiZPlikow();
            WczytajDaneZPliku();
            AktualizujOkno();
        }

        private void ZaladujGrafikiZPlikow()
        {
            string katalogAplikacji = AppDomain.CurrentDomain.BaseDirectory;

            string sciezkaObraz = Path.Combine(katalogAplikacji, "obraz.png");
            string sciezkaObraz2 = Path.Combine(katalogAplikacji, "obraz3.png");
            string sciezkaObraz3 = Path.Combine(katalogAplikacji, "obraz2.png");

            if (File.Exists(sciezkaObraz))
            {
                pbPlyta.Source = new BitmapImage(new Uri(sciezkaObraz));
            }

            if (File.Exists(sciezkaObraz2))
            {
                imgPoprzedni.Source = new BitmapImage(new Uri(sciezkaObraz2));
            }
            else
            {
                btnPoprzedni.Content = "<<";
                btnPoprzedni.FontSize = 16;
                btnPoprzedni.FontWeight = FontWeights.Bold;
            }

            if (File.Exists(sciezkaObraz3))
            {
                imgNastepny.Source = new BitmapImage(new Uri(sciezkaObraz3));
            }
            else
            {
                btnNastepny.Content = ">>";
                btnNastepny.FontSize = 16;
                btnNastepny.FontWeight = FontWeights.Bold;
            }
        }

        private void WczytajDaneZPliku()
        {
            string sciezkaPliku = "Dane.txt";
            if (!File.Exists(sciezkaPliku))
            {
                sciezkaPliku = "Data.txt";
            }

            if (!File.Exists(sciezkaPliku))
            {
                return;
            }

            string[] wszystkieLinie = File.ReadAllLines(sciezkaPliku);
            List<string> linie = new List<string>();

            foreach (string linia in wszystkieLinie)
            {
                if (!string.IsNullOrWhiteSpace(linia))
                {
                    linie.Add(linia.Trim());
                }
            }

            for (int i = 0; i + 4 < linie.Count; i += 5)
            {
                Album album = new Album
                {
                    Wykonawca = linie[i],
                    Tytul = linie[i + 1],
                    LiczbaUtworow = int.Parse(linie[i + 2]),
                    RokWydania = int.Parse(linie[i + 3]),
                    LiczbaPobran = int.Parse(linie[i + 4])
                };
                listaAlbumow.Add(album);
            }
        }

        private void AktualizujOkno()
        {
            if (listaAlbumow.Count == 0) return;

            Album aktualny = listaAlbumow[aktualnyIndeks];
            lblWykonawca.Text = aktualny.Wykonawca;
            lblTytul.Text = aktualny.Tytul;
            lblLiczbaUtworow.Text = $"{aktualny.LiczbaUtworow} utworów";
            lblRokWydania.Text = aktualny.RokWydania.ToString();
            lblLiczbaPobran.Text = aktualny.LiczbaPobran.ToString();
        }

        private void BtnPoprzedni_Click(object sender, RoutedEventArgs e)
        {
            if (listaAlbumow.Count == 0) return;

            aktualnyIndeks--;
            if (aktualnyIndeks < 0)
            {
                aktualnyIndeks = listaAlbumow.Count - 1;
            }
            AktualizujOkno();
        }

        private void BtnNastepny_Click(object sender, RoutedEventArgs e)
        {
            if (listaAlbumow.Count == 0) return;

            aktualnyIndeks++;
            if (aktualnyIndeks >= listaAlbumow.Count)
            {
                aktualnyIndeks = 0;
            }
            AktualizujOkno();
        }

        private void BtnPobierz_Click(object sender, RoutedEventArgs e)
        {
            if (listaAlbumow.Count == 0) return;

            listaAlbumow[aktualnyIndeks].LiczbaPobran++;
            AktualizujOkno();
        }
    }
}