using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Warior : BaseFighter
    {
        public Warior(StringCreator stringCreator) : base(fighterClass: "Warior", stringCreator: stringCreator) { }

        public override float[] Attack() => Random.Next(100) < AbilityChance ? TakeManyDamage() : base.Attack();

        public float[] TakeManyDamage() => Attack(2);

        public override BaseFighter ToCopy() => new Warior(StringCreator);
    }
}
