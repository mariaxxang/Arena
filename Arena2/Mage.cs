using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena2
{
    internal class Mage : Hero
    {
        private const int FireballChance = 15;
        private const int ShieldChance = 20;

        public Mage(string name, Weapon weapon) : base(name, weapon) { }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(FireballChance))
            {
                attack += 50;
                Console.WriteLine($"{Name} casts a fireball!");
            }
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (ThrowDice(ShieldChance))
            {
                incomingDamage /= 2;
                Console.WriteLine($"{Name} halves the incoming damage with a shield!");
            }
            base.TakeDamage(incomingDamage);
        }
    }
}
