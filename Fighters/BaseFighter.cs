using Colisium.Fighters.Actions;
using System;

namespace Colisium.Fighters
{
    abstract class BaseFighter : IAttackable, IDamagable, IAbilityble, IFighter
    {
        private float _health;
        private float _armor;
        private float _damage;
        private float _abilityChance;
        private float _damageDeviation;
        private Random _random;
        public StringCreator StringCreator { get; private set; }
        public string Class { get; private set; }
        public bool IsAlive => _health > 0;

        public BaseFighter(StringCreator stringCreator, string fighterClass, float health = 1000, int armor = 20, int damage = 50, float abilityChance = 30)
        {
            _health = health;
            _armor = armor;
            _damage = damage;
            _abilityChance = abilityChance;
            _damageDeviation = 10;
            _random = new Random();
            StringCreator = stringCreator;
            Class = fighterClass;
        }

        public float Attack()
        {
            int minDamage = (int)(_damage > _damageDeviation ? _damage - _damageDeviation : 0);
            int maxDamage = (int)(_damage > _damageDeviation ? _damage + _damageDeviation : _damageDeviation * 2);
            int damage = _random.Next(minDamage, maxDamage);

            StringCreator.ShowMessage(Class + " Нанес урон " + damage);
            return damage;
        }

        public void TakeDamage(float damage)
        {
            float realDamage = damage - (damage * _armor / 100);
            _health -= realDamage;
            StringCreator.ShowMessage(Class + " Получил урон " + realDamage);
        }

        public virtual void UseAbility()
        {

        }

        public virtual void ShowInfo()
        {
            StringCreator.ShowMessage(Class + " | HP : " + _health + "" + " | Armor : " + _armor + "" + " | Damage : " + _damage + "");
        }

        public abstract BaseFighter ToCopy();
    }
}
