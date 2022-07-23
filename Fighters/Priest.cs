using Colisium.Fighters.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium.Fighters
{
    class Priest : BaseFigther,  IHealingable
    {
        //Лечится с некоторым шансом
        private float _healingPercentage;

        public Priest()
        {
            _healingPercentage = 50;
        }

        public override void UseAbility()
        {
            Heal();
        }

        public void Heal()
        {

        }
    }
}
