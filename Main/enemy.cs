using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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

        public async Task kovesd(int stopStatus, int targetX, int targetY) {

            int prevY = 0;
            int prevX = 0;
            while (status == stopStatus || Player.p1.pontok < 121 || Player.p1.isAlive)
            {
                if (x == Player.p1.x && y == Player.p1.y)
                {
                    Player.p1.isAlive = false;
                    break;
                }

                if (x > targetX && Palya.palya[y, x - 1] != '#' && (prevX != x - 1 && prevY != y))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Balra(this);
                }
                else if (x < targetX && Palya.palya[y, x + 1] != '#' && (prevX != x + 1 && prevY != y))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Jobbra(this);
                }
                else if (y > targetY && Palya.palya[y - 1, x] != '#' && (prevY != y - 1 && prevX != x))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Le(this);
                }
                else if (y < targetY && Palya.palya[y + 1, x] != '#' && (prevY != y + 1 && prevX != x))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Fel(this);
                }
                else if (Palya.palya[y + 1, x] != '#' && (prevY != y + 1 && prevX != x))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Fel(this);
                }
                else if (Palya.palya[y - 1, x] != '#' && (prevY != y - 1 && prevX != x))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Le(this);
                }
                else if (Palya.palya[y, x + 1] != '#' && (prevX != x + 1 && prevY != y))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Jobbra(this);
                }
                else if (Palya.palya[y, x - 1] != '#' && (prevX != x - 1 && prevY != y))
                {
                    prevX = x;
                    prevY = y;
                    await Mozgas.Balra(this);
                }
                else {
                    switch (status)
                    {
                        case 1:
                            Scatter();
                            break;
                        case 2:
                            Flee();
                            break;
                        case 3:
                            Chase();
                            break;
                        default:
                            break;
                    }
                    // ezekre nem kell await, nem akarjuk megvárni hogy lefussanak
                }
            }
        }

        public async Task Chase() 
        {
            status = 3;
            int targetX = Player.p1.x;
            int targetY = Player.p1.y;
            kovesd(3, targetX, targetY);
            
        }
        public async Task Scatter()
        {
            status = 1;
            Random r = new Random();
            int targetX = r.Next(13);
            int targetY = r.Next(24);
            kovesd(1, targetX, targetY);
        }

        public async Task Flee()
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
