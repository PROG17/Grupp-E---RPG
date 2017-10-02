using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Monsters
    {
        public int Hp { get; set; }
        public int Hp_Current { get; set; }
        public int Monster_Strength { get; set; }

        List<string> Monsterloot = new List<string>();

        public void CreateMonster(string name)
        {
            if (name == "Goblin")
            {
                Hp = 50;
                Hp_Current = 50;
                Monster_Strength = 3;
            }

        }
        public int MonsterHit(string name)
        {
            Random MonsterHit = new Random();
            int MonsterDamage = 0;
            if (name == "Goblin")
            {
                MonsterDamage = MonsterHit.Next(10, 15) + Monster_Strength;
            }

            return MonsterDamage;
        }
        public string MonsterLoot(string name)
        {

            if (name == "Goblin")
            {
                string[] PotentialLoot = new string[5];
                PotentialLoot[0] = "Bread";
                PotentialLoot[1] = "Water";
                PotentialLoot[2] = "Water";
                PotentialLoot[3] = "Feather";
                PotentialLoot[4] = "Strawhat";

                Monsterloot.Add(PotentialLoot[LootChecker(PotentialLoot.Count())]);

            }
            return name;
        }
        public List<string> ShowMonsterLoot()
        {
            Console.Write("Loot: ");
            foreach (var item in Monsterloot)
            {
                Console.Write(item + "\n");
            }
            return Monsterloot;
        }
        public List<string> GetMonsterLoot()
        {
            return Monsterloot;
        }
        private int LootChecker(int lootNr)
        {
            Random LootChecker = new Random();
            int Loot = 0;
            Loot = LootChecker.Next(0, lootNr);
            return Loot;
        }
    }
}
