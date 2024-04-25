using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Main
{
    public class Enemy : Karakter
    {
        
        Random r = new Random();
        public int status = 0;

        public Enemy(ConsoleColor szin, int x, int y)
        {
            
            kinezet = '₳';
            this.szin = szin;
            this.x = x;
            this.y = y;
            status = 0;
            int prevY, prevX;
        }

        
       
        public static Enemy e1 = new Enemy(ConsoleColor.Green, 11, 6);
        public static Enemy e2 = new Enemy(ConsoleColor.Red, 11, 6);
        public static Enemy e3 = new Enemy(ConsoleColor.Magenta, 11, 6);
        public static Enemy e4 = new Enemy(ConsoleColor.DarkBlue, 11, 6);

        public async Task Start(Enemy karakter)
        {
            await Scatter(karakter);
            for(int i = 0; i < 5; i++) {
            await Task.Delay(7000).ContinueWith(_ => Chase(karakter));
            await Task.Delay(20000).ContinueWith(_ => Scatter(karakter));
            }
        }

        public async Task kovesd(int stopStatus, Enemy karakter)
        {
            while (status == stopStatus || Player.p1.pontok < 121 || Player.p1.isAlive)
            {
                if (status == 1 && x == targetX && y == targetY)
                    break;
                await Task.Delay(50);
                if (x == Player.p1.x && y == Player.p1.y)
                {
                    Player.p1.isAlive = false;
                    break;
                }
                await KiutKeres(karakter);
                Thread.Sleep(10);
            }
        }

        public async Task Chase(Enemy karakter) 
        {
            status = 3;
            int targetX = Player.p1.x;
            int targetY = Player.p1.y;
            kovesd(3, karakter);
            
        }

        public async Task Scatter(Enemy karakter)
        {
            status = 1;
            targetX = r.Next(13);
            targetY = r.Next(24);
            kovesd(1, karakter);

        }

        public async Task Flee(Enemy karakter)
        {
            status = 2;
            this.kinezet = '៛';
            Random r = new Random();
            targetX = r.Next(13);
            targetY = r.Next(24);
            kovesd(2, karakter);

        }

        private async Task KiutKeres(Enemy karakter)
        {
            int kiutakSzama = 0;
            Dictionary<string, Boolean> Kiutak = new Dictionary<string, Boolean> { { "fel", false }, { "jobbra", false }, { "le", false }, { "balra", false } };
            if (await Mozgas.NextMezoKeres(y, x + 1) != '#') { 
                Kiutak["jobbra"] = true; kiutakSzama++;
            }
            if (await Mozgas.NextMezoKeres(y, x - 1) != '#')
            {
                Kiutak["balra"] = true;
                kiutakSzama++;
            }
            if (await Mozgas.NextMezoKeres(y - 1, x) != '#') { 
                Kiutak["fel"] = true;
                kiutakSzama++;
            }
            if (await Mozgas.NextMezoKeres(y + 1, x) != '#') { 
                Kiutak["le"] = true;
                kiutakSzama++;
            }
            var Tavolsagok = await LegrovidebbUt(Kiutak, x,y, kiutakSzama);
            await Lepes(Tavolsagok, karakter);
        }


        private async Task<Dictionary<string, int>> LegrovidebbUt(Dictionary<string, Boolean> Kiutak,int x, int y, int kiutakSzama)
        {
            Dictionary<string, int> Tavolsagok = new Dictionary<string, int> { {"jobbra", 100}, { "balra", 100 },{"fel",100 },{ "le",100} };
            
            if (Kiutak["jobbra"] == true)
            {
                if(await VisszaLepesCheck(y, x + 1))
                {
                    if(kiutakSzama == 1)
                        Tavolsagok["jobbra"] = targetX - x;
                }
                else
                    Tavolsagok["jobbra"] = targetX - x;

            }
            if (Kiutak["balra"] == true)
            {
                if (await VisszaLepesCheck(y, x))
                {
                    if (kiutakSzama == 1)
                        Tavolsagok["balra"] = x - targetX;
                }
                else
                    Tavolsagok["balra"] = x - targetX;

            }
            if (Kiutak["fel"] == true)
            {
                if (await VisszaLepesCheck(y - 1 , x))
                {
                    if (kiutakSzama == 1)
                        Tavolsagok["fel"] = targetY - y;
                }
                else
                    Tavolsagok["fel"] = targetY - y;
            }
            if (Kiutak["le"] == true)
            {
                if (await VisszaLepesCheck(y, x))
                {
                    if (kiutakSzama == 1)
                        Tavolsagok["le"] = y - targetY;
                }
                else
                    Tavolsagok["le"] = y - targetY;

            }
            Tavolsagok = Tavolsagok.OrderBy(key => key.Value).ToDictionary(item => item.Key, item => item.Value);
            return Tavolsagok;
        }

        private async Task<bool> VisszaLepesCheck(int y, int x)
        {
            if(x == prevX && y == prevY)
                return true;
            return false;
        }

        private async Task Lepes(Dictionary<string, int> Tavolsagok, Enemy karakter)
        {
            if (Tavolsagok.First().Key == "jobbra")
                await Mozgas.Jobbra(karakter);
            if (Tavolsagok.First().Key == "balra")
                await Mozgas.Balra(karakter);
            if (Tavolsagok.First().Key == "fel")
                await Mozgas.Fel(karakter);
            if (Tavolsagok.First().Key == "le")
                await Mozgas.Le(karakter);
            prevX = x; prevY = y;
        }
    }
}
