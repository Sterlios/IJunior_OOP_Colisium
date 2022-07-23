using Colisium.Fighters.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium.Fighters
{
    class Viking : BaseFigther, ICriticable
    {
        // Щанс крита

        public Viking()
        {

        }

        public override void UseAbility()
        {
            IncraeseCtiticalDamageChance();
        }

        public void IncraeseCtiticalDamageChance()
        {
            Attack();
        }
    }
}
