using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public abstract class Karakter
    {
        //koordinatak
        public int x, y, prevX,prevY, targetX, targetY;
        public ConsoleColor szin;
        public char kinezet;

    }
}
