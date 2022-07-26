using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class IceMan : BaseFighter
    {
        private bool _stunSuccess;

        public IceMan(StringCreator stringCreator) : base(fighterClass: "IceMen", stringCreator: stringCreator) { }

        public override Damage Attack()
        {
            if (Random.Next(100) < AbilityChance)
            {
                Stun();
            }

            Damage damage = new Damage(base.Attack().GetDamage(), _stunSuccess);

            _stunSuccess = false;
            return damage;
        }

        public void Stun()
        {
            _stunSuccess = true;
            StringCreator.ShowMessage(Class + " застанил врага");
        }

        public override BaseFighter ToCopy() => new IceMan(StringCreator);
    }
}
