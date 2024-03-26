// See https://aka.ms/new-console-template for more information
using Main;

var palya = Palya.Letrehoz();
var p1 = new Player();
var enemies = Enumerable.Range(0, 3).Select(x => new Enemy());

while (true)
{
    foreach (var e in enemies)
    {
        palya[e.y, e.x] = e.kinezet;
    }
    p1.Menj(palya);
    palya[p1.y, p1.x] = p1.kinezet;
    System.Threading.Thread.Sleep(5);
    Palya.Kiir(palya);
}