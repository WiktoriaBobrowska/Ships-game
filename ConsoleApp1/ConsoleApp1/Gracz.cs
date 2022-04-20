using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class Gracz
    {
        protected Plansza flota; //plansza gracza ze statkami
        protected Plansza ileTrafień; //plansza przeciwnika
        protected List<Statek> statki;
        protected byte[] rozmiaryStatków = { 6, 4, 4, 3, 3, 2, 2 };

        public Gracz()
        {
            statki = new List<Statek>();
            flota = new Plansza(10);
            ileTrafień = new Plansza(10);
        }
        public byte[] RozmiaryS { get { return rozmiaryStatków; } }
        public List<Statek> Statki { get { return statki; } }
        public Plansza Flota { get { return flota; } }
        public Plansza IleTrafień { get { return ileTrafień; } }
        public abstract (byte, byte) Strzał();
       

        /* Na planszach 10 na 10 przyjmuje się, że każdy z graczy dysponuje flotą złożoną z:
         jednego czteromasztowca o wielkości czterech kratek
         dwóch trójmasztowców o wielkości trzech kratek
         trzech dwumasztowców o wielkości dwóch kratek 
         cztery jednomasztowców o wielkości jednej kratki.*/

        /*dwa dwumasztowe, 2 trzy masztowe i 2 czteromasztowe*/

        public void ulozlosowo()
        {
             Random r = new Random();
             kierunek k;
             int x, y;
             for (int i = 0; i < rozmiaryStatków.Length; i++)
             {
                 while (true)
                 {
                     x = r.Next(10);
                     y = r.Next(10);

                     if (r.Next(2) == 0) k = kierunek.PIONOWO;
                     else k = kierunek.POZIOMO;

                     Statek s = new Statek(k, (byte)x, (byte)y, rozmiaryStatków[i]);
                     if (flota.czymoznaumiescic(s) == true) {
                         Statki.Add(s);
                         break;
                     } 
                     else continue;
                 }
             }
        }

        public bool czyzatopiony(Statek s)
        {
            if (s==null) return false;

            int Rozmiar2 = 0;
            for(int i = 0; i < s.Rozmiar; i++)
            {
                if (s.Maszty[i] == true) Rozmiar2++;
            }
            if(s.Rozmiar == Rozmiar2)
            {
                Statki.Remove(s);
                Console.WriteLine("Twój statek został zatopiony!");
                return true;
            }
            else return false;
        }

        public Statek odbierztrafienie(byte y, byte x)
        {
            return flota.wykonajStrzal(y, x);
        }

        public bool czyzatopionewszystkie()
        {
            if (Statki.Count == 0) return true;
            else return false;
        }


    }
}


