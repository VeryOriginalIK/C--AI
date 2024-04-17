using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Main
{
    internal class Enemy : Karakter
    {
        public Enemy(ConsoleColor szin, int x, int y)
        {
            kinezet = '₳';
            this.szin = szin;
            this.x = x;
            this.y = y;
        }

        public async void Start()
        {
            Scatter();
            Task.Delay(7000).ContinueWith(_ => Chase());
            Task.Delay(20000).ContinueWith(_ => Scatter());
            Task.Delay(7000).ContinueWith(_ => Chase());
            Task.Delay(20000).ContinueWith(_ => Scatter());
            Task.Delay(7000).ContinueWith(_ => Chase());
            Task.Delay(20000).ContinueWith(_ => Scatter());
            Task.Delay(7000).ContinueWith(_ => Chase());




            while (Player.p1.pontok < 122)
            {
            }
        }

        public async void Chase() 
        {
            int targetX = Player.p1.x;
            int targetY = Player.p1.y;
        }
        public async void Scatter() 
        {
            Random r = new Random();
            int targetX = r.Next(13);
            int targetY = r.Next(24);
        }


        public async void Flee()
        {
            this.kinezet = '៛';
            Random r = new Random();
            int targetX = r.Next(13);
            int targetY = r.Next(24);
        }
    }
}
