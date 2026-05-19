using System;
using System.Collections.Generic;
using System.IO;

namespace AplikacjaKonsolowa
{
    class Album
    {
        public string Wykonawca { get; set; }
        public string Tytul { get; set; }
        public int LiczbaUtworow { get; set; }
        public int RokWydania { get; set; }
        public int LiczbaPobran { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string sciezkaPliku = "Data.txt";
            if (!File.Exists(sciezkaPliku))
            {
                sciezkaPliku = "Dane.txt";
            }

            List<Album> listaAlbumow = WczytajDane(sciezkaPliku);
            WyswietlDane(listaAlbumow);

            Console.ReadLine();
        }

        static List<Album> WczytajDane(string sciezkaPliku)
        {
            List<Album> albumy = new List<Album>();

            if (!File.Exists(sciezkaPliku))
            {
                return albumy;
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
                Album nowyAlbum = new Album();
                nowyAlbum.Wykonawca = linie[i];
                nowyAlbum.Tytul = linie[i + 1];
                nowyAlbum.LiczbaUtworow = int.Parse(linie[i + 2]);
                nowyAlbum.RokWydania = int.Parse(linie[i + 3]);
                nowyAlbum.LiczbaPobran = int.Parse(linie[i + 4]);

                albumy.Add(nowyAlbum);
            }

            return albumy;
        }

        static void WyswietlDane(List<Album> albumy)
        {
            foreach (var album in albumy)
            {
                Console.WriteLine(album.Wykonawca);
                Console.WriteLine(album.Tytul);
                Console.WriteLine(album.LiczbaUtworow);
                Console.WriteLine(album.RokWydania);
                Console.WriteLine(album.LiczbaPobran);
                Console.WriteLine();
            }
        }
    }
}
