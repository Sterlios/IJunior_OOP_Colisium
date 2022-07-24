using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Warior : BaseFighter, IDoubleAttack
    {
        //двойной удар

        public Warior()
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
    }
}
