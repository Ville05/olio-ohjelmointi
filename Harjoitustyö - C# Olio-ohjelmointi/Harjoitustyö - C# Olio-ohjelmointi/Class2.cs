using System;

namespace vikatehtävä
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("olet astumassa ritaripeliin");

            Player player = new Player();

            //pelin viholliset
            Enemy lohikäärme = new Lohikäärme();
            Enemy lohi = new lohi();
            Enemy sauli  = new sauli ();
            

            //aseet ja armorit
            Weapon ak47 = new Weapon() { Name = "ak47", Damage = 1 };
            Armor hattu = new Armor() { Name = "suoja-hattu", Defense = 5 };
            

            player.EquippedWeapon = ak47; 
            player.EquippedArmor = hattu;
           

            List<Item> inventory = new List<Item>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("mikä seuraava siirto");
                Console.WriteLine("1. ostokset");
                Console.WriteLine("2. väkivalta");
                Console.WriteLine("3. omistamat kamasi");
                Console.WriteLine("4. pussyo ja lopeta peli");
                Console.Write("Valinta: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Olet kaupassa");

                    while (true)
                    {
                        Console.WriteLine($"Kulta määrä: {player.Money}");

                        Console.WriteLine("Mitä aiot tehdä?");
                        Console.WriteLine("");
                        Console.WriteLine("1. HP lisäys (5 kultaa)");
                        Console.WriteLine("kun käytetty taistelussa lisää +20 hp");
                        Console.WriteLine("");
                        Console.WriteLine("2. suoja-hattu (5 kultaa)");
                        Console.WriteLine("Kypärä antaa +5 hp");
                        Console.WriteLine("3. ak47 (5 kultaa)");
                        Console.WriteLine("Antaa  +1 dmg ja vähentää -2 hp");
                        Console.WriteLine("");
                        Console.WriteLine("4. Takaisin");
                        Console.Write("Valinta: ");

                        int valinta = int.Parse(Console.ReadLine());
                        Console.WriteLine("");

                        if (player.Money < 5)
                        {
                            Console.WriteLine("et ole saanut tarpeeksi rahaa tähän");
                        }

                        if (valinta == 4)
                        {
                            break;
                        }

                        

                        else
                        {
                            if (valinta == 1)
                            {
                                Console.WriteLine("hommasit hp lisäyksen (lisää taistelussa 20hp)");
                                
                                player.Money -= 5;
                                
                            }
                            if (valinta == 2)
                            {
                                Console.WriteLine("Ostit hienon suoja-hatun");
                                player.pottu++;
                                inventory.Add(hattu);
                                player.Money -= 5;
                                
                            }
                            if (valinta == 3)
                            {
                                Console.WriteLine("hommasit laittoman ak47 +1 dmg ja  -2 hp ");
                                inventory.Add(ak47);
                                player.AttackDamage++;
                                player.Health -= 2;
                                player.Money -= 5;
                                
                            }
                           
                        }

                        if (valinta == 4)
                        {
                            continue;
                        }
                    }
                }

                else if (choice == 2)
                {
                    Enemy enemy;

                    Console.WriteLine("");
                    Console.WriteLine("Valitse vihollinen!");
                    Console.WriteLine("1. lohikäärme");
                    Console.WriteLine("2. sauli niinistö");
                    Console.WriteLine("3. lohi");
                    Console.WriteLine("4. Takaisin");
                    Console.Write("Valinta: ");
                    int enemyChoice = int.Parse(Console.ReadLine());

                    if (enemyChoice == 1)
                    {
                        enemy = lohikäärme;

                        while (!enemy.IsDefeated)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"lohikäärmeen elämät: {enemy.Health}");
                            Console.WriteLine($"sun elämät: {player.Health}");
                            

                            Console.WriteLine("how we move?");
                            Console.WriteLine("1.läpsäytä vihua");
                            Console.WriteLine("2. ability");
                            Console.WriteLine($"3. hp lisäys (määrä: {player.pottu})");
                            Console.WriteLine("4. juokse pakoon");
                            Console.Write("Valinta: ");

                            int val = int.Parse(Console.ReadLine());

                            switch (val)
                            {
                                case 1:
                                    player.Attack(enemy);
                                    break;
                                
                                    
                                case 2:
                                    {
                                        if (player.pottu > 0)
                                        {
                                            player.Health += 20;
                                            player.pottu--;
                                            Console.WriteLine($"hp lisäys eli +20 hp. Sinulla on  {player.pottu} lisäyksiö jäljellä.");
                                        }
                                        if (player.pottu <= 0)
                                        {
                                            Console.WriteLine("ei o enää hp lisäyksiä");
                                        }
                                        break;
                                    }
                                case 4:
                                    Console.WriteLine("pussyo juoksit pako!");
                                    return;
                                default:
                                    Console.WriteLine("ei toimi!");
                                    break;
                            }

                            if (enemy.IsDefeated)
                            {
                                Console.WriteLine("tuhostit lohikäärmeen!");
                                player.Money += 10;
                                break;
                            }

                            enemy.Attack(player);

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("sut tuhottii lol!");
                                return;
                            }
                        }
                    }

                    if (enemyChoice == 2)
                    {
                        enemy = sauli;

                        while (!enemy.IsDefeatedTro)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"sun healt: {player.Health}");
                            Console.WriteLine($"ritskun hp: {enemy.Trohealth}");

                            Console.WriteLine("Mitä aiot tehdä?");
                            Console.WriteLine("1. släppää vihuu");
                            Console.WriteLine("2.  ability");
                            Console.WriteLine($"3. Käytä HP lisäys (määrä: {player.pottu})");
                            Console.WriteLine("4. runaa pakoo g");
                            Console.Write("Valinta: ");

                            int val = int.Parse(Console.ReadLine());

                            switch (val)
                            {
                                case 1:
                                    player.Attack(enemy);
                                    break;
                                
                                case 2:
                                    {
                                        if (player.pottu > 0)
                                        {
                                            player.Health += 20;
                                            player.pottu--;
                                            Console.WriteLine($" heltti lisäyksen ja sait +20 hp. Sinulla on jäljellä {player.pottu} potiota.");
                                        }
                                        if (player.pottu <= 0)
                                        {
                                            Console.WriteLine("Sinulla ei ole hp lisäyksiä");
                                        }
                                        break;
                                    }
                                case 4:
                                    Console.WriteLine("Pakenit taistelusta!");
                                    return;
                                default:
                                    Console.WriteLine("ei toimi!");
                                    break;
                            }

                            if (enemy.IsDefeatedTro)
                            {
                                Console.WriteLine("Tapoit Trollin!");
                                player.Money += 10;
                                break;
                            }

                            enemy.Attack(player);

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("Trolli tappoi sinut!");
                                continue;
                            }
                        }
                    }

                    if (enemyChoice == 3)
                    {
                        enemy = lohi;

                        while (!enemy.IsDefeatedloh)
                        {

                            Console.WriteLine();
                            Console.WriteLine($"Pelaajan HP: {player.Health}");
                            Console.WriteLine($"Lohikäärmeen HP: {enemy.Lohhealth}");

                            Console.WriteLine("Mitä aiot tehdä?");
                            Console.WriteLine("1. Hyökkää");
                            Console.WriteLine("2. Käytä ability");
                            Console.WriteLine($"3. Käytä HP potion (määrä: {player.pottu})");
                            Console.WriteLine("4. Pakene");
                            Console.Write("Valinta: ");

                            int val = int.Parse(Console.ReadLine());

                            switch (val)
                            {
                                case 1:
                                    player.Attack(enemy);
                                    break;
                                case 2:
                                    enemy.IsWeakToAbility = true;

                                    
                                    break;
                                case 3:
                                    {
                                        if (player.pottu > 0)
                                        {
                                            player.Health += 20;
                                            player.pottu--;
                                            Console.WriteLine($"Käytit heltti potun ja sait +20 hp. Sinulla on jäljellä {player.pottu} potions.");
                                        }
                                        if (player.pottu <= 0)
                                        {
                                            Console.WriteLine("Sinulla ei ole HP potions");
                                        }
                                        break;
                                    }
                                case 4:
                                    Console.WriteLine("Pakenit taistelusta!");
                                    return;
                                default:
                                    Console.WriteLine("ei toimi!");
                                    break;
                            }
                            enemy.Attack(player);

                            if (player.Health <= 0)
                            {
                                Console.WriteLine("Lohikäärme tappoi sinut!");
                                continue;
                            }

                            if (enemy.IsDefeatedloh)
                            {
                                Console.WriteLine("Tapoit Lohikäärmeen!");
                                player.Money += 20;
                                break;
                            }

                           
                        }
                    }
                    if (enemyChoice == 4)
                    {
                        continue;
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("invi:");

                    if (inventory.Count == 0)
                    {
                        Console.WriteLine("invis on tyhjä");
                    }
                    else
                    {
                        foreach (var item in inventory)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("kiitti gameni pelaamisesta!");
                    return;
                }
            }
        }
    }
}