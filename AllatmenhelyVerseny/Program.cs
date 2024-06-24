using System;
using System.Collections.Generic;

namespace AllatmenhelyVerseny {
    internal class Program {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Mennyi legyen a regisztrált állatok maximum életkora");
                Allat.MaximumEletkor = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Hibás adat megadva, a bevitel csak egész számokat tartalmazhat");
                return;
            }


            Console.WriteLine("Állatok hozzáadása");
            List<Allat> allatok = new List<Allat>();
            while (true)
            {
                Console.WriteLine("Új állat neve:");
                string nev = Console.ReadLine();

                Console.WriteLine("Új állat életkora:");
                int kor = int.Parse(Console.ReadLine());

                allatok.Add(new Allat(nev, kor));

                Console.WriteLine("További állatok hozzáadása? [I]gen vagy [N]em");
                if (Console.ReadLine().ToLower()[0] == 'n')
                    break;
            }

            foreach (Allat allat in allatok)
            {
                Console.WriteLine(allat);
            }
        } // Main
    }
}