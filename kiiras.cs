using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Kiiras
    {
        public int x, y;
        public ConsoleColor szin;
        public char kinezet;


        public Kiiras(Karakter karakter, int y, int x)
        {
            this.kinezet = karakter.kinezet;
            this.x = x;
            this.y = y;
            this.szin = karakter.szin;
        }
    }
}
