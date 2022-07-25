using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Assassin : BaseFighter, IDodgable
    {
        // шанс уклонения 

        public Assassin(StringCreator stringCreator) : base(fighterClass: "Assassin", stringCreator: stringCreator) { }

        protected override void TakeDamage(float damage)
        {
            bool abilitySuccess = Random.Next(100) < AbilityChance;

            if (abilitySuccess)
            {
                Dodge();
            }
            else
            {
                base.TakeDamage(damage);
            }
        }

        public void Dodge()
        {
            StringCreator.ShowMessage(Class + " уклонился от удара");
        }

        public override BaseFighter ToCopy()
        {
            return new Assassin(StringCreator);
        }
    }
}
