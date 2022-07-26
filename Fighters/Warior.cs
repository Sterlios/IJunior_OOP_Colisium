using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Warior : BaseFighter
    {
        public Warior(StringCreator stringCreator) : base(fighterClass: "Warior", stringCreator: stringCreator) { }

        public override Damage Attack() => Random.Next(100) < AbilityChance ? TakeManyDamage() : base.Attack();

        public Damage TakeManyDamage() => Attack(2);

        public override BaseFighter ToCopy() => new Warior(StringCreator);
    }
}
