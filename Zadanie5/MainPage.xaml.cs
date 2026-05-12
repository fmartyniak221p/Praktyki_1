namespace MauiApp13
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ZmienKolor(object sender, ValueChangedEventArgs e)
        {
            int r = (int)SliderR.Value;
            int g = (int)SliderG.Value;
            int b = (int)SliderB.Value;


            LabelR.Text = r.ToString();
            LabelG.Text = g.ToString();
            LabelB.Text = b.ToString();


            DuzyProstokat.Color = Color.FromRgb(r, g, b);
        }

        private void PobierzKolor(object sender, EventArgs e)
        {
            int r = (int)SliderR.Value;
            int g = (int)SliderG.Value;
            int b = (int)SliderB.Value;


            EtykietaWynik.Text = $"{r}, {g}, {b}";
            EtykietaWynik.BackgroundColor = Color.FromRgb(r, g, b);
        }
    }
}
