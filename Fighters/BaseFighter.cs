using Colisium.Fighters.Actions;
using System;
using System.Collections.Generic;

namespace Colisium.Fighters
{
    abstract class BaseFighter : IFighter
    {
        public float Health { get; private set; }
        public float MaxHealth { get; }
        public Random Random { get; private set; }
        public StringCreator StringCreator { get; private set; }
        public string Class { get; private set; }
        public bool IsAlive => Health > 0;
        public bool IsStun { get; private set; }
        public float Damage { get; private set; }
        public int Percent { get; }
        public float AbilityChance { get; private set; }

        private float _armor;
        private float _damageDeviation;

        public BaseFighter(StringCreator stringCreator, string fighterClass, float health = 1000, int armor = 20, int damage = 50, float abilityChance = 30)
        {
            Health = health;
            MaxHealth = health;
            _armor = armor;
            Damage = damage;
            AbilityChance = abilityChance;
            _damageDeviation = 10;
            Random = new Random();
            StringCreator = stringCreator;
            Class = fighterClass;
            Percent = 100;
        }

        public virtual Damage Attack() => Attack(1);

        public virtual void TakeDamage(Damage damages)
        {
            IsStun = damages.IsStun;
            List<float> damageList = damages.GetDamage();

            foreach (float damage in damageList)
            {
                TakeDamage(damage);
            }
        }

        public virtual void ShowInfo()
        {
            StringCreator.ShowMessage(Class + " | HP : " + Health + " | Armor : " + _armor + " | Damage : " + Damage);
        }

        public abstract BaseFighter ToCopy();

        protected Damage Attack(int hitsNumber)
        {
            List<float> damages = new List<float>();

            if (IsStun == false)
            {
                for (int i = 0; i < hitsNumber; i++)
                {
                    if (Damage > 0)
                    {
                        int minDamage = (int)(Damage > _damageDeviation ? Damage - _damageDeviation : 1);
                        int maxDamage = (int)(Damage > _damageDeviation ? Damage + _damageDeviation : _damageDeviation * 2);
                        damages.Add(Random.Next(minDamage, maxDamage));

                        StringCreator.ShowMessage(Class + " Нанес урон " + damages[i]);
                    }
                }
            }
            else
            {
                StringCreator.ShowMessage(Class + " застанен");
            }

            return new Damage(damages);
        }

        protected void ChangeDamage(float newDamage)
        {
            Damage = newDamage;
        }

        protected void ChangeHealth(float deltaHealth)
        {
            if(deltaHealth > 0)
            {
                Health += deltaHealth;

                if (Health > MaxHealth)
                {
                    Health = MaxHealth;
                }

                StringCreator.ShowMessage(Class + " восстановил " + deltaHealth + " здоровья");
            }
        }

        protected virtual void TakeDamage(float damage)
        {
            if (damage > 0)
            {
                float realDamage = damage - (damage * _armor / 100);
                Health -= realDamage;
                StringCreator.ShowMessage(Class + " Получил урон " + realDamage);
            }
        }
    }
}
