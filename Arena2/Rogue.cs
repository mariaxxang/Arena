using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena2
{
    internal class Rogue : Hero
    {
        private const int TripleDamageMagicLastDigit = 5;
        private const int HealEachNthRound = 3;
        private int attackCount;

        public Rogue(string name, Weapon weapon) : base(name, weapon)
        {
            attackCount = 0;
        }

        public override int Attack()
        {
            int attack = base.Attack();
            if (attack % 25 == TripleDamageMagicLastDigit)
            {
                attack = attack * 3;
                Console.WriteLine($"{Name} deals triple damage!");
            }
            attackCount++;
            if (attackCount % HealEachNthRound == 0 && ThrowDice(25))
            {
                Heal(StartingHealth * 50 / 100);
                Console.WriteLine($"{Name} heals after attack!");
            }
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (ThrowDice(30))
            {
                incomingDamage = 0;
                Console.WriteLine($"{Name} dodges the attack!");
            }
            base.TakeDamage(incomingDamage);
        }
    }
}
