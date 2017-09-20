using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Character
    {
        
        public int GetStats(string vocation, out int Char_Strength, out int Char_Agility, out int Char_Intelligence)
        {
            Char_Strength = 0;
            Char_Agility = 0;
            Char_Intelligence = 0;
            if (vocation == "Barbarian")
            {
                Char_Strength = 12;
                Char_Agility = 6;
                Char_Intelligence = 6;
                
            }
            else if (vocation == "Knight")
            {
                Char_Strength = 8;
                Char_Agility = 8;
                Char_Intelligence = 8;
               
            }
            else if (vocation == "Thief")
            {
                Char_Strength = 6;
                Char_Agility = 10;
                Char_Intelligence = 8;
                
            }
            else if (vocation == "Warlock")
            {
                Char_Strength = 6;
                Char_Agility = 8;
                Char_Intelligence = 10;
                
            }
            else
            {

            }
            return Char_Strength;
            
        }

        public int GetHP(int hp, string vocation)
        {
            if (vocation == "Barbarian")
            {
                hp = 110;
            }
            else if (vocation == "Knight")
            {
                hp = 115;
            }
            else if (vocation == "Thief")
            {
                hp = 105;
            }
            else if (vocation == "Warlock")
            {
                hp = 100;
            }
            else
            {
                hp = 1000;
            }

            return hp;

        }
        public string AddInventory(string Item, List<string> Backpack)
        {
            Backpack.Add(Item);
            return Item;
        }
        public string DropInventory(string Item, List<string> Backpack)
        {
            Backpack.Remove(Item);
            return Item;
        }
        
    }
}
