using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public static class Mozgas
    {
        private static BlockingCollection<Kiiras> takarit = new BlockingCollection<Kiiras>();
        private static BlockingCollection<Kiiras> kiir = new BlockingCollection<Kiiras>();

        public static async Task enemyStart(Enemy e1, Enemy e2,Enemy e3, Enemy e4) {

            e1.Start(e1);
            Task.Delay(20000).ContinueWith(_ => e2.Start(e2));
            Task.Delay(20000).ContinueWith(_ => e3.Start(e3));
            Task.Delay(20000).ContinueWith(_ => e4.Start(e4));
        }

        private static async Task PontKiiras()
        {
            Console.SetCursorPosition(7, 14);
            Console.Write(Player.p1.pontok);
            Console.SetCursorPosition(Player.p1.x, Player.p1.y);
        }

        private static async Task Kiir(Karakter karakter, int y, int x)
        {
            kiir.Add(new Kiiras(karakter, y, x));
        }

        private static async Task Takarit(Karakter karakter, int y, int x)
        {
            takarit.Add(new Kiiras(karakter, y, x));
        }

        
        public static async Task KonzolKezel()
        {
            while (true) { 
               while(takarit.Count > 0) 
            {
                var adatok = takarit.Take();
                await Takaritas(adatok);
            }
            while (kiir.Count > 0)
            {
                var adatok = kiir.Take();
                await Kiiratas(adatok);
            }
                await PontKiiras();
                Thread.Sleep(50);
            }
        }
       

            private static async Task Kiiratas(Kiiras adatok)
        {
            Console.SetCursorPosition(adatok.y, adatok.x);
            Console.ForegroundColor = adatok.szin;
            Console.Write(adatok.kinezet);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(adatok.y, adatok.x);
        }

        private static async Task Takaritas(Kiiras adatok)
        {
                if (Palya.palya[adatok.x, adatok.y] != '#' && Palya.palya[adatok.x, adatok.y] != '&')
                {
                    Palya.palya[adatok.x, adatok.y] = ' ';
                    Console.SetCursorPosition(adatok.y, adatok.x);
                    if (adatok.kinezet == '℗')
                    {
                        Console.Write(' ');
                    }
                    else if(Palya.palya[adatok.x, adatok.y] == '◦')
                    {
                        Console.Write('◦');
                    }
                    else
                        Console.Write(' ');
                Console.SetCursorPosition(adatok.y, adatok.x);
            }
        }

        public static async Task<int> Jobbra(Karakter karakter)
        {
            int prevX = karakter.x;
            var kovi = await NextMezoKeres(karakter.y, ++karakter.x);
            if (kovi == ' ' || kovi == '◦')
            {
                if (kovi == '◦' && karakter.Equals(Player.p1))
                    Player.p1.pontok++;

                await Takarit(karakter, prevX, karakter.y);
                await Kiir(karakter, karakter.x, karakter.y);
                Thread.Sleep(150);
                return 0;
            }
            else
            {
                karakter.x--;
            }

            if (kovi == '&')
            {
                await Takarit(karakter, prevX, karakter.y);
                Player.p1.x = 1;
                return 0;
            }
            karakter.x--;
            return 1;
        }


        public static async Task<int> Balra(Karakter karakter)
        {
            int kisebb = karakter.x;
            var kovi = await NextMezoKeres(karakter.y, --karakter.x);
            if (kovi == ' ' || kovi == '◦' || kovi == '$')
            {
                if (kovi == '◦' && karakter.Equals(Player.p1))
                    Player.p1.pontok++;

                await Takarit(karakter, kisebb, karakter.y);
                await Kiir(karakter, karakter.x, karakter.y);
                Thread.Sleep(150);
                return 0;
            }
            else
            {
                karakter.x++;
            }

            if (kovi == '&')
            {
                await Takarit(karakter, kisebb, karakter.y);
                Player.p1.x = 21;
                return 0;
            }
            karakter.x++;
            return 1;
        }


        public static async Task<int> Le(Karakter karakter)
        {
            int kisebb = karakter.y;
            var kovi = await NextMezoKeres(++karakter.y, karakter.x);
            if (kovi == ' ' || kovi == '◦')
            {
                if (kovi == '◦' && karakter.Equals(Player.p1))
                    Player.p1.pontok++;

                await Takarit(karakter, karakter.x, kisebb);
                await Kiir(karakter, karakter.x, karakter.y);
                Thread.Sleep(200);
                return 0;
            }

            karakter.y--;
            return 1;
        }



        public static async Task<int> Fel(Karakter karakter)
        {
            int nagyobb = karakter.y;
            var kovi = await NextMezoKeres(--karakter.y, karakter.x);

            if (kovi != '#')
            {
                if (kovi == '◦' && karakter.Equals(Player.p1))
                    Player.p1.pontok++;

                await Takarit(karakter, karakter.x, nagyobb);
                await Kiir(karakter, karakter.x, karakter.y);
                Thread.Sleep(200);
                return 0;
            }

            karakter.y++;
            return 1;
        }

        public static async Task<char> NextMezoKeres(int y, int x)
        {
            return Palya.palya[y,x];
        }
    }
}
