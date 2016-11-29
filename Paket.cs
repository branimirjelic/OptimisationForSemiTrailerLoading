using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizacija
{
    public class Paket : IComparable //klasa Paket koja nasljeđuje interface IComprable, koji je potreban za override metodu CompareTo(), i ima jedno polje i svojstvo
    {
        private int duzina; 

        public int Duzina
        {
            get { return duzina; }
            set { duzina = value; }
        }

        public Paket(int d) //preopterećeni konstruktor koji prima duzinu paketa
        {
            Duzina = d;
        }


        int IComparable.CompareTo(object pak) //override metode CompareTo() koja nm je potrebna za sortiranje paketa od najveceg do najmanjeg
        {
            Paket temp = (Paket)pak;
            if (this.duzina > temp.duzina)
                return -1;
            if (this.duzina < temp.duzina)
                return 1;
            return 0;
        }

        public override string ToString() //override metode ToString()
        {
            return this.duzina.ToString()+" ";
        }

        public Paket()
        {
        }
    }

    public class Red //klasa red koja predstavlja jedan red u tovarnom prostoru kamiona
    {
        public List<Paket> lista = new List<Paket>(); //lista u kojoj ce se pohranjivati paketi koji se nalaze u tom redu
        public int brojPaketa;
        public string nazivReda;

        public int DuzinaReda() //metoda koja vraca duzinu iskoristenog prostora u redu
        {
            int d=0;
            for (int i = 0; i < lista.Count; i++)
                d += lista[i].Duzina;
            return d;
        }

        public int Neiskoristeno() //metoda koja vraca preostalu neiskoristenu duzinu
        {
            return 1340 - DuzinaReda()- brojPaketa*10;
        }

        public override string ToString() //override metode ToString() za ispis reda
        {
            int t = 0;
            string vrati = "Broj reda: " + this.nazivReda + "\nDuzine paketa:\t";
            foreach (Paket p in lista)
            {
                t = p.Duzina;
                vrati += t+" ";
            }
            vrati += String.Format("\tNeiskorišten prostor: {0}\n", this.Neiskoristeno()+20);

            return vrati;
        }
    }
}
