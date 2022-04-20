using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Bot : Gracz
    {
        public Bot() : base() { }

        public override (byte, byte) Strzał()
        {
            Random r = new Random();
            byte x, y;

            while (true)
            {
                x = (byte)r.Next(10);
                y = (byte)r.Next(10);

                if (ileTrafień.zaznaczStrzal(x, y).zostałowykonane == false) continue;
                else break;
            }
            (byte, byte) strzał = (x, y);
            return strzał;
        }
    }
}
