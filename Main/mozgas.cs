using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public static class Mozgas
    {

        private static void Kiir(Karakter karakter, int y, int x )
        {
            Console.SetCursorPosition(y,x);
            Console.ForegroundColor = karakter.szin;
            Console.Write(karakter.kinezet);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(y, x);
        }

        private static void Takarit(int y, int x)
        {
            if (Palya.palya[x,y] != '#' && Palya.palya[x, y] != '&')
            {
                Palya.palya[x, y] = ' ';
                Console.SetCursorPosition(y, x);
                Console.Write(' ');
            }
        }

        public static int Jobbra(Karakter karakter)
        {

                int prevX = karakter.x;
                var kovi = Palya.palya[karakter.y, ++karakter.x];
                if (kovi == ' ' || kovi == '◦')
                {
                    if (kovi == '◦' && karakter.Equals(Player.p1))
                        Player.p1.pontok++;
                    Takarit(prevX, karakter.y);
                    Kiir(karakter, karakter.x, karakter.y);
                    Thread.Sleep(150);
                    return 0;
                }
                else
                    karakter.x--;

                //teleport a szélén
                if (kovi == '&')
                {
                    Takarit(prevX, karakter.y );
                    Player.p1.x = 1;
                    return 0;
                }
                else
                {
                    Kiir(karakter, karakter.x, karakter.y); Thread.Sleep(150); 

                }
            return 1;
        }

        public static int Balra(Karakter karakter)
        {

            int kisebb = karakter.x;
            var kovi = Palya.palya[karakter.y, --karakter.x];
            if (kovi == ' ' || kovi == '◦')
            {
                if (kovi == '◦' && karakter.Equals(Player.p1))
                    Player.p1.pontok++;
                Takarit(kisebb, karakter.y);
                Kiir(karakter, karakter.x, karakter.y);
                Thread.Sleep(150);
                return 0;
            }
            else 
                karakter.x++;
            
            //teleport a szélén
            if (Palya.palya[karakter.y, --karakter.x] == '&')
            {
                Takarit(kisebb, karakter.y);
                Player.p1.x = 21;
                return 0;
            }
            else {
                karakter.x++;
                Kiir(karakter, karakter.x, karakter.y);
             Thread.Sleep(150);
                }
                return 1;     
        }

        public static int Le(Karakter karakter)
        {
                int kisebb = karakter.y;

                var kovi = Palya.palya[++karakter.y, karakter.x];
                if (kovi == ' ' || kovi == '◦')
                {
                    if (kovi == '◦' && karakter.Equals(Player.p1))
                        Player.p1.pontok++;
                    Takarit(karakter.x, kisebb);
                    Kiir(karakter, karakter.x, karakter.y);
                    Thread.Sleep(200);
                     return 0;
                }
            karakter.y--;
            Kiir(karakter, karakter.x, karakter.y);
            return 1;
        }
   

        public static int Fel(Karakter karakter)
        {

            int nagyobb = karakter.y;
            var kovi = Palya.palya[--karakter.y, karakter.x];
            if (kovi == ' ' || kovi == '◦')
            {
                if (kovi == '◦' && karakter.Equals(Player.p1))
                    Player.p1.pontok++;
                    Takarit(karakter.x, nagyobb);
                    Kiir(karakter, karakter.x, karakter.y);
                    Thread.Sleep(200);
                    return 0;
                }

            Thread.Sleep(150);
            karakter.y++;
            Kiir(karakter, karakter.x, karakter.y);
            return 1;
        }
    }
}
