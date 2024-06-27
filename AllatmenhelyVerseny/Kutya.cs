using System;

namespace AllatmenhelyVerseny {
    public class Kutya: Allat {
        private int viszonypont;

        public Kutya(string nev, int kor, int oltasiIgazolás): base(nev, kor, oltasiIgazolás)
        {
            viszonypont = r.Next(PontSzorzo());
        }

        public override void Pontoz()
        {
            if (viszonypont <= 0)
                return;

            base.Pontoz();
            szepsegPont += viszonypont;
            viselkedesPont += viszonypont;
        }
    }
}