using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Viking : BaseFighter, ICriticable
    {
        // Щанс крита

        public Viking()
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
    }
}
