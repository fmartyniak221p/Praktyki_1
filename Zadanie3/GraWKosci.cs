using System;
using System.Collections.Generic;

namespace GraWKosci
{
    class Program
    {
        static void Main(string[] args)
        {
            char ponowienie;

            do
            {
                int liczbaKostek = PobierzLiczbeKostek();

                List<int> rzuty = WykonajRzuty(liczbaKostek);

                WyswietlWyniki(rzuty);
                int punkty = ObliczPunkty(rzuty);
                Console.WriteLine($"Liczba uzyskanych punktów: {punkty}");
                Console.Write("Jeszcze raz? (t/n) ");
                ponowienie = Console.ReadKey().KeyChar;
                Console.WriteLine(); 

            } while (ponowienie == 't' || ponowienie == 'T');
        }

        static int PobierzLiczbeKostek()
        {
            int liczba;
            while (true)
            {
                Console.WriteLine("Ile kostek chcesz rzucić? (3 - 10)");
                string wejscie = Console.ReadLine();

                if (int.TryParse(wejscie, out liczba) && liczba >= 3 && liczba <= 10)
                {
                    return liczba;
                }
            }
        }

        static List<int> WykonajRzuty(int liczbaKostek)
        {
            Random losowanie = new Random();
            List<int> wyniki = new List<int>();

            for (int i = 0; i < liczbaKostek; i++)
            {
                wyniki.Add(losowanie.Next(1, 7)); 
            }
            return wyniki;
        }

        static void WyswietlWyniki(List<int> rzuty)
        {
            for (int i = 0; i < rzuty.Count; i++)
            {
                Console.WriteLine($"Kostka {i + 1}: {rzuty[i]}");
            }
        }

        static int ObliczPunkty(List<int> rzuty)
        {
            int sumaKoncowa = 0;

            for (int wartoscOczek = 1; wartoscOczek <= 6; wartoscOczek++)
            {
                int licznikWystapien = 0;
                int sumaDlaWartosci = 0;

                foreach (int rzut in rzuty)
                {
                    if (rzut == wartoscOczek)
                    {
                        licznikWystapien++;
                        sumaDlaWartosci += rzut;
                    }
                }
                if (licznikWystapien >= 2)
                {
                    sumaKoncowa += sumaDlaWartosci;
                }
            }

            return sumaKoncowa;
        }
    }
}
