using System;
using System.Collections.Generic;

namespace AllatmenhelyVerseny {
    internal class Program {
        public static string hibasAdatMsg = "Hibás adat, az adat csak egész számokat tartalmazhat.\nPróbálja újra:";

        public static void Main(string[] args)
        {
            int aktualisEv;
            Console.WriteLine("Adja meg az aktuális évet: ");
            while (!int.TryParse(Console.ReadLine(), out aktualisEv))
            {
                WriteError(hibasAdatMsg);
            }

            // Maximum életkor beállítása
            Console.WriteLine("Mennyi legyen a regisztrált állatok maximum életkora");
            int maxEletkor;
            while (!int.TryParse(Console.ReadLine(), out maxEletkor))
            {
                WriteError(hibasAdatMsg);
            }
            Allat.MaximumEletkor = maxEletkor;

            // Állatok regisztrálása
            Console.WriteLine("Állatok hozzáadása");
            List<Allat> allatok = new List<Allat>();
            while (true)
            {
                Console.WriteLine("Új állat neve:");
                string nev = Console.ReadLine();

                Console.WriteLine("Új állat születési éve:");
                int szulEv, kor;
                while (!int.TryParse(Console.ReadLine(), out szulEv) || szulEv < 0 || szulEv > aktualisEv)
                {
                    WriteError($"Hibás adat. Az adat nem tartalmazhat betűt, illetve 0-nál nagyobbnak, {aktualisEv}-nél kisebbnek kell lennie.\nPróbálja újra:");
                }
                kor = aktualisEv - szulEv;

                Console.WriteLine("Új állat oltási igazolásának száma:");
                int oltasiSzam;
                while (!int.TryParse(Console.ReadLine(), out oltasiSzam))
                {
                    WriteError(hibasAdatMsg);
                }

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
            WriteLineColored("\nEredmények", ConsoleColor.Green);
            foreach (Allat allat in allatok)
            {
                Console.WriteLine(allat);
            }

            // Résztvevők száma
            Console.WriteLine($"Résztvevők száma: {allatok.Count}");

            // Átlag pontszám
            int ossz = 0;
            foreach (Allat allat in allatok)
            {
                ossz += allat.Pontok;
            }
            Console.WriteLine($"Átlag pontszám: {ossz / allatok.Count}");

            // Legnagyobb pontszám
            Allat nyertes = allatok[0];
            foreach (Allat allat in allatok)
            {
                if (allat.Pontok > nyertes.Pontok)
                    nyertes = allat;
            }

            Console.WriteLine($"Legtöbb ponton {nyertes.Nev} szerezte, ez {nyertes.Pontok} volt");


        } // Main

        #region Console segítők
        static void WriteColored(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ResetColor();
        }

        static void WriteLineColored(string msg, ConsoleColor color)
        {
            msg += "\n";
            WriteColored(msg, color);
        }

        static void WriteError(string msg)
        {
            WriteColored(msg, ConsoleColor.Red);
        }
        #endregion
    }
}