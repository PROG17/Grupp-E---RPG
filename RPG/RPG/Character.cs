using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Character
    {
        private string name;
        private string character;
        List<string> Char_Backpack = new List<string>();
        List<string> Char_Buffs = new List<string>();


        // Properties för alla stats
        public int Char_Strength { get; set; }
        public int Char_Agility { get; set; }
        public int Char_Intelligence { get; set; }
        public int Hp { get; set; }
        public int Hp_Current { get; set; }
        public string Char_Vocation { get; set; }
        // Konstruktor som sätter Namn och class
        public Character(string Name, string Character)
        {
            this.name = Name;
            this.character = Character;

            // När en ny hjälte skapas fylls även hans väska med ett item
            Char_Backpack.Add("Bread");

            // Sätter hjältens stats beroend på val av karaktär
            SetStats(character);
        }

        private void SetStats(string vocation)
        {
            if (vocation == "Barbarian")
            {
                Char_Strength = 12;
                Char_Agility = 6;
                Char_Intelligence = 6;
                Hp = 110;
                Hp_Current = 110;
                Char_Vocation = vocation;

            }
            else if (vocation == "Knight")
            {
                Char_Strength = 8;
                Char_Agility = 7;
                Char_Intelligence = 8;
                Hp = 115;
                Hp_Current = 115;
                Char_Vocation = vocation;
            }
            else if (vocation == "Thief")
            {
                Char_Strength = 6;
                Char_Agility = 10;
                Char_Intelligence = 8;
                Hp = 105;
                Hp_Current = 105;
                Char_Vocation = vocation;
            }
            else if (vocation == "Warlock")
            {
                Char_Strength = 6;
                Char_Agility = 8;
                Char_Intelligence = 10;
                Hp = 100;
                Hp_Current = 100;
                Char_Vocation = vocation;
            }
        }

        // Vid anrop skriver stats ut
        public void TypeStats()
        {
            Console.WriteLine("\nHealth: " + Hp_Current);
            Console.WriteLine("Strength: " + Char_Strength);
            Console.WriteLine("Agility: " + Char_Agility);
            Console.WriteLine("Intelligence: \n" + Char_Intelligence);
            foreach (var item in Char_Buffs)
            {
                Console.WriteLine("Active buff: \n" + item);
            }

        }

        // Lägger till i hjältens väska
        public void AddInventory(string item)
        {
            Console.WriteLine("\nYou added {0} to your inventory\n", item);
            Char_Backpack.Add(item);

        }

        // Plockar bort ur västa
        public void UsedItem(string item)
        {
            Console.WriteLine("\n You use " + item + ".");
            Char_Backpack.Remove(item);
        }
        public void DropToRoom(string item)
        {
            if (item == "Shield") { }
            else
            {
                Console.WriteLine("You dropped {0} on the floor", item);
            }
            Char_Backpack.Remove(item);
        }


        // Kollar om väskan innehåller ett vist item och returnerar True eller false
        public bool CheckBackPack(string item)
        {
            bool Ex = Char_Backpack.Contains(item);
            return Ex;
        }

        public void HpHeal(int heal)
        {
            int HealedHp = Hp - Hp_Current;
            Hp_Current += heal;
            if (Hp_Current >= Hp)
            {
                Console.WriteLine("\nYou gain " + HealedHp + " health.\n");
                Hp_Current = Hp;
            }
            else
            {
                Console.WriteLine("\nYou gain " + heal + " health.\n");
            }
        }

        public int AttackDamage(string name)
        {
            Random PlayerHit = new Random();
            int PlayerDamage = PlayerHit.Next(1, 10) + Char_Strength;
            Console.WriteLine("You deal " + PlayerDamage + " damage to " + name + ".\n");
            return PlayerDamage;
        }

        public void HpDamage(int dmg, string cause)
        {

            Hp_Current -= dmg;

            if (Hp_Current <= 0)
            {
                Console.WriteLine("You loose " + dmg + " hitpoints by " + cause + ".");
                Console.WriteLine("Health: " + Hp_Current);
            }
            else
            {
                Console.WriteLine("You loose " + dmg + " hitpoints by " + cause + ".");
                Console.WriteLine("Health: " + Hp_Current);
            }

        }

        // Hämtar väskan
        public List<string> GetBackPack()
        {
            return Char_Backpack;
        }

        public List<string> GetBuffs()
        {
            return Char_Buffs;
        }

        public void UseItem(string item)
        {
            if (Char_Backpack.Contains(item))
            {
                if (item == "Bread")
                {
                    if (Hp_Current >= Hp)
                    {
                        Console.WriteLine("\nYou already have full health. " + item + " was not used.\n");
                    }
                    else
                    {
                        HpHeal(20);
                        Char_Backpack.Remove(item);
                    }
                    
                }
                else if (item == "Green Vial")
                {
                    Char_Buffs.Add("Goblinoid");
                    Console.WriteLine("\nYou drink the green liquid and you feel strange... But you can't put your nose on what's wrong.\n");
                    Char_Backpack.Remove(item);
                }
                else if (item == "White Vial")
                {
                    Console.WriteLine("\nYou drink the white liquid and you feel a sharp pain in your stomach. " +
                        "You feel that this was the wrong choice.\n");
                    HpDamage(30, item);
                    Char_Backpack.Remove(item);
                }
                else if (item == "Rusty Key")
                {
                    Console.WriteLine("\nYou must go to a door to use this key.\n");
                }
            }
            else
            {
                Console.WriteLine("\nYou don't have that in your inventory.\n");
            }
        }

        // skriver ut väskans innehåll
        public void ShowInventory()
        {
            Console.WriteLine("");
            if (Char_Backpack.Count == 0)
            {
                Console.WriteLine("You have no items in your backpack.");
                Console.Write("");
            }
            else
            {
                Console.WriteLine("\nINVENTORY");
                Console.WriteLine("-----------------------------------------\n");
                for (int i = 0; i < Char_Backpack.Count; i++)
                {
                    Console.WriteLine(i + 1 + ": " + Char_Backpack[i] + "\n");
                }
                Console.Write("-----------------------------------------");
                Console.WriteLine("\n");
            }

        }

        public static string FirstToUpper()
        {
            string text = Console.ReadLine();
            if (text.Length > 1)
            {
                text = text.First().ToString().ToUpper() + text.Substring(1).ToLower();
            }

            return text;
        }


    }
}
