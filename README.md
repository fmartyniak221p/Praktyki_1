# Praktyki - dwa zadania na pierwszy dzień praktyk
## Wszystkie zadania były tworzone w edytorze VisualStudio 2026 versja 18.4.3
### Zadanie pierwsze - losowanie liczb
```csharp
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
```

# Dokumentacja Zadania 1: Loteria Liczbowa

## 1. Opis aplikacji
Program jest aplikacją konsolową symulującą loterię liczbową. Użytkownik określa liczbę zestawów, które mają zostać wylosowane. Każdy zestaw składa się z 6 unikalnych liczb całkowitych z zakresu od 1 do 49. Po wygenerowaniu danych program wyświetla wyniki losowań oraz statystykę wystąpień każdej z liczb we wszystkich zestawach.

## 2. Opis algorytmu
1. Pobranie od użytkownika liczby zestawów `n`.
2. Dla każdego z `n` zestawów:
   - Losowanie liczb za pomocą generatora liczb pseudolosowych.
   - Zapewnienie unikalności liczb w obrębie jednego zestawu (brak powtórzeń).
   - Zapisanie zestawu do dwuwymiarowej tablicy.
3. Wyświetlenie zawartości tablicy na ekranie.
4. Przejście przez całą tablicę w celu zliczenia wystąpień liczb 1-49.
5. Wyświetlenie wyników zliczania.

## 3. Wykaz zmiennych
| Nazwa zmiennej | Typ | Opis |
| :--- | :--- | :--- |
| `liczbaLosowan` | `int` | Przechowuje liczbę zestawów do wygenerowania, podaną przez użytkownika. |
| `losowania` | `int[,]` | Tablica dwuwymiarowa (n wierszy, 6 kolumn) przechowująca wyniki wszystkich losowań. |
| `generator` | `Random` | Obiekt klasy Random służący do generowania liczb pseudolosowych. |
| `unikalneLiczby` | `HashSet<int>` | Kolekcja pomocnicza zapewniająca unikalność liczb w zestawie. |
| `wystapienia` | `int[]` | Tablica liczników (rozmiar 50) przechowująca liczbę wystąpień dla każdej liczby od 1 do 49. |

## 4. Wykaz metod
| Nazwa metody | Parametry | Typ zwracany | Opis |
| :--- | :--- | :--- | :--- |
| `GenerujLosowania` | `int liczbaLosowan` | `int[,]` | Wypełnia tablicę losowymi, niepowtarzającymi się liczbami z zakresu <1, 49>. |
| `WyswietlLosowania` | `int[,] losowania` | `void` | Wyświetla wszystkie wygenerowane zestawy na ekranie. |
| `WyswietlWystapienia`| `int[,] losowania` | `void` | Zlicza i wyświetla liczbę wystąpień każdej liczby (1-49). |

---

### Zadanie drugie - sortowanie przez wybieranie
```csharp
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
```

# Dokumentacja Zadania 2: Sortowanie przez wybieranie

## 1. Opis aplikacji
Aplikacja konsolowa realizująca algorytm sortowania tablicy 10 liczb całkowitych metodą "przez wybieranie" (Selection Sort) w porządku malejącym. Program wczytuje dane od użytkownika, wyszukuje element maksymalny w nieposortowanej części tablicy i zamienia go miejscami z elementem na bieżącej pozycji.

## 2. Opis algorytmu (Sortowanie malejące)
1. Inicjalizacja tablicy 10 liczb pobranych z klawiatury.
2. Dla każdego indeksu `i` od 0 do przedostatniego elementu tablicy:
   - Znajdź indeks największego elementu w podzbiorze od `i` do końca tablicy.
   - Zamień miejscami element na pozycji `i` z elementem maksymalnym.
3. Wyświetlenie posortowanej tablicy.
Algorytm posiada złożoność obliczeniową $O(n^2)$.

## 3. Opis klasy i pól
| Nazwa pola | Typ | Widoczność | Opis |
| :--- | :--- | :--- | :--- |
| `tablica` | `int[]` | `private` | Pole klasy przechowujące 10 liczb całkowitych do posortowania. |

## 4. Wykaz metod klasy `SortowanieWybieranie`
| Nazwa metody | Parametry | Typ zwracany | Widoczność | Opis |
| :--- | :--- | :--- | :--- | :--- |
| `WczytajLiczby` | brak | `void` | `public` | Pobiera od użytkownika 10 liczb i zapisuje je w tablicy. |
| `ZnajdzIndeksMaksimum` | `int indeksPoczatkowy` | `int` | `private` | Szuka indeksu najwyższej wartości od zadanej pozycji do końca tablicy. |
| `SortujMalejaco` | brak | `void` | `public` | Realizuje główną pętlę sortowania przez wybieranie. |
| `WyswietlTablice` | brak | `void` | `public` | Wypisuje wszystkie elementy tablicy na ekran. |
