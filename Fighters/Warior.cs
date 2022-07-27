using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Warior : BaseFighter
    {
        private int _damageCount;

        public Warior(StringCreator stringCreator) : base(fighterClass: "Warior", stringCreator: stringCreator) 
        {
            _damageCount = 2;
        }

        public override Damage Attack() => Random.Next(100) < AbilityChance ? TakeManyDamage() : base.Attack();

        public Damage TakeManyDamage() => Attack(_damageCount);

        public override BaseFighter ToCopy() => new Warior(StringCreator);
    }
}
