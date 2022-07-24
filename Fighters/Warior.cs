using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Warior : BaseFighter, IDoubleAttack
    {
        //двойной удар

        public Warior(StringCreator stringCreator) : base(fighterClass: "Warior", stringCreator: stringCreator)
        {

        }

        public override void UseAbility()
        {
            TakeSecondDamage();
        }

        public void TakeSecondDamage()
        {
            Attack();
            Attack();
        }

        public override BaseFighter ToCopy()
        {
            return new Warior(StringCreator);
        }
    }
}
