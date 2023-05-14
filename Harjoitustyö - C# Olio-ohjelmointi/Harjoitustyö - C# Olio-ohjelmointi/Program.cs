using System;
using System.Numerics;

namespace vikatehtävä
{
    abstract class Enemy
    {
        public bool IsWeakToAbility { get; set; } = false;
        public int Trohealth { get; set; } = 75;
        public int Lohhealth { get; set; } = 150;
        public int Health { get; set; } = 50;
        public int AttackDamage { get; set; } = 5;
        
        public bool IsDefeated { get { return Health <= 0; } }
        public bool IsDefeatedloh { get { return Lohhealth <= 0; } }
        public bool IsDefeatedTro { get { return Trohealth <= 0; } }
        public Random random = new Random();

        public void Attack(Player player)
        {
            int damage = AttackDamage;
            Console.WriteLine($"Vihollinen hyökkää sinuun ja tekee {damage} damagea!");
            player.TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            if (IsWeakToAbility)
            {
                damage *= 2;
                Console.WriteLine($"hit n run osui vihollisen heikkoon kohtaan teit {damage} damagea!");
            }

            Health -= damage;
            Trohealth -= damage;
            Lohhealth -= damage;
        }
    }
    class lohi : Enemy
    {
        public lohi()
        {
            Health = 50;
            int AttackDamage = random.Next(3, 8);
        }
    }

    

    class Lohikäärme : Enemy
    {
        public Lohikäärme()
        {
            Lohhealth = 100;
            int AttackDamage = random.Next(10, 21);
            IsWeakToAbility = true;
        }
    }
    class sauli : Enemy
    {
        public sauli()
        {
            Trohealth = 75;
            int AttackDamage = random.Next(6, 11);
        }
    }
}