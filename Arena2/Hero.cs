using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena2
{
    internal class Hero
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public Weapon Weapon { get; private set; }
        protected int StartingHealth { get; private set; }
        public bool IsDead { get { return Health <= 0; } }

        public Hero(string name, Weapon weapon)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
            Strength = 100;
            Weapon = weapon;
        }

        public virtual int Attack()
        {
            int baseDamage = (Strength * Random.Shared.Next(80, 121)) / 100;
            baseDamage += Weapon.DamageBonus;
            if (Weapon.TryApplySpecialEffect(ref baseDamage))
            {
                Console.WriteLine($"{Name}'s weapon {Weapon.Name} special ability activated!");
            }
            return baseDamage;
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            if (incomingDamage < 0) return;
            Health -= incomingDamage;
        }

        protected bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            return dice <= chance;
        }

        protected void Heal(int value)
        {
            Health += value;
            if (Health > StartingHealth) Health = StartingHealth;
            Console.WriteLine($"{Name} heals {value} health.");
        }
    }
}