using Colisium.Fighters.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium.Fighters
{
    class Warior : BaseFigther, IDoubleAttack
    {
        //двойной удар

        public Warior()
        {

        }

        public override void UseAbility()
        {
            TakeSecondDamage();
        }

        public void TakeSecondDamage()
        {
            Attack();
            Attack();
        }
    }
}
