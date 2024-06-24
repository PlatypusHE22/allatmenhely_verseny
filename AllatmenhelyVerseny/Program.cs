using System;
using System.Collections.Generic;

namespace AllatmenhelyVerseny {
    internal class Program {
        public static void Main(string[] args)
        {
            // Maximum életkor beállítása
            try
            {
                Console.WriteLine("Mennyi legyen a regisztrált állatok maximum életkora");
                Allat.MaximumEletkor = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                throw new Exception("Hibás adat megadva, a bevitel csak egész számokat tartalmazhat");
            }


            // Állatok regisztrálása
            Console.WriteLine("Állatok hozzáadása");
            List<Allat> allatok = new List<Allat>();
            while (true)
            {
                Console.WriteLine("Új állat neve:");
                string nev = Console.ReadLine();

                Console.WriteLine("Új állat életkora:");
                int kor = int.Parse(Console.ReadLine());

                Console.WriteLine("Új állat oltási igazolásának száma:");
                int oltasiSzam = int.Parse(Console.ReadLine());

                allatok.Add(new Allat(nev, kor, oltasiSzam));

                Console.WriteLine("További állatok hozzáadása? [I]gen vagy [N]em");
                if (Console.ReadLine().ToLower()[0] == 'n')
                    break;
            }

            // Rajtszámok kiosztása
            for (int i = 0; i < allatok.Count; i++)
            {
                allatok[i].Rajtszam = i + 1;
            }

            // Adatok kiiratása
            foreach (Allat allat in allatok)
            {
                Console.WriteLine(allat);
            }
        } // Main
    }
}