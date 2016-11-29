using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimizacija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Paket> lista; //lista paketa koje treba rasporediti
        int[, ,] tdn; //trodimenzionalni niz u kojem su spremljeni zbrojevi tri paketa
        int[,] matrica; //matrica u kojoj su spremljeni zbrojevi dva paketa
        int napunjeniRedovi = 0; //pomoćna varijabla koja nam govori koliko je redova u listi GotoviRedovi popunjeno
        List<Red> redovi = new List<Red>(); //lista redova u koje se slažu paketi
        List<int> iskoristeni = new List<int>(); /*lista u koju se spremaju indeksi paketa u listi koji su potrebni za
                                                  lakše baratanje objektima*/

        private void Form1_Load(object sender, EventArgs e)
        {
            lista = new List<Paket>(); //prilikom pokretanja forme se inicijalizira lista u koju će se spremati paketi
        }

        private void btnUnos_Click(object sender, EventArgs e) //Kod koji se izvršava klikom na btnUnos
        {
            try
            {
                short n = short.Parse(txtDuzina.Text);//Ukoliko se uspješno parsira varijabli n se dodjeljuje tekst iz txtDuzina
                if (n < 100 || n > 500) //Povjerava se unos
                {
                    MessageBox.Show("Dužine paketa su u rasponu od 100 cm - 500 cm");//ukoliko ne odgovara ispiše se poruka
                    return;  //prekida se izvršavanje koda
                }
                Paket novi = new Paket(n); //inicijalizira se novi objekt klase paket
                lista.Add(novi); //dodaje se u listu paketa
            }
            catch//ukoliko parsiranje nije prošlo
            {
                MessageBox.Show("Krivi unos");
                return;
            }

            lista.Sort(); //sortiraju se podaci u listi
            txtDuzina.Text = "";
            txtDuzina.Focus();
            Ispis(); //ispisuju se podaci iz liste u ListBox
        }

        public void NapuniNizove() 
        {
            foreach (Paket p in lista) //metoda koja puni trodimenzionalni niz
            {
                for (int i = 0; i < lista.Count - 2; i++)
                    for (int j = i + 1; j < lista.Count - 1; j++)
                        for (int k = j + 1; k < lista.Count; k++)
                            tdn[i, j - 1, k - 2] = lista[i].Duzina + lista[j].Duzina + lista[k].Duzina;
            }

            foreach (Paket p in lista)//metoda koja puni matricu
            {
                for (int i = 0; i < lista.Count - 1; i++)
                    for (int j = i + 1; j < lista.Count; j++)
                        matrica[i, j - 1] = lista[i].Duzina + lista[j].Duzina;
            }
        }

        private void btnRačunaj_Click(object sender, EventArgs e)
        {
                
            while (lista.Count > 0 && napunjeniRedovi != 4)//kod se izvršava dok se ne napune svi slobodni redovi
            {
                Red novi = new Red();
                novi.nazivReda = String.Format(" {0} ",napunjeniRedovi + 1); //mijenja se broj paketa da ne počinju s 0
                if (UkupnaDuzina() < 1340 && napunjeniRedovi < 4) //ako preostali paketi stanu u red i postoji nepopunjen red
                {
                    foreach (Paket p in lista) //svi paketi iz liste se dodaju u red
                    {
                        novi.lista.Add(p);
                    }
                    novi.brojPaketa = lista.Count;
                    lista.Clear(); //brisu se paketi koji su prebaceni u red odnosno brisu se svi elementi liste
                }
                else
                {
                    novi.lista.Add(lista[0]);//dodaje se najveci paket u red
                    novi.brojPaketa = 1; //broj paketa u redu se postavlja na 1
                    lista.RemoveAt(0); //paket koji je u redu brise iz liste
                    tdn = new int[lista.Count, lista.Count - 1, lista.Count - 2];
                    matrica = new int[lista.Count, lista.Count - 1];

                    NapuniNizove(); //poziva se metoda za punjenje matrice i trodimenzionalnog niza

                    while (TraziUTDN(novi)) /*ukoliko postoji zbroj duzina tri paketa koji stane u red onda se ta tri
                                             paketa dodaju u red i brisu se iz liste */
                    {
                        novi.lista.Add(lista[iskoristeni[2]]);
                        novi.lista.Add(lista[iskoristeni[1]]);
                        novi.lista.Add(lista[iskoristeni[0]]);
                        lista.RemoveAt(iskoristeni[2]);
                        lista.RemoveAt(iskoristeni[1]);
                        lista.RemoveAt(iskoristeni[0]);
                        NapuniNizove();//ponovno se pune matrica i tdn da ne dode do ponavljanja paketa
                        novi.brojPaketa += 3; //broj paketa
                    }

                    while (TraziUMatrici(novi))/*ukoliko postoji zbroj duzina dva paketa koji stane u red onda se ta dva
                                             paketa dodaju u red i brisu se iz liste */
                    {
                        novi.lista.Add(lista[iskoristeni[1]]);
                        novi.lista.Add(lista[iskoristeni[0]]);
                        lista.RemoveAt(iskoristeni[1]);
                        lista.RemoveAt(iskoristeni[0]);
                        NapuniNizove();//ponovno se pune matrica i tdn da ne dode do ponavljanja paketa
                        novi.brojPaketa += 2; //broj paketa
                    }
                    while (TraziUListi(novi)) /*ukoliko postoji paket koji stane u red onda se dodaje u red i brise 
                                               iz liste */
                    {
                        novi.lista.Add(lista[iskoristeni[0]]);
                        lista.RemoveAt(iskoristeni[0]);
                        novi.brojPaketa++; //broj paketa
                    }
                }
                redovi.Add(novi); //napunjeni red se dodaje u listu redova
                napunjeniRedovi++; //povcava se broja redova
            }

            IspisKraj(); //Ispisuju se popunjeni redovi
            btnRačunaj.Enabled = false; //racunanje je izvrseno i nema potrebe za ponovnim
            Ispis(); //ispisuju se preostali nerasporedeni paketi ukoliko ih ima
            btnBriši.Visible = false; 
            label2.Visible = true;
            btnUnos.Enabled = false;
        }

        public int UkupnaDuzina() //metoda koja vraca zbroj duzina preostalih paketa u listi
        {
            int zbroj=0;
            foreach (Paket p in lista)
                zbroj += p.Duzina;
            return zbroj;
        }

        public bool TraziUTDN(Red novi) //metoda koja vraca postoji li zbroj 3 paketa koji stanu u red i sprema njihove indekse u listu iskoristeni
        {
            int max = 0;
            for (int i = 0; i < lista.Count; i++)
                for (int j = i+1; j < lista.Count-1; j++)
                    for (int k = j+1; k < lista.Count-2; k++)
                    {
                        if (tdn[i, j-1, k-2] < novi.Neiskoristeno()-20 && tdn[i, j, k] > max)
                        {
                            iskoristeni.Clear();
                            max = tdn[i, j, k];
                            iskoristeni.Add(i);
                            iskoristeni.Add(j);
                            iskoristeni.Add(k);
                        }
                    }
            if (max == 0)
                return false;
            return true;
        }

        public bool TraziUMatrici(Red novi) //metoda koja vraca postoji li zbroj 2 paketa koji stanu u red i sprema njihove indekse u listu iskoristeni
        {
            int max = 0;
            for (int i = 0; i < lista.Count; i++)
                for (int j = i+1; j < lista.Count-1; j++)
                    {
                        if (matrica[i, j-1] < novi.Neiskoristeno()-10 && matrica[i, j] > max)
                        {
                            iskoristeni.Clear();
                            max = matrica[i, j];
                            iskoristeni.Add(i);
                            iskoristeni.Add(j);
                        }
                    }
            if (max == 0)
                return false;
            return true;
        }

        public bool TraziUListi(Red novi) //metoda koja vraca postoji li paket koji stanu u red i sprema njegov indeks u listu iskoristeni
        {
            int max=0;
            for (int i=0; i<lista.Count;i++)
            {
                if (lista[i].Duzina < novi.Neiskoristeno() && lista[i].Duzina > max)
                {
                    iskoristeni.Clear();
                    max = lista[i].Duzina;
                    iskoristeni.Add(i);
                }
            }
            if (max == 0)
                return false;
            return true;
        }

        public void IspisKraj() //ispis redova koji su popunjeni
        {
            rtbPaketi.Text = "";
            foreach (Red r in redovi)
            {
                if (r.lista.Count != 0)
                    rtbPaketi.Text += r.ToString();
            }
        }

        public void Ispis() //ispis paketa iz liste u listbox
        {
            lstDuzine.Items.Clear();
            foreach (Paket p in lista)
            {
                lstDuzine.Items.Add(p);
            }
        }

        private void txtDuzina_KeyDown(object sender, KeyEventArgs e) //unos koji je jednak kao i na btnUnos samo sto se izvrsava kada je pritisnuta tipka Enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    short n = short.Parse(txtDuzina.Text);
                    if (n < 100 || n > 500)
                    {
                        MessageBox.Show("Dužine paketa su u rasponu od 100 cm - 500 cm");
                        return;
                    }
                    Paket novi = new Paket(n);
                    lista.Add(novi);
                }
                catch
                {
                    MessageBox.Show("Krivi unos");
                    return;
                }

                lista.Sort();
                txtDuzina.Text = "";
                txtDuzina.Focus();
                Ispis();
            }
        }

        private void btnBriši_Click(object sender, EventArgs e) //brisanje iz liste i ListBoxa
        {
            if (lstDuzine.SelectedIndex != -1)
            {
                lista.RemoveAt(lstDuzine.SelectedIndex);
                Ispis();
            }
        }
    }
}
