﻿using Colisium.Control.Console;
using Colisium.Display.Console;

namespace Colisium
{
    class Program
    {
        static void Main()
        {
            FightRing fightRing = new FightRing("Бойцовский клуб", new StringCreator(new ConsoleDisplay()), new ConsoleDataInput());

            fightRing.Run();
        }
    }
}
