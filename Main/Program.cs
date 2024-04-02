// See https://aka.ms/new-console-template for more information
using Main;
Console.CursorVisible = false;

var e1 = new Enemy(ConsoleColor.Red);
var e2= new Enemy(ConsoleColor.Magenta);
var e3 = new Enemy(ConsoleColor.DarkBlue);
var e4 = new Enemy(ConsoleColor.Green);

Palya.palya[Player.p1.y, Player.p1.x] = Player.p1.kinezet;
Palya.palya[e1.y, e1.x] = e1.kinezet;
Palya.Kiir(Palya.palya);
Palya.palya[Player.p1.y, Player.p1.x] = ' ';

Player.p1.Menj(Palya.palya);
