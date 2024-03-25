using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Player : Karakter
    {
        public Player()
        {
            this.kinezet = 'ᗧ';
            this.x = 10;
            this.y = 11;
        }

        public void Menj(char[,] palya)
        {
            var nyil = Console.ReadKey(true).Key;
            //Checkelni kell, hogy nem mész falba az adott esetben. Különben nem változtatsz semmit.
            switch (nyil)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (palya[y, x--] == ' ')
                            x--;
                        if (palya[y, x--] == '&')
                            x = 21;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (palya[y, x++] == ' ')
                            x++;
                        //teleport a szélén
                        if (palya[y, x++] == '&')
                            x = 0;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if (palya[y++, x] == ' ')
                            y++;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (palya[y--, x] == ' ')
                            y--;
                    }
            }
        }
    }
}