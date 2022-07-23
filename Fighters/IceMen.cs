using Colisium.Fighters.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium.Fighters
{
    class IceMen : BaseFigther, IStunable
    {
        // Стан врага

        public IceMen()
        {

        }

        public override void UseAbility()
        {
            Stun();
        }

        public void Stun()
        {

        }
    }
}
