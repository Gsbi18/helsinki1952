using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace helsinki1952
{
    class olimpia_adatok
    {
        public int helyezes;
        public int csapatmeret;
        public string sportag;
        public string versenyszam;
        public olimpia_adatok(string sor)
        {

            string[] adatok = sor.Split(' ');
            this.helyezes = int.Parse(adatok[0]);
            this.csapatmeret = int.Parse(adatok[1]);
            this.sportag = adatok[2];
            this.versenyszam = adatok[3];
        }
    }
    class Program
    {
        static List<olimpia_adatok> olimpia_adat = new List<olimpia_adatok>();
        public static void beolvas(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);
            string sor;

            while ((sor=sr.ReadLine())!= null)
            {
                olimpia_adat.Add(new olimpia_adatok(sor));
            }
        }
        static void Main(string[] args)
        {
            beolvas("helsinki.txt");
            Console.WriteLine("3.Feladat:\nPontszerző helyezések száma:" + olimpia_adat.Count());
            int arany = 0;
            int ezust = 0;
            int bronz = 0;
            foreach (var item in olimpia_adat)
            {
                if (item.helyezes==1) { arany++; }
                else if (item.helyezes == 2) { ezust++; }
                else if (item.helyezes == 3) { bronz++; }
            }
            Console.WriteLine("4.Feladat:\nArany: {0}\nEzüst: {1}\nBronz: {2}\nÖsszesen: {3}",arany,ezust,bronz,arany+ezust+bronz);
            int osszpont = 0;
            foreach (var item in olimpia_adat)
            {
                if (item.helyezes == 1) { osszpont += 7; }
                else if (item.helyezes == 2) { osszpont += 5; }
                else if (item.helyezes == 3) { osszpont += 4; }
                else if (item.helyezes == 4) { osszpont += 3; }
                else if (item.helyezes == 5) { osszpont += 2; }
                else if (item.helyezes == 6) { osszpont += 1; }
            }
            Console.WriteLine("5.Feladat:\nOlimpiasi pontok száma:" + osszpont);
            int torna = 0;
            int uszas = 0;
            foreach (var item in olimpia_adat)
            {
                if (item.sportag == "torna" && item.helyezes<=3) { torna++; }
                else if(item.sportag == "uszas" && item.helyezes <= 3) { uszas++; }
            }
            if (uszas>torna ) {Console.WriteLine("6.Feladat:\nÚszás sportágban szereztek több érmet");}
            else if (uszas<torna) {Console.WriteLine("6.Feladat:\nTorna sportágban szereztek több érmet");}
            else if (uszas==torna) {Console.WriteLine("6.Feladat:\nEgyenlö volt az érmek száma");}
            foreach (var item in olimpia_adat)
            {
                if (item.sportag=="kajakkenu")
                {
                    item.sportag = "kajak-kenu";
                }
            }
            StreamWriter iro = new StreamWriter("helsinki2.txt", false, Encoding.Default);
            
            foreach (var item in olimpia_adat)
            {
                int pont;
                if (item.helyezes == 1) { pont = 7; }
                else if (item.helyezes == 2) { pont = 5; }
                else if (item.helyezes == 3) { pont = 4; }
                else if (item.helyezes == 4) { pont = 3; }
                else if (item.helyezes == 5) { pont = 2; }
                else if (item.helyezes == 6) { pont = 1; }
                else { pont = 0; }
                iro.WriteLine(item.helyezes + " " + item.csapatmeret + " " + pont + " "+ item.sportag + " " + item.versenyszam);
            }
            iro.Close();
            int legtobbember = 0;
            for (int i = 0; i < olimpia_adat.Count; i++)
            {
                if (olimpia_adat[i].csapatmeret>olimpia_adat[legtobbember].csapatmeret)
                {
                    legtobbember = i;
                }
            }
            Console.WriteLine("8.Feladat:\nHelyezás: {0}\nSportág: {1}\nVersenyszám: {2}\nSportolók száma : {3}", olimpia_adat[legtobbember].helyezes, olimpia_adat[legtobbember].sportag, olimpia_adat[legtobbember].versenyszam, olimpia_adat[legtobbember].csapatmeret);

        }
    }
}
