using Colisium.Fighters.Actions;
using System.Collections.Generic;

namespace Colisium.Fighters
{
    class Priest : BaseFighter
    {
        private float _healingPercentage;

        public Priest(StringCreator stringCreator) : base(fighterClass: "Priest", stringCreator: stringCreator)
        {
            _healingPercentage = 0.1f;
        }

        public override Damage Attack() => Random.Next(100) < AbilityChance ? Heal() : base.Attack();

        public Damage Heal()
        {
            if(IsStun == false)
            {
                float deltaHealth = MaxHealth * _healingPercentage;
                ChangeHealth(deltaHealth);
            }

            Damage currentDamage = new Damage(new List<float>());

            return currentDamage;
        }

        public override BaseFighter ToCopy() => new Priest(StringCreator);
    }
}
