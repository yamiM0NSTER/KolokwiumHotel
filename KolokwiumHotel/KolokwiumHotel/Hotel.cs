using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KolokwiumHotel
{
    class Hotel : IHotel, IData
    {
        private SortedDictionary<Pokoj, Gosc> rezerwacje = new SortedDictionary<Pokoj,Gosc>();
        private double zysk = -80;
        private DateTime data;
        private Pokoj ostatniPokoj;
        
        public void DodajRezerwacje(string imie, string nazwisko, int nr, double cena)
        {
            Gosc gosc = new Gosc(imie, nazwisko);
            Pokoj pokoj = new Pokoj(nr, cena);
            if (rezerwacje.Keys.Contains(pokoj))
            {
                MessageBox.Show("Pokój o tym numerze jest już zarezerwowany");
                return;
            }
            zysk += cena;
            rezerwacje.Add(pokoj, gosc);
            ostatniPokoj = pokoj;
        }

        public void OdwolajRezerwacje()
        {
            rezerwacje.Remove(ostatniPokoj);
        }

        public void OdwolajWszystkieRezerwacje()
        {
            while (rezerwacje.Count > 0)
                rezerwacje.Remove(rezerwacje.Last().Key);
        }

        public void UstawDate(DateTime Time)
        {
            data = Time;
        }

        public bool SprawdzDate(DateTime Time)
        {
            if ( DateTime.Compare(data, Time) > 0)//data.CompareTo(Time) < 0)
                return true;
            return false;
        }

        public override string ToString()
        {
            string str = "Rezerwacje:\n\n";
            str += "Data: " + data.Year +"-"+data.Month+"-"+data.Day+ "\n\n";

            if (rezerwacje.Count > 0)
            {
                for (int i = 0; i < rezerwacje.Count; i++)
                {
                    str += "[" + rezerwacje.ElementAt(i).Key.ToString() + "; " + rezerwacje.ElementAt(i).Value.ToString() + "]\n\n";
                }
            }
            else
            {
                str += "Brak gości\n\n";
            }
            str += "Zysk: " + zysk;
            return str;
        }
    }
}
