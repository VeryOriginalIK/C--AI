using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public async void Chase() { }
        public async void Scatter() { }


        public async void Flee()
        {
            this.kinezet = '៛';
            
        }
    }
}
