using System;

class SortowanieWybieranie
{
    private int[] tablica = new int[10];

    public void WczytajLiczby()
    {
        Console.WriteLine("Podaj 10 liczb całkowitych:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Liczba {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out tablica[i]))
            {
                Console.Write($"Nieprawidłowa wartość. Podaj ponownie liczbę {i + 1}: ");
            }
        }
    }

    private int ZnajdzIndeksMaksimum(int indeksPoczatkowy)
    {
        int indeksMaksimum = indeksPoczatkowy;
        
        for (int i = indeksPoczatkowy + 1; i < tablica.Length; i++)
        {
            if (tablica[i] > tablica[indeksMaksimum])
            {
                indeksMaksimum = i;
            }
        }
        
        return indeksMaksimum;
    }

    public void SortujMalejaco()
    {
        for (int i = 0; i < tablica.Length - 1; i++)
        {
            int indeksMaksimum = ZnajdzIndeksMaksimum(i);
            
            int wartoscTymczasowa = tablica[i];
            tablica[i] = tablica[indeksMaksimum];
            tablica[indeksMaksimum] = wartoscTymczasowa;
        }
    }

    public void WyswietlTablice()
    {
        Console.WriteLine("Posortowana tablica:");
        for (int i = 0; i < tablica.Length; i++)
        {
            Console.Write(tablica[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] argumenty)
    {
        SortowanieWybieranie sortowanie = new SortowanieWybieranie();
        
        sortowanie.WczytajLiczby();
        sortowanie.SortujMalejaco();
        sortowanie.WyswietlTablice();
    }
}
