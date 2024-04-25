using Main;
Console.CursorVisible = false;


Palya.palya[Player.p1.y, Player.p1.x] = Player.p1.kinezet;
Palya.palya[Enemy.e1.y, Enemy.e1.x] = Enemy.e1.kinezet;
Palya.Kiir(Palya.palya);
Palya.palya[Player.p1.y, Player.p1.x] = ' ';

Mozgas.enemyStart(Enemy.e1, Enemy.e2, Enemy.e3, Enemy.e4);

Task.Run(() => Mozgas.KonzolKezel());

while (Player.p1.pontok < 121 && Player.p1.isAlive)
{
   await Player.p1.Menj(Palya.palya);
}

if (Player.p1.isAlive)
{
    Console.WriteLine("YOU WIN!!");
} else {
    Console.WriteLine("GAME OVER");
}