using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumHotel
{
    class Pokoj : IComparable<Pokoj>
    {
        private int nrPokoju;
        private double cenaZaDzien;

        public Pokoj(int nr, double cena)
        {
            this.nrPokoju = nr;
            this.cenaZaDzien = cena;
        }

        public override string ToString()
        {
            return "Pokój, nr: " + this.nrPokoju + ", cena za dzień: " + this.cenaZaDzien;
        }

        public int PodajNumer()
        {
            return this.nrPokoju;
        }

        public double PodajCene()
        {
            return this.cenaZaDzien;
        }

        public int CompareTo(Pokoj obj)
        {
            if (this.nrPokoju < obj.nrPokoju)
                return -1;
            if (this.nrPokoju > obj.nrPokoju)
                return 1;

            return 0;
        }
    }
}
