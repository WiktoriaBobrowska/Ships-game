using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Manager
    {
        Człowiek gracz1;
        Bot gracz2;
        public Manager()
        {
            gracz1 = new Człowiek();
            gracz2 = new Bot();
            gracz2.ulozlosowo();

            Console.WriteLine("Legenda pól mapy: ");
            Console.WriteLine(" '_' oznacza puste pole \n '+' oznacza pojedynczy maszt statku \n '*' oznacza trafienie w pole, na którym nie ma żadnego statku (pudło) \n 'x' oznacza trafienie w maszt statku \n");
            gracz1.jakułożyćStatki();
            Console.WriteLine();

            Console.WriteLine("Twoje trafienia:");
            gracz1.IleTrafień.Wyswietl();
            

            while(true)
            {
                ruchgracz1();
                Console.Clear();
                ruchgracz2();
                Console.WriteLine(" ");
                Console.WriteLine("Twoje statki:");
                gracz1.Flota.Wyswietl();
                Console.WriteLine(" ");
                Console.WriteLine("Twoje trafienia:");
                gracz1.IleTrafień.Wyswietl();
                Console.WriteLine(" ");
                if (koniecgry() == true) break;
            }
        }


        /*void synchro(byte x, byte y)
        {
            if(gracz2.Flota.mapa[y,x].p == pole.PUSTY) {
                gracz1.IleTrafień.mapa[y, x].p = pole.PUDŁO;
            }

            else if(gracz2.Flota.mapa[y, x].p == pole.OBECNY)
                gracz1.IleTrafień.mapa[y, x].p = pole.TRAFIONY;

            if (gracz1.Flota.mapa[y, x].p == pole.PUSTY)
                gracz2.IleTrafień.mapa[y, x].p = pole.PUDŁO;

            else if (gracz1.Flota.mapa[y, x].p == pole.OBECNY)
                gracz2.IleTrafień.mapa[y, x].p = pole.TRAFIONY;
        }*/

        void ruchgracz1()
        {
            (byte x, byte y) = gracz1.Strzał();
            Statek s = gracz2.Flota.wykonajStrzal(x, y);
            if (s != null) gracz1.IleTrafień.oznacztrafienie(x,y);
            //synchro(x, y);
            if (gracz2.czyzatopiony(s) == true) Console.WriteLine("Statek został zatopiony!");
            if (gracz2.czyzatopionewszystkie() == true) Console.WriteLine("Zatopiłeś wszystkie statki przeciwnika!"); 
        }

        void ruchgracz2()
        {
            (byte x, byte y) = gracz2.Strzał();
            Statek s = gracz1.Flota.wykonajStrzal(x, y);
            if(s != null) gracz2.IleTrafień.oznacztrafienie(x, y);
            //synchro(x, y);
            Console.WriteLine("Ostrzelono Cię w punkcie" + (x,y));
            if (gracz1.czyzatopiony(s) == true) Console.WriteLine("Twój statek został zatopiony!");
            if (gracz1.czyzatopionewszystkie() == true) Console.WriteLine("Przeciwnik zatopił wszystkie Twoje statki!");
        }

        bool koniecgry()
        {
            if (gracz1.czyzatopionewszystkie()==true)
            {
                Console.WriteLine("Przegrałeś! Koniec gry");
                return true;
            }
            else if (gracz2.czyzatopionewszystkie() == true) {
                Console.WriteLine("Wygrałeś! Koniec gry");
                return true;
            }
            return false;
        }
    }
}
