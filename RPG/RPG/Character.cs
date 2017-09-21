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
        private int hp;
        List<string> Char_Backpack = new List<string>();

       // public List<string> Char_Backpack { get; set; }
        public int Char_Strength { get; set; }
        public int Char_Agility { get; set; }
        public int Char_Intelligence { get; set; }
        public int Hp { get; set; }

        public Character(string Name, string Character)
        {
            this.name = Name;
            this.character = Character;
            
            Char_Backpack.Add("Rusty Key");
            Char_Backpack.Add("Bread");
            SetStats(character);
        }
        
        public void SetStats(string vocation)
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
       
        public void AddInventory(string item)
        {
            Console.WriteLine("You added {0} to your inventory", item);
            Char_Backpack.Add(item);
            
        }
        public void DropInventory(string item)
        {
            Console.WriteLine("You dropped {0} on the floor", item);
            Char_Backpack.Remove(item);
        }

        public void CheckBackPack()
        {
            Console.WriteLine("Current items in your backpack");
            foreach (var item in Char_Backpack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        
    }
}
