using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena2
{
    internal class Berserker : Hero
    {
        private const int RageChance = 10;
        private const int HealChance = 5;

        public Berserker(string name, Weapon weapon) : base(name, weapon) { }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(RageChance))
            {
                attack *= 2; // Rage double attack
                Console.WriteLine($"{Name} enters a rage and deals double damage!");
            }
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
            if (ThrowDice(HealChance))
            {
                Heal(StartingHealth * 20 / 100); // Heal on taking damage
                Console.WriteLine($"{Name} heals after taking damage!");
            }
        }
    }
}
