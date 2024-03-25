// See https://aka.ms/new-console-template for more information
using Main;

var palya = Palya.Letrehoz();
var p1 = new Player();
var enemies = Enumerable.Range(0, 3).Select(x => new Enemy());


    palya[p1.y, p1.x] = p1.kinezet;
    foreach (var e in enemies) 
    {
        palya[e.y, e.x] = e.kinezet;
    }
    Palya.Kiir(palya);