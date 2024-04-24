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

        public int status = 0;

        public Enemy(ConsoleColor szin, int x, int y)
        {
            kinezet = '₳';
            this.szin = szin;
            this.x = x;
            this.y = y;
            status = 0;
        }

        public async Task Start()
        {
            Scatter();
            await Task.Delay(7000).ContinueWith(_ => Chase());
            await Task.Delay(20000).ContinueWith(_ => Scatter());
            await Task.Delay(7000).ContinueWith(_ => Chase());
            await Task.Delay(20000).ContinueWith(_ => Scatter());
            await Task.Delay(7000).ContinueWith(_ => Chase());
            await Task.Delay(20000).ContinueWith(_ => Scatter());
            await Task.Delay(7000).ContinueWith(_ => Chase());
        }

        public async void kovesd(int stopStatus, int targetX, int targetY) {
            while (status == stopStatus || Player.p1.pontok < 121 || Player.p1.isAlive)
            {
                if (x == Player.p1.x && y == Player.p1.y)
                {
                    Player.p1.isAlive = false;
                }

                if (x > targetX && Palya.palya[y, x - 1] != '#')
                {
                    await Mozgas.Balra(this);
                }
                else if (x < targetX && Palya.palya[y, x + 1] != '#')
                {
                    await Mozgas.Jobbra(this);
                }
                else if (y > targetY && Palya.palya[y - 1, x] != '#')
                {
                    await Mozgas.Le(this);
                }
                else if (y < targetY && Palya.palya[y + 1, x] != '#')
                {
                    await Mozgas.Fel(this);
                }
                else if (Palya.palya[y + 1, x] != '#')
                {
                    await Mozgas.Fel(this);
                }
                else if (Palya.palya[y - 1, x] != '#')
                {
                    await Mozgas.Le(this);
                }
                else if (Palya.palya[y, x + 1] != '#') {
                    await Mozgas.Jobbra(this);
                } else {
                    await Mozgas.Balra(this);
                }
            }
        }

        public async void Chase() 
        {
            status = 3;
            int targetX = Player.p1.x;
            int targetY = Player.p1.y;
            kovesd(3, targetX, targetY);
            
        }
        public async void Scatter()
        {
            status = 1;
            Random r = new Random();
            int targetX = r.Next(13);
            int targetY = r.Next(24);
            kovesd(1, targetX, targetY);

        }


        public async void Flee()
        {
            status = 2;
            this.kinezet = '៛';
            Random r = new Random();
            int targetX = r.Next(13);
            int targetY = r.Next(24);

            kovesd(2, targetX, targetY);

        }
    }
}
