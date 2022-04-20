using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Interfejs
    {
        protected Człowiek gracz1;
        protected Bot AI;

       /* public bool czy_człowiek()
        {
            Console.WriteLine("Wybierz rozgrywkę, wybierając odpowiedni numer: ");
            Console.WriteLine("1. gracz vs gracz, 2. gracz vs komputer");
            int wybor = Convert.ToInt16(Console.ReadLine());

            do
            {
                if (wybor == 1) return true;
                else if (wybor == 2) return false;
            } while (wybor == 2 && wybor == 1);

            return false;
        }*/

        public bool jakułóżyćStatki()
        {
            Console.WriteLine("Czy chcesz samodzielnie rozstawić statki? (T/N)");
            string odpowiedź = Console.ReadLine();
            if (odpowiedź[0] == 'T' || odpowiedź[0] == 't') return true;
            else if (odpowiedź[0] == 'N' || odpowiedź[0] == 'n') return false;
            else return false;
        }

        public byte rozłożenie(byte rozmiarS)
        {
            Console.WriteLine("Wybierz rozłożenie statku" + rozmiarS + "masztowego. Za pomocą wciśnięcie odpowiedniego klawisza: [1/2]");
            Console.WriteLine("1. W pionie");
            Console.WriteLine("2. W poziomie");

            byte wybór;
            while (true)
            {
                wybór = byte.Parse(Console.ReadLine());
                if (wybór == 1) return 1;
                else if (wybór == 2) return 2;
                else Console.WriteLine("Nieprawidłowe dane! Proszę wybrać jeszcze raz: ");
            }
        }
        public kierunek ustawpozycje(byte pozycja)
        {
            kierunek k;
            if (pozycja == 1) k = kierunek.PIONOWO;
            else k = kierunek.POZIOMO;

            return k;
        }
        public byte setwiersz()
        {
            Console.WriteLine("Podaj wiersz: ");
            byte wybór;
            do
            {
                wybór = byte.Parse(Console.ReadLine());
            } while (wybór <= 0 && wybór > 10);

            return wybór;
        }
        public byte setkolumna()
        {
            Console.WriteLine("Podaj kolumnę: ");
            byte wybór;
            do
            {
                wybór = byte.Parse(Console.ReadLine());
            } while (wybór <= 0 && wybór > 10);

            return wybór;
        }
        public void jakułożyćStatki(bool jakułożyćStatki)
        {
            if (jakułożyćStatki == true)
            {
                for (int i = 0; i < gracz1.RozmiaryS.Length; i++)
                {
                    kierunek k = ustawpozycje(rozłożenie(gracz1.RozmiaryS[i]));
                    byte x = setwiersz();
                    byte y = setkolumna();
                    Statek s = new Statek(k, x, y, gracz1.RozmiaryS[i]);
                    if (gracz1.Flota.czymoznaumiescic(s) == true)
                    {
                        gracz1.Statki.Add(s);
                        break;
                    }
                }
            }
            else if (jakułożyćStatki == false)
            {
                gracz1.ulozlosowo();
            }
        }
    }
}
