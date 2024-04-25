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

        public bool isAlive;

        public Player()
        {
            kinezet = '℗';
            szin = ConsoleColor.Yellow;
            x = 11;
            y = 11;
            this.pontok = 0;
            isAlive = true;
        }

        private static ConsoleKey nyil;

        private static async Task Beker()
        {
            await Task.Run(() => nyil = nyil = Console.ReadKey(true).Key);
            
        }

        public async Task Menj(char[,] palya)
        {
                switch (nyil)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            int eredmeny = 0;
                            do
                        {
                            eredmeny = await Mozgas.Balra(p1);
                                Beker();

                            Thread.Sleep(50);
                        }
                            while (!(nyil != ConsoleKey.LeftArrow) && eredmeny == 0);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            int eredmeny = 0;
                            do
                            {

                            eredmeny = await Mozgas.Jobbra(p1);
                                Beker();

                            Thread.Sleep(50);
                        }
                            while (!(nyil != ConsoleKey.RightArrow) && eredmeny == 0);
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            int eredmeny = 0;
                        do {
                            eredmeny = await Mozgas.Le(p1);
                            Beker();
Thread.Sleep(50);
                        }
                            while (!(nyil != ConsoleKey.DownArrow) && eredmeny == 0);
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            int eredmeny = 0;
                            do
                        {
                            Player.p1.prevY = p1.y;
                            Player.p1.prevX = p1.x;
                            eredmeny = await Mozgas.Fel(p1);
                                Beker();

                            Thread.Sleep(50);
                        }
                            while (!( nyil != ConsoleKey.UpArrow) && eredmeny == 0);
                            break;
                        }
                }
            Beker();
        }
        }

    }
