using Colisium.Fighters.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium.Fighters
{
    abstract class BaseFigther : IAttackable, IDamagable, IAbilityble
    {
        private float _health;
        private float _armor;
        private float _damage;
        private float _abilityChance;
        private float _damageDeviation;
        private Random _random;

        public BaseFigther(float health = 1000, int armor = 20, int damage = 50, float abilityChance = 30)
        {
            _health = health;
            _armor = armor;
            _damage = damage;
            _abilityChance = abilityChance;
            _damageDeviation = 10;
            _random = new Random();
        }

        public float Attack()
        {
            int minDamage = (int)(_damage > _damageDeviation ? _damage - _damageDeviation : 0);
            int maxDamage = (int)(_damage > _damageDeviation ? _damage + _damageDeviation : _damageDeviation * 2);
            return _random.Next(minDamage, maxDamage);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage - (damage * _armor / 100);
        }

        public virtual void UseAbility()
        {

        }
    }
}
