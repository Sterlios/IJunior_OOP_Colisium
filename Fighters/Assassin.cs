using Colisium.Fighters.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium.Fighters
{
    class Assassin : BaseFigther, IDodgable
    {
        // шанс уклонения 

        public Assassin()
        {

        }

        public override void UseAbility()
        {
            Dodge();
        }

        public void Dodge()
        {

        }
    }
}
