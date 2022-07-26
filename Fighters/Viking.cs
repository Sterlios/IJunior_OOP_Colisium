﻿using Colisium.Fighters.Actions;
using System.Collections.Generic;

namespace Colisium.Fighters
{
    class Viking : BaseFighter
    {
        private float _critMultiple;

        public Viking(StringCreator stringCreator) : base(fighterClass: "Viking", stringCreator: stringCreator)
        {
            _critMultiple = 2f;
        }

        public override Damage Attack() => Random.Next(100) < AbilityChance ? DoCriticalAttack() : base.Attack();

        public Damage DoCriticalAttack()
        {
            float oldDamage = Damage;
            float newDamage = Damage * _critMultiple;

            ChangeDamage(newDamage);
            Damage currentDamage = base.Attack();
            ChangeDamage(oldDamage);

            return currentDamage;
        }

        public override BaseFighter ToCopy() => new Viking(StringCreator);
    }
}
