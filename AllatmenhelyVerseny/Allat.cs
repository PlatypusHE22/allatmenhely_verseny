using System;
using System.Runtime.InteropServices;

namespace AllatmenhelyVerseny {
    abstract public class Allat {
        protected static Random r = new Random();
        public static int MaximumEletkor = 0;

        protected string nev;
        protected int kor;
        protected int rajtszam = 0;
        protected int oltasiIgazolás;

        public int Rajtszam
        {
            get => rajtszam;
            set => rajtszam = value;
        }

        public string Nev => nev;
        public int Kor => kor;

        protected int szepsegPont = 0;
        protected int viselkedesPont = 0;

        public int Pontok => szepsegPont + viselkedesPont;

        public Allat(string nev, int kor, int oltasiIgazolás)
        {
            this.nev = nev;
            this.kor = kor;
            this.oltasiIgazolás = oltasiIgazolás;
        }

        public virtual void Pontoz()
        {
            if (kor > MaximumEletkor)
                return;

            szepsegPont = r.Next(PontSzorzo()) - kor;
            viselkedesPont = r.Next(PontSzorzo()) + kor;
        }

        public override string ToString()
        {
            return $"{rajtszam}, {nev}, {Pontok}";
        }

        public static int PontSzorzo()
        {
            return MaximumEletkor;
        }
    }
}