using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Enemy : Karakter
    {
        public Enemy(ConsoleColor szin)
        {
            kinezet = '₳';
            this.szin = szin;
             x = 11;
             y = 6;
        }

        public async void Menekul()
        {
            while (true) { 
            this.kinezet = '៛';
            Thread.Sleep(150);
            this.kinezet = '₳';
            }
        }
    }
}
