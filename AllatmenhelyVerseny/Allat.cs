using System;

namespace AllatmenhelyVerseny {
    public class Allat {
        public static int MaximumEletkor = 0;

        private string nev;
        private int kor;

        private int szepsegPont = 0;
        private int viselkedesPont = 0;

        public int Pontok => szepsegPont + viselkedesPont;

        public Allat(string nev, int kor)
        {
            this.nev = nev;
            this.kor = kor;

            if (kor > MaximumEletkor)
                return;

            Random r = new Random();
            szepsegPont = r.Next(PontSzorzo()) - kor;
            viselkedesPont = r.Next(PontSzorzo()) + kor;
        }

        public override string ToString()
        {
            return $"Állat[név: {nev}, pontok: {Pontok}]";
        }

        private static int PontSzorzo()
        {
            return MaximumEletkor;
        }
    }
}