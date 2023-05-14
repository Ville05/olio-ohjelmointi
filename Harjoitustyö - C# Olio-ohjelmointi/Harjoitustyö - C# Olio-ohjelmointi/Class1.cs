using System;

namespace vikatehtävä
{
    class Armor : Item
    {
        public int Defense { get; set; }
    }
    

    class Weapon : Item
    {
        public int Damage { get; set; }
    }
    abstract class Item
    {
        public string Name { get; set; }
    }


    class Player
    {
        public int Health { get; set; } = 100;
        public int AttackDamage { get; set; } = 10;
        
        public int AbilityDmg { get; set; } = 0;

        public int pottu { get; set; } = 0;
        public int Money { get; set; } = 0;
        
        private Random random = new Random();
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }



        public void Attack(Enemy enemy)
        {
            int damage = random.Next(5, 11);
            if (EquippedWeapon != null)
            {
                damage += EquippedWeapon.Damage;
            }
            enemy.TakeDamage(damage);
            Console.WriteLine($"Pelaaja hyökkää ja tekee {damage} vahinkoa!");
        }

       

        public void TakeDamage(int damage)
        {
            if (EquippedWeapon != null)
            {
                damage += EquippedWeapon.Damage;
            }

            Health -= damage;
            Console.WriteLine($"vihollinen teki {damage} damagea !");
        }
    }
}