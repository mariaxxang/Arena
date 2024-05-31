using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena2
{
    internal class Knight : Hero
    {
        const int BlockDamageChance = 10;
        private const int ExtraDamageChance = 5;

        public Knight(string name, Weapon weapon) : base(name, weapon) { }

        public override void TakeDamage(int incomingDamage)
        {
            int damageReduceCoef = Random.Shared.Next(20, 61);
            incomingDamage -= (incomingDamage * damageReduceCoef) / 100;
            if (ThrowDice(BlockDamageChance))
            {
                incomingDamage = 0;
                Console.WriteLine($"{Name} blocks all incoming damage!");
            }
            base.TakeDamage(incomingDamage);
        }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(ExtraDamageChance))
            {
                attack = attack * 150 / 100;
                Console.WriteLine($"{Name} deals extra damage!");
            }
            return attack;
        }
    }
}
