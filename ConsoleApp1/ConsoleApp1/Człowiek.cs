using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Człowiek : Gracz
    {
        public Człowiek() : base() { }

        public override (byte, byte) Strzał()
        {
            Console.WriteLine("Wykonaj strzał: ");
            Random r = new Random();
            byte x, y;

            while (true)
            {
                Console.WriteLine("kolumna: ");
                x = byte.Parse(Console.ReadLine());
                Console.WriteLine("wiersz: ");
                y = byte.Parse(Console.ReadLine());

                if (ileTrafień.zaznaczStrzal(x, y).zostałowykonane == false)
                {
                    Console.WriteLine("Nie można wykonać strzału w to samo miejsce. Spróbuj ponownie: ");
                    continue;
                }
                else break;
            }
            (byte, byte) strzał = (x, y);
            return strzał;
        }
        bool jakułożyćStatkiinner()
        {
            Console.WriteLine("Czy chcesz samodzielnie rozstawić statki? (T/N)");
            string odpowiedź = Console.ReadLine();
            if (odpowiedź[0] == 'T' || odpowiedź[0] == 't') return true;
            else if (odpowiedź[0] == 'N' || odpowiedź[0] == 'n') return false;
            else return false;
        }

        public byte rozłożenie(byte rozmiarS)
        {
            Console.WriteLine("Wybierz rozłożenie statku" + " " + rozmiarS + " " + "masztowego. Za pomocą wciśnięcie odpowiedniego klawisza: [1/2]");
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
        public void jakułożyćStatki()
        {
            bool wybór = jakułożyćStatkiinner();
            if (wybór == true)
            {
                for (int i = 0; i < RozmiaryS.Length; i++)
                {
                    while (true)
                    {
                        kierunek k = ustawpozycje(rozłożenie(RozmiaryS[i]));
                        byte y = setwiersz();
                        byte x = setkolumna();
                        Statek s = new Statek(k, x, y, RozmiaryS[i]);
                        if (Flota.czymoznaumiescic(s) == true)
                        {
                            Statki.Add(s);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawne miejsce położenia statku. Spróbuj ponownie.");
                            continue;
                        }
                    }
                    Flota.Wyswietl();
                }
            }
            else if (wybór == false)
            {
                ulozlosowo();
                Console.WriteLine("Twoje statki:");
                Flota.Wyswietl();
            }
        }
    }
}
 