using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Viking : BaseFighter, ICriticable
    {
        // Щанс крита

        public Viking(StringCreator stringCreator) : base(fighterClass: "Viking", stringCreator: stringCreator)
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

        public override BaseFighter ToCopy()
        {
            return new Viking(StringCreator);
        }
    }
}
