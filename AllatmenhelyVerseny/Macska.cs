namespace AllatmenhelyVerseny {
    public class Macska: Allat {
        private bool vanDoboz;

        public bool VanDoboz
        {
            get => vanDoboz;
            set => vanDoboz = value;
        }

        public Macska(string nev, int kor, int oltasiIgazolás, bool vanDoboz) : base(nev, kor, oltasiIgazolás)
        {
            this.vanDoboz = vanDoboz;
        }

        public override void Pontoz()
        {
            if (!vanDoboz)
                return;

            base.Pontoz();
        }
    }
}