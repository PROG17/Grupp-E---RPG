using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Media;

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
            bool fifthEnter = true;
            bool FirstDoorOpen = false;
            bool FirstItemIsFound = false;
            bool FirstRoomIronBarWindow = true;
            bool CheckChestOpen = false;
            //bool vaseBroken = false;
            bool EndGame = false;
            bool CauldronIsFull = true;
            bool ShieldOnStatue = false;

            string Char_Name = "David";
            string Char_Voc = "Cool";
            string Command = "";

            var Ascii = new ASCII();
            List<string> FirstRoomItems = new List<string>();
            List<string> SecondRoomItems = new List<string>();
            List<string> ThirdRoomItems = new List<string>();
            List<string> FifthRoomItems = new List<string>();
            FirstRoomItems.Add("Rusty Key");
            string ChestItem = "Vial";

            SoundPlayer Song = new SoundPlayer(@"c:\Age of Labyrinth.WAV");   // Spelar upp låten
            Song.PlayLooping();

            // Sätter namn och karaktär, Warlock som defaul
            //Ascii.WelcomeStart();

            Console.CursorVisible = true;
            Char_Name = FirstUpperCase(WelcomeName(Char_Name));
            Char_Voc = FirstUpperCase(WelcomeVoc(Char_Voc));
            if (Char_Voc != "Barbarian" && Char_Voc != "Knight" && Char_Voc != "Thief" && Char_Voc != "Warlock")
            {
                Char_Voc = "Warlock";
            }

            WelcomeMessage(Char_Name, Char_Voc);
            Song.Stop();   //Stoppar låten

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
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 5);
                    Console.WriteLine("THE GUESTROOM");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("The First Room"); //ska ta bort sen
                    Console.ReadLine();
                    Console.Clear();
                    Console.SetCursorPosition(0, 30);
                    if (firstEnter == true)
                    {
                        roomOne.RoomInfo();
                        firstEnter = false;
                    }
                    while (true)
                    {
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Help")
                        {
                            Help();
                        }
                        //else if (Command == "Tre")
                        //{
                        //    FirstRoom = false;
                        //    ThirdRoom = true;
                        //    break;
                        //}

                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }

                        else if (Command == "Look")
                        {
                            List<string> itemsOnFloor = roomOne.RoomInfo();
                            if (itemsOnFloor != null)
                            {
                                foreach (var thing in itemsOnFloor)
                                {
                                    // Allt man plockar upp läggs i ditt inventory
                                    Hero.AddInventory(thing);
                                }
                            }

                        }

                        else if (Command == "Door" || Command == "Table" || Command == "Window" || Command == "Chest" || Command == "Inspect")
                        {
                            roomOne.RoomAction(Hero, Command);
                        }

                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        else if (backPack.Contains(Command))
                        {
                            Hero.UseItem(Command);
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
                                Hero.DropToRoom(itemToDrop);
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
                                SecondRoom = true;
                                break;



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
                    if (Rooms.vaseBroken == false)  //om vasen är hel
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
                        if (Command == "Vase" || Command == "Statue" || Command == "Inspect" || Command == "Shield" || Command == "Vase Shards" || Command == "Use Vase" || Command == "Take Vase")
                        {
                            roomTwo.RoomAction(Hero, Command);
                        }


                        else if (Command == "West" || Command == "Go West")
                        {
                            SecondRoom = false;
                            FirstRoom = true;
                            roomOne.RoomInfo();
                            break;
                        }
                        else if (Command == "North" || Command == "Go North")
                        {
                            SecondRoom = false;
                            ThirdRoom = true;
                            break;
                        }

                        else if (Command == "Go South" || Command == "South" || Command == "Go East" || Command == "East")
                        {
                            Console.WriteLine("Cant go that way.");
                        }

                        else if (Command == "Help")
                        {
                            Help();
                        }
                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }
                        else if (Command == "Look")
                        {
                            List<string> itemsOnFloor = roomTwo.RoomInfo();
                            if (itemsOnFloor != null)
                            {
                                foreach (var thing in itemsOnFloor)
                                {
                                    // Allt man plockar upp läggs i ditt inventory
                                    Hero.AddInventory(thing);
                                }
                            }
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
                                Hero.DropToRoom(itemToDrop);
                                roomTwo.AddRoomItem(itemToDrop);
                            }
                            else
                            {
                                Console.WriteLine("No such item in your inventory");
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

                    roomThree.RoomInfo();
                    if (Rooms.HiddenDoorOpen == true)
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
                            if (Rooms.HiddenDoorOpen == true)
                            {
                                Console.WriteLine("There seems to be a shining light emerging behind a cupboard.\n");
                            }

                            List<string> itemsOnFloor = roomThree.RoomInfo();
                            if (itemsOnFloor != null)
                            {
                                foreach (var thing in itemsOnFloor)
                                {
                                    // Allt man plockar upp läggs i ditt inventory
                                    Hero.AddInventory(thing);
                                }
                            }

                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }

                        else if (Command == "Drop" || Command == "Remove" || Command.Contains("Drop"))
                        {

                            Console.WriteLine("");
                            Console.WriteLine("Which item do you want to drop?");
                            Console.WriteLine("");
                            Hero.ShowInventory();
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (backPack.Contains(Command))
                            {
                                backPack.Remove(Command);
                                roomThree.AddRoomItem(Command);
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
                        else if (Command == "Cupboard" && Rooms.HiddenDoorOpen == true)
                        {
                            Console.WriteLine("You go to the Cupboard and push it backwards and it reveals a small passageway to the East.\n");
                        }
                        else if (Command == "East" && Rooms.HiddenDoorOpen == true || Command == "Go East" && Rooms.HiddenDoorOpen == true)
                        {

                            Console.WriteLine("You go to the east.\n");
                            if (fifthEnter == true && Buffs.Contains("Goblinoid"))
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");
                                Console.WriteLine("Suddenly you notice a small green man hiding behind some barrels close to the ladder.");
                                Console.WriteLine("Goblin: u druck teh green water, soon we brothas. - The goblin says before disappearing.\n");
                                ThirdRoom = false;
                                fifthRoom = true;
                                fifthEnter = false;

                            }
                            else if (fifthEnter == true)
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");
                                Console.WriteLine("Suddenly you notice a small green man hiding behind some barrels close to the ladder.");
                                Console.WriteLine("Goblin: You are not going to take my ladder!!! - The goblin screams and strikes at you.");
                                ThirdRoom = false;
                                fifthRoom = true;
                                fifthEnter = false;
                            }
                            else if (fifthEnter == false && Buffs.Contains("Goblinoid"))
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");
                                Console.WriteLine("You also see some barrels besides the ladder, where you once saw a goblin.\n");
                                ThirdRoom = false;
                                fifthRoom = true;
                            }
                            else
                            {
                                Console.WriteLine("You crawl through a small opening and get inside a small room with a ladder going to the roof.");
                                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close in escaping.");
                                if (FifthRoomFight == false)
                                {
                                    Console.WriteLine("You also see a dead goblin on the floor that you've slain.");
                                }
                                ThirdRoom = false;
                                fifthRoom = true;
                            }
                            ThirdRoom = false;
                            fifthRoom = true;
                            break;

                        }
                        else if (Command == "East" && Rooms.HiddenDoorOpen == false || Command == "Go East" && Rooms.HiddenDoorOpen == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You see some kitchen furniture in front of a wall. You can't go this way.");
                            Console.WriteLine("");
                        }
                        else if (Command == "South" || Command == "Go South")
                        {
                            ThirdRoom = false;
                            SecondRoom = true;
                            Console.WriteLine("You go to the hallway.");
                            break;

                        }

                        else if (Command == "North" || Command == "Go North")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You cannot go to the north, it's blocked by a wall.");
                            Console.WriteLine("");
                        }
                        else if (Command == "Table" || Command == "Go To Table" || Command == "Alchemy Table" || Command == "Go To Alchemy Table" || Command == "Inspect")
                        {
                            roomThree.RoomAction(Hero, Command);
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
                                Hero.DropToRoom(itemToDrop);
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

                        else if (Command == "Shield" || Command == "Silver Shield" || Command == "Carpet" || Command == "Painting" || Command == "Mirror" || Command == "Inspect") 
                        {
                            if (Command == "Painting")
                            {
                                if (roomOne.castleSeen == true)
                                {
                                    Console.WriteLine("The painting resembles the castle you saw from the window in the first room");
                                }
                                else
                                {
                                    Console.WriteLine("The painting shows a big castle");
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
                            //Console.WriteLine("You are leaving the trophy room");
                            fourthRoom = false;
                            ThirdRoom = true;
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
                            roomFive.RoomInfo();
                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }
                        else if (Command == "Inspect")
                        {
                            roomFive.RoomAction(Hero, Command);
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
                        else if (Command == "Go West" || Command == "West")
                        {
                            //Console.WriteLine("You are leaving the trophy room");
                            fifthRoom = false;
                            ThirdRoom = true;
                            break;
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
                            fifthRoom = false;
                            EndGame = true;
                        }

                    }
                    else
                    {
                        Monster.CreateMonster("Goblin");
                        while (FifthRoomFight == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Do you want to Hit/Fight or Run?\n");
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
                            roomFive.RoomInfo();
                            Console.WriteLine("There is also a dead goblin on the floor.\n");
                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Hero.ShowInventory();
                        }
                        else if (Command == "Status")
                        {
                            Hero.TypeStats();
                        }
                        else if (Command == "Inspect")
                        {
                            roomFive.RoomAction(Hero, Command);
                        }
                        else if (Command == "Go West" || Command == "West")
                        {
                            //Console.WriteLine("You are leaving the trophy room");
                            fifthRoom = false;
                            ThirdRoom = true;
                            break;
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
                Ascii.GameOver();
            }
            else
            {
                Ascii.Win();
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
            //  Console.WriteLine("If you want more information about commands, type Command.\n");
            GetCommand();

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
            Console.WriteLine("Welcome {0} to the Age of Labyrinth. You have chosen to be a {1}.", name, character);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 17, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Press enter to start your adventure.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 19, Console.WindowHeight / 2 - 3);
            Console.ReadLine();
            Console.Clear();



            Console.SetCursorPosition(0, 30);
        }

        public static string WelcomeName(string name) //Detta körs vid starten och sparar ditt namn
        {
            //Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 5);
            //Console.WriteLine("Welcome to the Age of Labyrinth.");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 5);
            Console.WriteLine("Please select a name for your character: ");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 3);
            name = Console.ReadLine().ToLower();
            return name;

        }

        public static string WelcomeVoc(string type)//Detta körs vid starten och sparar ditt voc (ifall du skriver fel blir det WL
        {
            Console.Clear();
            //Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 5);
            //Console.WriteLine("Welcome to the Age of Labyrinths.");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 5);
            Console.WriteLine("Please select a vocation: Barbarian, Knight, Thief, Warlock");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 1);
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