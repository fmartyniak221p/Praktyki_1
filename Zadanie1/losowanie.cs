using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] argumenty)
    {
        Console.WriteLine("Ile wygenerować losowań?");
        
        if (int.TryParse(Console.ReadLine(), out int liczbaLosowan) && liczbaLosowan > 0)
        {
            int[,] losowania = GenerujLosowania(liczbaLosowan);
            WyswietlLosowania(losowania);
            WyswietlWystapienia(losowania);
        }
        else
        {
            Console.WriteLine("Nieprawidłowa wartość.");
        }
    }

    static int[,] GenerujLosowania(int liczbaLosowan)
    {
        int[,] losowania = new int[liczbaLosowan, 6];
        Random generator = new Random();

        for (int i = 0; i < liczbaLosowan; i++)
        {
            HashSet<int> unikalneLiczby = new HashSet<int>();
            
            while (unikalneLiczby.Count < 6)
            {
                unikalneLiczby.Add(generator.Next(1, 50));
            }

            int j = 0;
            foreach (int liczba in unikalneLiczby)
            {
                losowania[i, j] = liczba;
                j++;
            }
        }

        return losowania;
    }

    static void WyswietlLosowania(int[,] losowania)
    {
        Console.WriteLine("Zestawy wylosowanych liczb:");
        int wiersze = losowania.GetLength(0);
        
        for (int i = 0; i < wiersze; i++)
        {
            Console.Write($"Losowanie {i + 1}: ");
            for (int j = 0; j < 6; j++)
            {
                Console.Write($"{losowania[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static void WyswietlWystapienia(int[,] losowania)
    {
        int[] wystapienia = new int[50];
        int wiersze = losowania.GetLength(0);

        for (int i = 0; i < wiersze; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                wystapienia[losowania[i, j]]++;
            }
        }

        for (int i = 1; i <= 49; i++)
        {
            Console.WriteLine($"Wystąpienia liczby {i}: {wystapienia[i]}");
        }
    }
}
