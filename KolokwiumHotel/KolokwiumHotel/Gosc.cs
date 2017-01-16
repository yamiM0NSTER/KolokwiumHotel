using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolokwiumHotel
{
    class Gosc
    {
        private string imie;
        private string nazwisko;

        public Gosc(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public override string ToString()
        {
            return "Gość, " + this.imie + " " + this.nazwisko;
        }

    }
}
