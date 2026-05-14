namespace MauiApp14
{
    public partial class MainPage : ContentPage
    {
        private int calkowityWynikGry = 0;
        private Random losowanie = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OdrzucKoscmiKlikniete(object sender, EventArgs e)
        {
            int[] wynikiRzutow = new int[5];
            Image[] kontrolkiObrazow = { ObrazKosci1, ObrazKosci2, ObrazKosci3, ObrazKosci4, ObrazKosci5 };

            for (int i = 0; i < 5; i++)
            {
                wynikiRzutow[i] = losowanie.Next(1, 7); 
                kontrolkiObrazow[i].Source = $"k{wynikiRzutow[i]}.jpg";
            }

            int punktyBiezace = ObliczPunkty(wynikiRzutow);

            calkowityWynikGry += punktyBiezace;

            NapisWynikLosowania.Text = $"Wynik tego losowania: {punktyBiezace}";
            NapisWynikGry.Text = $"Wynik gry: {calkowityWynikGry}";
        }

        private int ObliczPunkty(int[] rzuty)
        {
            int sumaPunktow = 0;
            int[] licznikiOczek = new int[7];

            foreach (int oczka in rzuty)
            {
                licznikiOczek[oczka]++;
            }

            for (int i = 1; i <= 6; i++)
            {
                if (licznikiOczek[i] >= 2)
                {
                    sumaPunktow += (i * licznikiOczek[i]);
                }
            }

            return sumaPunktow;
        }

        private void OnResetujWynikKlikniete(object sender, EventArgs e)
        {
            calkowityWynikGry = 0;

            ObrazKosci1.Source = "question.jpg";
            ObrazKosci2.Source = "question.jpg";
            ObrazKosci3.Source = "question.jpg";
            ObrazKosci4.Source = "question.jpg";
            ObrazKosci5.Source = "question.jpg";

            NapisWynikLosowania.Text = "Wynik tego losowania: 0";
            NapisWynikGry.Text = "Wynik gry: 0";
        }
    }
}
