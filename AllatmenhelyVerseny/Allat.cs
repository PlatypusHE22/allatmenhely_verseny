using System;
using System.Runtime.InteropServices;

namespace AllatmenhelyVerseny {
    public class Allat {
        public static int MaximumEletkor = 0;

        private string nev;
        private int kor;
        private int rajtszam = 0;
        private int oltasiIgazolás;

        public int Rajtszam
        {
            get => rajtszam;
            set => rajtszam = value;
        }

        public string Nev => nev;
        public int Kor => kor;

        private int szepsegPont = 0;
        private int viselkedesPont = 0;

        public int Pontok => szepsegPont + viselkedesPont;

        public Allat(string nev, int kor, int oltasiIgazolás)
        {
            this.nev = nev;
            this.kor = kor;
            this.oltasiIgazolás = oltasiIgazolás;

            if (kor > MaximumEletkor)
                return;

            Random r = new Random();
            szepsegPont = r.Next(PontSzorzo()) - kor;
            viselkedesPont = r.Next(PontSzorzo()) + kor;
        }

        public override string ToString()
        {
            return $"Állat[név: {nev}, pontok: {Pontok}, rajtszám: {rajtszam}]";
        }

        private static int PontSzorzo()
        {
            return MaximumEletkor;
        }
    }
}