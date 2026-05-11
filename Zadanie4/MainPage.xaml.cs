using System.Collections.ObjectModel;

namespace MauiApp12
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> ListaNotatek { get; set; }

        public MainPage()
        {
            InitializeComponent();

            ListaNotatek = new ObservableCollection<string>
        {
            "Zakupy: chleb, masło, ser",
            "Do zrobienia: obiad, umyć podłogi",
            "weekend: kino, spacer z psem"
        };

            WidokListyNotatek.ItemsSource = ListaNotatek;
        }

        private void KliknieciePrzyciskuDodaj(object sender, EventArgs e)
        {
            string trescNotatki = PoleTekstowe.Text;

            if (!string.IsNullOrWhiteSpace(trescNotatki))
            {
                ListaNotatek.Add(trescNotatki);

                PoleTekstowe.Text = string.Empty;
            }
        }
    }
}
