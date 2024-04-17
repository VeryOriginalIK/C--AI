using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Player : Karakter
    {
        public static Player p1 = new Player();

        public int pontok;

        public Player()
        {
            kinezet = '℗';
            szin = ConsoleColor.Yellow;
            x = 11;
            y = 11;
            this.pontok = 0;
        }

        private static void PontKiiras()
        {
            Console.SetCursorPosition(8, 14);
            Console.Write(p1.pontok);
            Console.SetCursorPosition(p1.x, p1.y);
        }

        public void Menj(char[,] palya)
        {
            var nyil = Console.ReadKey().Key;
            while (p1.pontok < 121)
            {

                if (!Console.KeyAvailable)
                {
                    nyil = Console.ReadKey(true).Key;
                }
                //Checkelni kell, hogy nem mész falba az adott esetben. Különben nem változtatsz semmit.
                switch (nyil)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            int eredmeny = 0;
                            do
                            {
                                eredmeny = Mozgas.Balra(p1);
                                PontKiiras();
                            }
                            while (!(Console.KeyAvailable && Console.ReadKey(true).Key != ConsoleKey.LeftArrow) && eredmeny == 0);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            int eredmeny = 0;
                            do
                            {
                                eredmeny = Mozgas.Jobbra(p1);
                                PontKiiras();
                            }
                            while (!(Console.KeyAvailable && Console.ReadKey(true).Key != ConsoleKey.RightArrow) && eredmeny == 0);

                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            int eredmeny = 0;
                            do
                            {
                                eredmeny = Mozgas.Le(p1);
                                PontKiiras();
                            }
                            while (!(Console.KeyAvailable && Console.ReadKey(true).Key != ConsoleKey.DownArrow) && eredmeny == 0);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            int eredmeny = 0;
                            do
                            {
                                eredmeny = Mozgas.Fel(p1);
                                PontKiiras();
                            }
                            while (!(Console.KeyAvailable && Console.ReadKey(true).Key != ConsoleKey.UpArrow) && eredmeny == 0);
                            break;
                        }
                }

            }
        }
    }
}