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

        // Properties för alla stats
        public int Char_Strength { get; set; }
        public int Char_Agility { get; set; }
        public int Char_Intelligence { get; set; }
        public int Hp { get; set; }

        // Konstruktor som sätter Namn och class
        public Character(string Name, string Character)
        {
            this.name = Name;
            this.character = Character;

            // När en ny hjälte skapas fylls även hans väska med två items
            Char_Backpack.Add("Rusty key");
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

            }
            else if (vocation == "Knight")
            {
                Char_Strength = 8;
                Char_Agility = 8;
                Char_Intelligence = 8;
                Hp = 115;

            }
            else if (vocation == "Thief")
            {
                Char_Strength = 6;
                Char_Agility = 10;
                Char_Intelligence = 8;
                Hp = 105;

            }
            else if (vocation == "Warlock")
            {
                Char_Strength = 6;
                Char_Agility = 8;
                Char_Intelligence = 10;
                Hp = 100;
            }
        }

        // Vid anrop skriver stats ut
        public void TypeStats()
        {
            Console.WriteLine("Helth: " + Hp);
            Console.WriteLine("Strenght: " + Char_Strength);
            Console.WriteLine("Agility: " + Char_Agility);
            Console.WriteLine("Intelligence: " + Char_Intelligence);
        }
        
        // Lägger till i hjältens väska
        public void AddInventory(string item)
        {
            Console.WriteLine("You added {0} to your inventory", item);
            Char_Backpack.Add(item);

        }

        // Plockar bort ur västa
        public void DropInventory(string item)
        {
            Console.WriteLine("You dropped {0} on the floor", item);
            Char_Backpack.Remove(item);
        }

        // Kollar om väskan innehåller ett vist item och returnerar True eller false
        public bool CheckBackPack(string item)
        {
            bool Ex = Char_Backpack.Contains(item);
            return Ex;
        }

        // Hämtar väskan
        public List<string> GetBackPack()
        {
            return Char_Backpack;
        }

        // skriver ut väskans innehåll
        public void ShowInentory()
        {
            foreach (var item in Char_Backpack)
            {
                Console.WriteLine(item);
            }
        }

    }
}
