using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Priest : BaseFighter,  IHealingable
    {
        //Лечится с некоторым шансом
        private float _healingPercentage;

        public Priest()
        {
            _healingPercentage = 50;
        }

        public override void UseAbility()
        {
            Heal();
        }

        public void Heal()
        {

        }
    }
}
