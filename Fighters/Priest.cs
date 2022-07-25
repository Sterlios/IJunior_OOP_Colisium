using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Priest : BaseFighter
    {
        //Лечится с некоторым шансом
        private float _healingPercentage;

        public Priest(StringCreator stringCreator) : base(fighterClass: "Priest", stringCreator: stringCreator)
        {
            _healingPercentage = 0.1f;
        }

        public override float[] Attack() => Random.Next(100) < AbilityChance ? Heal() : base.Attack();

        public float[] Heal()
        {
            float deltaHealth = MaxHealth * _healingPercentage;
            ChangeHealth(deltaHealth);

            float oldDamage = Damage;
            float newDamage = 0;

            ChangeDamage(newDamage);
            float[] currentDamage = base.Attack();
            ChangeDamage(oldDamage);

            return currentDamage;
        }

        public override BaseFighter ToCopy() => new Priest(StringCreator);
    }
}
