using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Priest : BaseFighter,  IHealingable
    {
        //Лечится с некоторым шансом
        private float _healingPercentage;

        public Priest(StringCreator stringCreator) : base(fighterClass: "Priest", stringCreator: stringCreator)
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

        public override BaseFighter ToCopy()
        {
            return new Priest(StringCreator);
        }
    }
}
