namespace MauiApp13
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LblKomunikat.Text = "Autor: 00000000000";
        }

        private void OnZatwierdzClicked(object sender, EventArgs e)
        {
            string email = EntEmail.Text ?? "";
            string haslo = EntHaslo.Text ?? "";
            string powtorzHaslo = EntPowtorzHaslo.Text ?? "";


            if (!email.Contains("@"))
            {
                LblKomunikat.Text = "Nieprawidłowy adres e-mail";
                return;
            }


            if (haslo != powtorzHaslo)
            {
                LblKomunikat.Text = "Hasła się różnią";
                return;
            }


            LblKomunikat.Text = $"Witaj {email}";
        }
    }
}
