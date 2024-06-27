using System;
using System.Collections.Generic;
using System.IO;

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

            // Állatok regisztrálása, fájl beolvasása
            List<Allat> allatok = new List<Allat>();
            using (StreamReader sr = new StreamReader("allatok.txt"))
            {
                while (!sr.EndOfStream)
                {
                    // Adatok beolvasása és validálása
                    string[] line = sr.ReadLine().Split(';');
                    string nev = line[1];
                    int szuletesiEv;
                    if (!int.TryParse(line[2], out szuletesiEv) || szuletesiEv > aktualisEv || szuletesiEv < 0)
                    {
                        WriteError($"Hiba az adatfájlban, {nev} születési éve hibás.");
                        continue;
                    }

                    int oltasiIgazolvany;
                    if(!int.TryParse(line[3], out oltasiIgazolvany))
                    {
                        WriteError($"Hiba az adatfájlban, {nev} oltási igazolványszáma hibás.");
                        continue;
                    }

                    if (line[0] == "k") // Kutya
                    {
                        allatok.Add(new Kutya(nev, aktualisEv - szuletesiEv, oltasiIgazolvany));
                    }
                    else if (line[0] == "m") // Macska
                    {
                        if (line[4] != "i" && line[4] != "n")
                        {
                            WriteError($"Hiba az adatfájlban, {nev} van-e szállító doboza értéke hibás.");
                            continue;
                        }
                        allatok.Add(new Macska(nev, aktualisEv - szuletesiEv, oltasiIgazolvany, line[4] == "i"));
                    }
                    else
                    {
                        WriteError("Hiba az adatfájlban, ismeretlen állat.");
                    }
                }
            }

            // Rajtszámok kiosztása
            for (int i = 0; i < allatok.Count; i++)
            {
                allatok[i].Rajtszam = i + 1;
            }

            // Állatok pontozása
            foreach (Allat allat in allatok)
            {
                allat.Pontoz();
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