using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace RPG
{
    class Program
    {

        public static void Main(string[] args)
        {
            bool FirstRoom = true;
            bool SecondRoom = false;
            bool ThirdRoom = false;
            bool fourthRoom = false;
            bool fifthRoom = false;

            bool FifthRoomFight = true;
            bool firstEnter = true;
            bool fifthEnter = false;
            bool FirstDoorOpen = false;
            bool FirstItemIsFound = false;
            bool FirstRoomIronBarWindow = true;
            bool CheckChestOpen = false;
            bool vaseBroken = false;
            bool EndGame = false;
            bool HiddenDoorOpen = false;
            bool CauldronIsFull = true;
            bool ShieldOnStatue = false;

            string Char_Name = "David";
            string Char_Voc = "Cool";
            string Command = "";

            List<string> FirstRoomItems = new List<string>();
            List<string> SecondRoomItems = new List<string>();
            List<string> ThirdRoomItems = new List<string>();
            List<string> FifthRoomItems = new List<string>();
            FirstRoomItems.Add("Rusty Key");
            string ChestItem = "Vial";

            // Sätter namn och karaktär, Warlock som defaul
            Char_Name = FirstUpperCase(WelcomeName(Char_Name));
            Char_Voc = FirstUpperCase(WelcomeVoc(Char_Voc));
            if (Char_Voc != "Barbarian" && Char_Voc != "Knight" && Char_Voc != "Thief" && Char_Voc != "Warlock")
            {
                Char_Voc = "Warlock";
            }

            WelcomeMessage(Char_Name, Char_Voc);

            var Hero = new Character(Char_Name, Char_Voc);
            var Monster = new Monsters();

            var roomOne = new Rooms(1);
            var roomTwo = new Rooms(2);
            var roomThree = new Rooms(3);
            var roomFour = new Rooms(4);
            var roomFive = new Rooms(5);

            List<string> backPack = Hero.GetBackPack();
            List<string> Buffs = Hero.GetBuffs();
            List<string> MonsterLoot = Monster.GetMonsterLoot();


            do
            {
              //  WriteTop(Char_Name, backPack.Count, Char_Voc, Hero.Hp_Current, Hero.Hp);
                while (FirstRoom == true)
                {
                    if (firstEnter == true)
                    {
                        roomOne.RoomInfo();
                        firstEnter = false;
                    }

                    Command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (Command == "Help")
                    {
                        Help();
                    }

                    else if (Command == "Status")
                    {
                        Hero.TypeStats();
                    }

                    else if (Command == "Look")
                    {
                        roomOne.RoomInfo();

                    }

                    else if (Command == "Door" || Command == "Table" || Command == "Window" || Command == "Chest")
                    {
                        roomOne.RoomAction(Hero, Command);
                    }

                    else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                    {
                        Hero.ShowInventory();
                    }

                    else if (Command == "Drop")
                    {
                        // Inventory skrivs ut och du väljer vad du vill droppa
                        Console.WriteLine("What item do you want to drop?");
                        Hero.ShowInventory();


                        string itemToDrop = FirstUpperCase(Console.ReadLine().ToLower());

                        // Kollar att du har föremålet du vill droppa
                        if (Hero.CheckBackPack(itemToDrop))
                        {
                            // Föremålet droppas och läggstill i nuvarande rummets itemlista
                            Hero.DropInventory(itemToDrop);
                            roomOne.AddRoomItem(itemToDrop);
                        }
                        else
                        {
                            Console.WriteLine("No such item in your inventory");
                        }
                    }

                    else if (Command == "Use")
                    {
                        Hero.ShowInventory();
                        Console.WriteLine("Which item do you want to use?\n");
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (backPack.Contains(Command))
                        {
                            Hero.UseItem(Command);
                        }
                        else
                        {
                            Console.WriteLine("You don't have that in your inventory.\n");
                        }
                    }

                    else if (Command == "Go East" || Command == "East")
                    {
                        if (roomOne.doorOpend == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Go to second room");
                            FirstRoom = false;
                            // SecondRoom = true;
                            fourthRoom = true;

                        }
                        else if (FirstDoorOpen == false)
                        {

                            Console.WriteLine("");
                            Console.WriteLine("The door is still locked");
                            Console.WriteLine("");
                        }
                    }

                    else if (Command == "Go West" || Command == "Go South" || Command == "Go North" || Command == "West" || Command == "South" || Command == "North")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You cannot go this way. The only way out seems to be to the East");
                        Console.WriteLine("");
                    }

                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Does not understand input. \nType \"Help\" to get help");
                        Console.WriteLine("");
                    }
                }

                while (SecondRoom == true) //////////////////////////////////////Rum 2 //////////////////////////////////////////////////
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 5);
                    Console.WriteLine("THE HALLWAY");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("The Second Room"); //ska ta bort sen
                    Console.ReadLine();

                    Console.Clear();
                    Console.SetCursorPosition(0, 30);
                    if (vaseBroken == false)  //om vasen är hel
                    {
                        Console.WriteLine(
                            "You have entered the hallway. By the south wall you see an ancient Vase on a piedestal.");
                        if (Hero.Char_Intelligence == 10)
                        {
                            Console.WriteLine(
                                "\nWith your great perception you see that the Vase has some kind of lever. \nBetter be careful...\n");
                        }
                    }

                    else
                    {
                        Console.WriteLine("You have entered the hallway. By the south wall you see a piedestal.");
                    }
                    Console.WriteLine("By the East wall stands a Statue of a knight in battle.\nHe holds a sword in his right hand.\n");
                    Console.WriteLine("To the North you see an open door.");
                    Console.WriteLine("To the West you see the room you woke up in.\n\n\n");

                    while (true)
                    {
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Vase" || Command == "Ancient Vase" || Command == "Take Vase" ||
                            Command == "Use Vase" || Command == "Use Ancient Vase")
                        {
                            if (vaseBroken == false)
                            {
                                Random arrowRnd = new Random();
                                int arrowDamage = arrowRnd.Next(20, 50);
                                Console.WriteLine("\nThe Vase is a trap! \n");
                                Console.WriteLine(
                                    $"Arrows shoot out from the south wall and you loose {arrowDamage} HP!");
                                Hero.Hp -= arrowDamage;
                                Console.WriteLine("Your Current HP is " + Hero.Hp +
                                                  ".\nThe Vase broke in to Shards\n");
                                SecondRoomItems.Add("Vase Shards");
                                vaseBroken = true;
                            }
                            else
                            {
                                Console.WriteLine("The Vase is broken...");
                            }
                        }

                        else if (Command == "Statue" || Command == "East" || Command == "Go East")
                        {
                            Console.WriteLine(
                                "\nYou walk up to the Statue.\nThe knight has a sword and armor, but no Shield... ");
                            Console.WriteLine("There is a Plate with an inscription at the foot of the Statue.");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Plate" || Command == "Read Plate" || Command == "Inscription" ||
                                Command == "Read")
                            {
                                Console.Clear();
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 11);
                                Console.WriteLine(
                                    "+-------------------------------------------------------------------+");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 10);
                                Console.WriteLine(
                                    "| = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = |");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 9);
                                Console.WriteLine(
                                    "|{>/-------------------------------------------------------------/<}|");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 8);
                                Console.WriteLine(
                                    "|: |                                                             | :|");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 7);
                                Console.WriteLine(
                                    "| :|                      MIHI OPUS EST CLYPEUS                  |: |");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 6);
                                if (Char_Voc == "Knight")
                                {
                                    Console.WriteLine(
                                   "|: |                        I NEED MY SHIELD                     | :|");

                                }
                                else
                                {
                                    Console.WriteLine(
                                        "|: |                                                             | :|");
                                }
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 5);
                                Console.WriteLine(
                                    "| :|                                                             |: |");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 4);
                                Console.WriteLine(
                                    "|{>/-------------------------------------------------------------/<}|");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 3);
                                Console.WriteLine(
                                    "| = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = |");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 2);
                                Console.WriteLine(
                                    "+-------------------------------------------------------------------+");

                                Console.ReadLine();
                                Console.Clear();
                                Console.SetCursorPosition(0, 30);
                                Console.WriteLine("You walk back to the center of the room.");
                            }
                            else if (Command == "No")
                            {
                                Console.WriteLine("You walk back to the center of the room.");
                            }
                            else
                            {
                                Console.WriteLine("\n?\n");
                                Console.WriteLine("You walk back to the center of the room.");
                            }
                        }

                        else if (Command == "West" || Command == "Go West")
                        {
                            SecondRoom = false;
                            FirstRoom = true;
                            break;
                        }
                        else if (Command == "North" || Command == "Go North")
                        {
                            SecondRoom = false;
                            ThirdRoom = true;
                            break;
                        }

                        else if (Command == "Help")
                        {
                            Help();
                        }
                        else if (Command == "Look")
                        {
                            Console.WriteLine("");
                            Console.WriteLine(
                                "You are in the hallway, and there is a piedestal by the South wall.");
                            if (vaseBroken == false)
                            {
                                Console.WriteLine("On the piedestal stands an ancient Vase.");
                                if (Hero.Char_Intelligence == 10)
                                {
                                    Console.WriteLine("Something feels strange about the Vase");
                                }
                                else if (!SecondRoomItems.Contains("Vase Shards"))
                                {
                                }
                                else
                                {
                                    Console.WriteLine("There are Vase Shards on the floor.");
                                }
                                if (ShieldOnStatue == false)
                                {
                                    Console.WriteLine(
                                    "By the East wall stands a Statue of a knight in battle.\nHe holds a Sword in his right hand.\n");
                                }
                                else {
                                    Console.WriteLine(
                                 "By the East wall stands a Statue of a knight in battle.\nHe holds a Sword in his right hand.\n" +
                                 "He now holds a Shield in his left hand.\n");
                                }
                            }
                                Console.WriteLine("To the North you see an open door.");
                                Console.WriteLine("To the West you see the room you woke up in.");


                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                            }
                        
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        Console.WriteLine("");
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Drop" || Command == "Remove" || Command.Contains("Drop"))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Which item do you want to drop?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                backPack.Remove(Command);
                                SecondRoomItems.Add(Command);
                                Console.WriteLine("You put the " + Command + " on the floor.");
                                Console.WriteLine("");

                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Could not find " + Command + " in your inventory.");
                            }
                        }

                        else if (Command == "Vase Shards" || Command == " Take Vase Shards" || Command == "Use Vase Shards" || Command == "Get Vase Shards" || Command == "Shards")
                        {
                            if (SecondRoomItems.Contains("Vase Shards"))
                            {
                                Console.WriteLine("\nDo you want to take the Vase Shards from the ground?");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Add("Vase Shards");
                                    SecondRoomItems.Remove("Vase Shards");
                                    Console.WriteLine("You pick up the Vase Shards.");
                                    Console.WriteLine("");

                                }
                                else if (Command == "No")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You left the Vase Shards on the floor.");
                                    Console.WriteLine("");
                                }

                                else
                                {
                                    Console.WriteLine("Does not recognise action. Please try again");
                                    Console.WriteLine("");
                                }
                            }
                        }
                        else if (Command == "Shield" || Command == "Use Shield")
                        {
                            if (!backPack.Contains("Shield") && ShieldOnStatue == false) // Om skölden inte är i ryggan eller på statyn.
                            {
                                Console.WriteLine("\nThe Statue seems to be missing its Shield...\n");
                            }
                            else if (ShieldOnStatue == true)    // Om skölden är uppe på statyn
                            {
                                Console.WriteLine("\nThe Shield is now in its right place!\n");
                            }
                            else if (backPack.Contains("Shield"))
                            {
                                Console.WriteLine("\nDo you want to put the Shield on the statue?\n");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Remove("Shield");
                                    SecondRoomItems.Add("Shield");
                                    ShieldOnStatue = true;
                                    HiddenDoorOpen = true;
                                    Console.WriteLine("\nYou put the Shield on its right place!\nThe walls starts to shake, and you hear a loud noise from the room to the North\n");
                                }
                                else if (Command == "No") { Console.WriteLine("\nThe Shield remains in your Backpack\n"); }
                                else { Console.WriteLine("Does not recognise action. Please try again"); }
                            }

                        }

                        else { Console.WriteLine("Does not recognise action. Please try again"); }
                    }
                }

                while (ThirdRoom == true)                 ///////////////////////////    ROOM 3        /////////////////////////////
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 5);
                    Console.WriteLine("THE LABORATORY");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("The Third Room"); //ska ta bort sen
                    Console.ReadLine();

                    Console.WriteLine("");
                    Console.WriteLine("As soon as you enter this room you are met with the most intoxicating smell that you'll dream of.");
                    Console.WriteLine("The room is quite foggy so it takes a while to see that there's only a Table in the room," +
                        " and a door to the west.");
                    Console.WriteLine("The smell seems to originate from the Table.");
                    if (HiddenDoorOpen == true)
                    {
                        Console.WriteLine("There seems to be a green gas emerging behind a cupboard.");
                    }


                    while (true)
                    {
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Help")
                        {

                            Help();
                        }
                        else if (Command == "Look")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("As soon as you enter this room you are met with the most intoxicating smell that you'll dream of.");
                            Console.WriteLine("The room is quite foggy so it takes a while to see that there's only a Table in the room," +
                                " and a door to the west.");
                            Console.WriteLine("The smell seems to originate from the Table.");
                            if (HiddenDoorOpen == true)
                            {
                                Console.WriteLine("There seems to be a green gas emerging behind a cupboard.");
                            }

                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        else if (Command == "Drop" || Command == "Remove" || Command.Contains("Drop"))
                        {

                            Console.WriteLine("");
                            Console.WriteLine("Which item do you want to drop?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                backPack.Remove(Command);
                                ThirdRoomItems.Add(Command);
                                Console.WriteLine("You put the " + Command + " on the floor.");
                                Console.WriteLine("");

                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Could not find " + Command + " in your inventory.");
                            }
                        }
                        else if (Command == "Use")
                        {
                            Hero.ShowInventory();
                            Console.WriteLine("Which item do you want to use?\n");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                Hero.UseItem(Command);
                            }
                            else
                            {
                                Console.WriteLine("You don't have that in your inventory.\n");
                            }
                        }
                        else if (Command == "Go West" || Command == "West")
                        {
                            ThirdRoom = false;
                            fourthRoom = true;
                            Console.WriteLine("You go to the west");
                            break;
                        }
                        else if (Command == "Cupboard" && HiddenDoorOpen == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You go to the Cupboard and push it backwards and it reveals a small passageway to the East.");
                            Console.WriteLine("");
                        }
                        else if (Command == "East" && HiddenDoorOpen == true || Command == "Go East" && HiddenDoorOpen == true)
                        {
                            ThirdRoom = false;
                            fifthRoom = true;
                            Console.WriteLine("You go to the east.\n");
                            if (fifthEnter == true && Buffs.Contains("Goblinoid"))
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");
                                Console.WriteLine("Suddenly you notice a small green man hiding behind some barrels close to the ladder.");
                                Console.WriteLine("");
                                Console.WriteLine("Goblin: u druck teh green water, soon we brothas. - The goblin says before disappearing.\n");
                                fifthEnter = false;
                            }
                            else if (fifthEnter == true)
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close in escaping.");
                                Console.WriteLine("Suddenly you notice a small green man hiding behind some barrels close to the ladder.");
                                Console.WriteLine("");
                                Console.WriteLine("Goblin: You are not going to take my ladder!!! - The goblin screams and strikes at you.");

                            }
                            else if (fifthEnter == false && Buffs.Contains("Goblinoid"))
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");
                                Console.WriteLine("You also see some barrels besides the ladder, where you once saw a goblin.\n");
                            }
                            else
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close in escaping.");
                                if (FifthRoomFight == false)
                                {
                                    Console.WriteLine("You also see a dead goblin on the floor that you've slain.");
                                }

                            }
                        }
                        else if (Command == "East" && HiddenDoorOpen == false || Command == "Go East" && HiddenDoorOpen == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You see some kitchen furniture in front of a wall. You can't go this way.");
                            Console.WriteLine("");
                        }
                        else if (Command == "South" || Command == "Go South")
                        {
                            ThirdRoom = false;
                            SecondRoom = true;
                            break;
                            Console.WriteLine("You go to the south.");
                        }
                        else if (Command == "North" || Command == "Go North")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You cannot go to the north, it's blocked by a wall.");
                            Console.WriteLine("");
                        }
                        else if (Command == "Table" || Command == "Go To Table" || Command == "Alchemy Table" || Command == "Go To Alchemy Table")
                        {
                            bool AlchemyTable = true;
                            if (CauldronIsFull == true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You approach the Table and it seems to be a Table of an alchemist.");
                                Console.WriteLine("The smell that's filling this room seems to come from a Cauldron.");
                                Console.WriteLine("There are two Cauldrons on the alchemy table.");
                                Console.WriteLine("The cauldron to the right seems to release the scent into the room," +
                                    " whilst the other is scentless.");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You approach the table and it seems to be a table of an alchemist.");
                                Console.WriteLine("The smell that's filling this room seems to come from a Cauldron.");
                                Console.WriteLine("There are two Cauldrons on the alchemy table.");
                                Console.WriteLine("Both of the cauldrons are empty.");
                                Console.WriteLine("");
                            }

                            while (AlchemyTable == true)
                            {

                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if ((Command == "Drink" && CauldronIsFull == true) || (Command == "Take A Sip" && CauldronIsFull == true) || (Command == "Cauldron" && CauldronIsFull == true))
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You must use a container to drink from.");
                                    Console.WriteLine("");

                                }
                                else if ((Command == "Drink" && CauldronIsFull == false) || (Command == "Take A Sip" && CauldronIsFull == false) || (Command == "Cauldron" && CauldronIsFull == false))
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("There is not any liquid left in the cauldrons.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "Use Vial" && backPack.Contains("Vial") && CauldronIsFull == true
                                    || Command == "Vial" && backPack.Contains("Vial") && CauldronIsFull == true
                                    || Command == "Fill Vial" && backPack.Contains("Vial") && CauldronIsFull == true
                                    || Command == "Fill" && backPack.Contains("Vial") && CauldronIsFull == true)
                                {
                                    bool UsingAlchTable = true;
                                    while (UsingAlchTable == true)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("The right cauldron is filled with white liquid." +
                                            " It also releases a scent that's almost irresistable.");
                                        Console.WriteLine("The left cauldron is green and almost looks ominous. " +
                                            "It doesn't smell like anything.");
                                        if (Hero.Char_Intelligence >= 10)
                                        {
                                            Console.WriteLine("Due to your high intelligence you figure out that the right cauldron might be " +
                                                "really dangerous to consume...");
                                        }
                                        Console.WriteLine("Which one do you want to use the vial on?");
                                        Console.WriteLine("");
                                        Command = FirstUpperCase(Console.ReadLine().ToLower());

                                        if (Command == "Right" || Command == "White")
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You fill the vial with the white liquid. " +
                                                "As you are done, all the liquid in the cauldrons vanish.");
                                            Console.WriteLine("");
                                            backPack.Remove("Vial");
                                            backPack.Add("Vial filled with white liquid");
                                            CauldronIsFull = false;
                                            AlchemyTable = false;
                                            UsingAlchTable = false;
                                        }
                                        else if (Command == "Left" || Command == "Green")
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You fill the vial with the green liquid. " +
                                                "As you are done, all the liquid in the cauldrons vanish.");
                                            Console.WriteLine("");
                                            backPack.Remove("Vial");
                                            backPack.Add("Vial filled with green liquid");
                                            CauldronIsFull = false;
                                            AlchemyTable = false;
                                            UsingAlchTable = false;
                                        }
                                        else if (Command == "Back")
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("You move away from the alchemy table.");
                                            Console.WriteLine("");
                                            UsingAlchTable = false;
                                        }

                                        else
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("Does not understand input. Try again.");
                                            Console.WriteLine("");
                                        }
                                    }
                                }
                                else if (Command == "Use Vial" && backPack.Contains("Vial")
                                    || Command == "Vial" && backPack.Contains("Vial")
                                    || Command == "Fill Vial" && backPack.Contains("Vial")
                                    || Command == "Fill" && backPack.Contains("Vial"))
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("There is no liquid left in the cauldrons to fill the container with.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "Use Vial" && !backPack.Contains("Vial") && CauldronIsFull == true
                                    || Command == "Vial" && !backPack.Contains("Vial") && CauldronIsFull == true
                                    || Command == "Fill Vial" && !backPack.Contains("Vial") && CauldronIsFull == true
                                    || Command == "Fill" && !backPack.Contains("Vial") && CauldronIsFull == true)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You don't have a container to fill.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "Use Vial" && !backPack.Contains("Vial")
                                    || Command == "Vial" && !backPack.Contains("Vial")
                                    || Command == "Fill Vial" && !backPack.Contains("Vial")
                                    || Command == "Fill" && !backPack.Contains("Vial"))
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You don't have a container to fill. But even so, there isn't even any liquid left here.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "Right" && CauldronIsFull == true)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("The right cauldron is filled with white liquid. It also releases a scent that's almost irresistable.");
                                    Console.WriteLine("");

                                }
                                else if (Command == "Right")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("The cauldron is empty.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "Left" && CauldronIsFull == true)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("The left cauldron is green and almost looks ominous. It doesn't smell like anything.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "Left")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("The cauldron is empty.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "Back")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You move away from the alchemy table.");
                                    Console.WriteLine("");
                                    AlchemyTable = false;
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Does not understand input. Try again.");
                                    Console.WriteLine("");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Does not understand input. Try again.");
                            Console.WriteLine("");
                        }
                    }

                }

                while (fourthRoom == true)    ///////////////////////////////////////////     ROOM 4    /////////////////////////////////
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 5);
                    Console.WriteLine("THE TROPHY ROOM");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("The Fourth Room"); //ska ta bort sen
                    Console.ReadLine();


                    // Skriver vilket rum man är i
                    roomFour.RoomInfo();

                    while (true)
                    {
                        Command = FirstUpperCase(Console.ReadLine().ToLower());

                        if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }

                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }

                        else if (Command == "Drop")
                        {
                            // Inventory skrivs ut och du väljer vad du vill droppa
                            Console.WriteLine("What item do you want to drop?");
                            Hero.ShowInventory();


                            string itemToDrop = FirstUpperCase(Console.ReadLine().ToLower());

                            // Kollar att du har föremålet du vill droppa
                            if (Hero.CheckBackPack(itemToDrop))
                            {
                                // Föremålet droppas och läggstill i nuvarande rummets itemlista
                                Hero.DropInventory(itemToDrop);
                                roomFour.AddRoomItem(itemToDrop);
                            }
                            else
                            {
                                Console.WriteLine("No such item in your inventory");
                            }
                        }

                        else if (Command == "Use")
                        {
                            Hero.ShowInventory();
                            Console.WriteLine("Which item do you want to use?\n");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                Hero.UseItem(Command);
                            }
                            else
                            {
                                Console.WriteLine("You don't have that in your inventory.\n");
                            }
                        }

                        else if (Command == "Shield"  || Command == "Silver Shield" || Command == "Carpet" || Command == "Painting" || Command == "Mirror")
                        {
                            if (Command == "Painting")
                            {
                                if (roomOne.castleSeen == true)
                                {
                                    Console.WriteLine("The painting is a resebles the castle you saw from the window in the first room");
                                }
                                else
                                {
                                    Console.WriteLine("The painting resebles a big Castel");
                                }
                            }
                            
                            roomFour.RoomAction(Hero, Command);
                        }
                        else if (Command == "Look")
                        {
                            // Får ny information om rummet
                            List<string> itemsOnFloor = roomFour.RoomInfo(); // Om man har droppat något från sin väska i rummet får man möjligheten att plocka upp det på en gång
                            if (itemsOnFloor != null)
                            {
                                foreach (var thing in itemsOnFloor)
                                {
                                    // Allt man plockar upp läggs i ditt inventory
                                    Hero.AddInventory(thing);
                                }
                            }
                            Console.WriteLine(""); // Skriv vad man ser i rummet

                        }

                        // Lämnar rummet
                        else if (Command == "Go East" || Command == "East")
                        {
                            Console.WriteLine("You are leaving the trophy room");
                            fourthRoom = false;
                            // ThirdRoom = true;
                            FirstRoom = true;
                            break;
                            
                        }

                        // Går ej att gå hit
                        else if (Command == "Go North" || Command == "Go West" || Command == "Go South" || Command == "North" || Command == "West" || Command == "South")
                        {
                            Console.WriteLine("You can't go there, the only exit is to the East.");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Does not understand input. Try again.");
                            Console.WriteLine("");
                        }

                    }
                }

                while (fifthRoom == true)
                {

                    if (Buffs.Contains("Goblinoid"))//Kräver att man ska dricka från gröna grytan i köksrummet
                    {

                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Help")
                        {
                            Help();
                        }
                        else if (Command == "Look")
                        {
                            Console.WriteLine("You are inside a small room with a ladder going to the roof, near some barrels.");
                            Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");
                            Console.WriteLine("You also see some barrels besides the ladder, where you once saw a goblin.\n");
                            Console.WriteLine("");
                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }
                        else if (Command == "Use")
                        {
                            Hero.ShowInventory();
                            Console.WriteLine("Which item do you want to use?\n");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                Hero.UseItem(Command);
                            }
                            else
                            {
                                Console.WriteLine("You don't have that in your inventory.\n");
                            }
                        }
                        else if (Command == "Drop" || Command == "Remove" || Command.Contains("Drop"))
                        {

                            Console.WriteLine("");
                            Console.WriteLine("Which item do you want to drop?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                backPack.Remove(Command);
                                FifthRoomItems.Add(Command);
                                Console.WriteLine("You put the " + Command + " on the floor.");
                                Console.WriteLine("");

                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Could not find " + Command + " in your inventory.");
                            }
                        }
                        else if (Command == "Barrel" || Command == "Barrels")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You walk to the barrels where you saw the goblin from before.");
                            Console.WriteLine("You inspect the barrels but they are all empty.\n");
                        }
                        else if (Command == "Goblin")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You can see no sign where the goblin went, or even how he did it.");
                            Console.WriteLine("What did he mean by 'soon we are brothers'?\n");
                        }
                        else if (Command == "Ladder" || Command == "Go To Ladder" || Command == "Use Ladder")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You climb up the ladder and reach the top. There is another room, and not the outside as you thought.");
                            Console.WriteLine("It seems like it will take a long time to get out of this labyrinth.");
                            EndGame = true;
                        }

                    }
                    else
                    {
                        Monster.CreateMonster("Goblin");
                        while (FifthRoomFight == true)
                        {


                            Console.WriteLine("");
                            Console.WriteLine("Do you want to Hit or Run?\n");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Run")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You run into the small passageway but the goblin attacked you on the way out.");
                                Console.WriteLine("It seems that the goblin decided to stay in the ladder room and you got away.");
                                FifthRoomFight = false;
                                fifthRoom = false;
                                ThirdRoom = true;
                            }
                            else if (Command == "Fight" || Command == "Hit")
                            {
                                Monster.Hp_Current -= Hero.AttackDamage("Goblin");
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You can only Fight or Run in this situation.");

                            }
                            Hero.HpDamage(Monster.MonsterHit("Goblin"), "Goblin");
                            if (Monster.Hp_Current <= 0)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You have defeated the goblin!");
                                Console.WriteLine("You have " + Hero.Hp_Current + " health left.\n");
                                Monster.MonsterLoot("Goblin");
                                FifthRoomFight = false;
                            }
                            else if (Hero.Hp_Current <= 0)
                            {
                                EndGame = true;
                                FifthRoomFight = false;
                            }
                        }

                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Help")
                        {
                            Help();
                        }
                        else if (Command == "Look")
                        {
                            Console.WriteLine("You are inside a small room with a ladder going to the roof, near some barrels.");
                            Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");
                            Console.WriteLine("There is also a dead goblin on the floor.");
                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }
                        else if (Command == "Use")
                        {
                            Hero.ShowInventory();
                            Console.WriteLine("Which item do you want to use?\n");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                Hero.UseItem(Command);
                            }
                            else
                            {
                                Console.WriteLine("You don't have that in your inventory.\n");
                            }
                        }
                        else if (Command == "Drop" || Command == "Remove" || Command.Contains("Drop"))
                        {

                            Console.WriteLine("");
                            Console.WriteLine("Which item do you want to drop?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                backPack.Remove(Command);
                                FifthRoomItems.Add(Command);
                                Console.WriteLine("You put the " + Command + " on the floor.");
                                Console.WriteLine("");

                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Could not find " + Command + " in your inventory.");
                            }
                        }
                        else if (Command == "Barrel" || Command == "Barrels")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You walk to the barrels where you saw the goblin from before.");
                            Console.WriteLine("You inspect the barrels but they are all empty.\n");
                        }
                        else if (Command == "Goblin" || Command == "Loot Goblin" || Command == "Loot")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You see a dead goblin on the floor.");
                            Monster.ShowMonsterLoot();
                        }
                        else if (MonsterLoot.Contains(Command))
                        {
                            backPack.Add(Command);
                            Console.WriteLine("You add " + Command + " in your backpack.\n");
                            MonsterLoot.Remove(Command);
                        }
                        else if (Command == "Ladder" || Command == "Go To Ladder" || Command == "Use Ladder")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You climb up the ladder and reach the top. There is another room, and not the outside as you thought.");
                            Console.WriteLine("It seems like it will take a long time to get out of this labyrinth.");

                            EndGame = true;
                            fifthRoom = false;
                        }
                        else
                        {
                            Console.WriteLine("Do not understand input, try again.\n");
                        }
                    }
                }


            } while (EndGame == false);
            if (EndGame == true && Hero.Hp_Current == 0)
            {
                Console.WriteLine("You are dead.");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("You made it out. Congratulations!");
                Console.ReadLine();
            }

        }





        // Sätter första bokstaven til STOR och resten till små. Förstod inte riktigt den andra metoden vi använder så gjorde en egen ;P

        public static void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("Here is a few commands that you can write in this game.");
            Console.WriteLine("Go North/Go South/Go East/Go West - To move through the game.");
            Console.WriteLine("Backpack - To show current items in your backpack.");
            Console.WriteLine("Help - To get room info and to be able to interact with the objects");
            Console.WriteLine("Tip: Sometimes you can take items from the room you are in, so try write them and see what happens.");
            Console.WriteLine("If you want more information about commands, type Command.\n");
            string command = Console.ReadLine().ToLower();
            if (command == "command")
            {
                GetCommand();
            }
            
        }

        // Alla kommandon du kan skriva från main programmet.
        public static void GetCommand()
        {
            List<string> allCommands = new List<string>();
            allCommands.Add("Go North");
            allCommands.Add("Go South");
            allCommands.Add("Go East");
            allCommands.Add("Go South");
            allCommands.Add("Backpack");
            allCommands.Add("Look");
            allCommands.Add("Take");
            allCommands.Add("Place");
            allCommands.Add("Drop");
            allCommands.Add("Status");
            allCommands.Add("Back");
            allCommands.Add("Help");

            Console.WriteLine();
            for (int i = 0; i < allCommands.Count; i++)
            {
                Console.WriteLine(allCommands[i]);
            }
            Console.WriteLine();

        }

        // Intro texten nu i egen metod för att kunna förmiska det
        public static void WelcomeMessage(string name, string character)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.WindowHeight / 2 - 5);
            Console.WriteLine("Welcome {0} to the Age of Labyrinths. You have chosen to be a {1}.", name, character);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 17, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Press enter to start your adventure.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 19, Console.WindowHeight / 2 - 3);
            Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(0, 30);
        }

        public static string WelcomeName(string name) //Detta körs vid starten och sparar ditt namn
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 5);
            Console.WriteLine("Welcome to the Age of Labyrinths.");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Please select a name for your character: ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 1);
            name = Console.ReadLine().ToLower();
            return name;

        }

        public static string WelcomeVoc(string type)//Detta körs vid starten och sparar ditt voc (ifall du skriver fel blir det WL
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 5);
            Console.WriteLine("Welcome to the Age of Labyrinths.");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Please select a vocation: Barbarian, Knight, Thief, Warlok");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 1);
            type = Console.ReadLine().ToLower();
            return type;

        }

        static string FirstUpperCase(string text)//Gör om all input till konsolen (BANAN) till bara stor förstabokstav (Banan)
        {
            text = new CultureInfo("en-US").TextInfo.ToTitleCase(text);
            return text;
        }


        //Här nedan är bordern med stats och namn som inte är inlagt ännu. Vill få denna att limmas fast längst upp i konsolfönstret
        public static void WriteTop(string Char_Name, int Char_Backpack, string Char_Voc, int Char_Current_HP, int Char_Max_HP)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.SetCursorPosition(0 + i, 0);
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");

            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(5, 0);
            Console.Write("Name: " + Char_Name + " the " + Char_Voc);
            Console.SetCursorPosition(35, 0);
            Console.Write("HP: " + Char_Current_HP + "/" + Char_Max_HP);
            Console.SetCursorPosition(55, 0);
            Console.Write("Items in backpack: " + Char_Backpack);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, Console.WindowHeight / 2);

        }
    }
}