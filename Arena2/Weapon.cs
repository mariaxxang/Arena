using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena2
{
    internal static class Weapons
    {
        public static Weapon Sword = new Weapon("Sword of Excalibur", 20, 10, damage => damage * 2);
        public static Weapon Bow = new Weapon("Bow of the Celestial Archer", 15, 20, damage => damage + 50);
        public static Weapon Dagger = new Weapon("Shadowstrike Dagger", 10, 30, damage => damage + Random.Shared.Next(10, 51));
        public static Weapon Axe = new Weapon("Warhammer of Thunderous Wrath", 25, 15, damage => damage + 100);
    }

    internal class Weapon
    {
        public string Name { get; private set; }
        public int DamageBonus { get; private set; }
        public int SpecialEffectChance { get; private set; }
        public Func<int, int> ApplySpecialEffect { get; private set; }

        public Weapon(string name, int damageBonus, int specialEffectChance, Func<int, int> applySpecialEffect)
        {
            Name = name;
            DamageBonus = damageBonus;
            SpecialEffectChance = specialEffectChance;
            ApplySpecialEffect = applySpecialEffect;
        }

        public bool TryApplySpecialEffect(ref int damage)
        {
            if (Random.Shared.Next(100) < SpecialEffectChance)
            {
                damage = ApplySpecialEffect(damage);
                return true;
            }
            return false;
        }
    }

  
}

