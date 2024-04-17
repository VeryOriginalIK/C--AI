using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Step {
        public int X;
        public int Y;
        public int F { get { return G + H; } }
        public int G { get { return pathfinding.getGErtek(X, Y); } }
        public int H;
        public Step? Parent;
    }

    public static class pathfinding
    {
        public static string[] GetShortestPath(int tagX, int tagY, Karakter karakter) {
            char[,] map = Palya.palya;
            Step start = new Step() { X = karakter.x, Y=karakter.y};
            Step target = new Step() { X = tagX, Y = tagY };
            var openList = new List<Step>();
            var closedList = new List<Step>();
            int g = 0;
            openList.Add(start);
            return null;
            do
            {

            } while (!(openList.Count == 0));
        }

        public static int getHErtek(int targetX, int targetY, int karakterX, int karakterY) {
            return 0;
        }

        public static int getGErtek(int currentX, int currentY) {
            return 0;
        }
    }
}
