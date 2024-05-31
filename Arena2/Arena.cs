using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena2
{
    internal class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;
            if (Random.Shared.Next(2) == 0)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }
            while (true)
            {
                int damage = attacker.Attack();
                Console.WriteLine($"{attacker.Name} attacks {defender.Name} for {damage} damage.");
                defender.TakeDamage(damage);
                if (defender.IsDead)
                {
                    Console.WriteLine($"{defender.Name} has died. {attacker.Name} is the winner!");
                    return attacker;
                }
                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }
    }   
}
