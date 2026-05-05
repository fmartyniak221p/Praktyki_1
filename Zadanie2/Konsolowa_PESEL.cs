using System;

class Program
{
    static void Main(string[] args)
    {
        string pesel = "55030101193";

        Console.WriteLine("Podaj numer PESEL:");
        string wejscie = Console.ReadLine();

        if (!string.IsNullOrEmpty(wejscie))
        {
            pesel = wejscie;
        }
        else
        {
            Console.WriteLine(pesel);
        }

        if (pesel.Length == 11)
        {
            char plecZnak = SprawdzPlec(pesel);
            if (plecZnak == 'K')
                Console.WriteLine("Płeć: Kobieta");
            else
                Console.WriteLine("Płeć: Mężczyzna");

            if (SprawdzSumeKontrolna(pesel))
                Console.WriteLine("Suma kontrolna: zgodna");
            else
                Console.WriteLine("Suma kontrolna: niezgodna");
        }
        else
        {
            Console.WriteLine("Błąd: Numer PESEL musi składać się z 11 cyfr.");
        }

    }

    static char SprawdzPlec(string pesel)
    {
        int cyfra = int.Parse(pesel[9].ToString());

        if (cyfra % 2 == 0)
            return 'K';
        else
            return 'M';
    }

    static bool SprawdzSumeKontrolna(string pesel)
    {
        int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        int S = 0;

        for (int i = 0; i < 10; i++)
        {
            int cyfra = int.Parse(pesel[i].ToString());
            S += cyfra * wagi[i];
        }

        int M = S % 10;

        int R;
        if (M == 0)
            R = 0;
        else
            R = 10 - M;

        int jedenastaCyfra = int.Parse(pesel[10].ToString());

        return R == jedenastaCyfra;
    }
}