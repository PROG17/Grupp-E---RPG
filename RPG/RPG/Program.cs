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
            bool firstEnter = true;
            bool FirstDoorOpen = false;
            bool FirstItemIsFound = false;
            bool FirstRoomIronBarWindow = true;
            bool CheckChestOpen = false;
            bool vaseBroken = false;
            bool EndGame = false;
            bool HiddenDoorOpen = false;
            bool CauldronIsFull = true;

            string Char_Name = "David";
            string Char_Voc = "Cool";
            string Command = "";

            List<string> FirstRoomItems = new List<string>();
            List<string> SecondRoomItems = new List<string>();
            List<string> ThirdRoomItems = new List<string>();
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
            var roomOne = new Rooms(1);
            var roomTwo = new Rooms(2);
            var roomThree = new Rooms(3);
            var roomFour = new Rooms(4);
            var roomFive = new Rooms(5);

            List<string> backPack = Hero.GetBackPack();


            do
            {
                while (FirstRoom == true)
                {
                    //WriteTop(Char_Name, Char_Backpack.Count, Char_Voc, Char_Current_HP, Char_Max_HP);

                    var firstRoom = new Rooms(1);

                    if (firstEnter == true)
                    {
                        firstRoom.RoomInfo();
                        firstEnter = false;
                    }

                    Command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (Command == "Help")
                    {
                        Help();
                    }
                    else if (Command == "Rum2") //FUSK FÖR ATT HAMNA I RUM 2
                    {
                        FirstDoorOpen = true;
                        FirstRoom = false;
                        SecondRoom = true;
                    }
                    else if (Command == "Look")
                    {
                        Console.WriteLine(
                            "\nThe room you are in has a wooden Door and one Window that seems to be blocked by Iron Bars.");
                        Console.WriteLine("You also see a beautifully ordinated Chest.");
                        Console.WriteLine(
                            "To the East you see a Door that's shut. Besides it you see a Table with some debris on it.");
                        Console.WriteLine("");
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
                            FirstRoomItems.Add(Command);
                            Console.WriteLine("You put the " + Command + " on the floor.");
                            Console.WriteLine("");

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Could not find " + Command + " in your inventory.");
                        }
                    }


                    else if (Command == "Chest" || Command == "Go To Chest")
                    {
                        if (CheckChestOpen == true && ChestItem.Contains("Vial"))
                        {
                            Console.WriteLine("");
                            Console.WriteLine(
                                "The Chest is opened wide. There is a Vial in here. Do you want to pick it up?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Yes")
                            {
                                backPack.Add("Vial");
                                ChestItem.Replace("Vial", "");
                                Console.WriteLine("You picked up the Vial.");
                                Console.WriteLine("");
                            }
                            else if (Command == "No")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You left the Vial in the Chest.");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Do not understand input. Going back to the middle of the room.");
                                Console.WriteLine("");
                            }
                        }


                        else if (CheckChestOpen == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(
                                "The Chest is beautifully ornated with purple lion emblems on the sides.");
                            Console.WriteLine(
                                "You examine it more closely but it seems that you can't open it without a key.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Use Lion Key" || Command == "Lion Key")
                            {
                                CheckChestOpen = true;
                                Console.WriteLine("");
                                Console.WriteLine("You open the Chest with the Lion Key!");
                                Console.WriteLine("There is a Vial in here. Do you want to pick it up?");
                                Console.WriteLine("");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Add("Vial");
                                    ChestItem.Replace("Vial", "");
                                    Console.WriteLine("You picked up the Vial.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "No")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You left the Vial in the Chest.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Do not understand input. Going back to the middle of the room.");
                                    Console.WriteLine("");
                                }
                            }
                            else if (Command == "Use Iron Bar" && backPack.Contains("Iron Bar") ||
                                     Command == "Iron Bar" && backPack.Contains("Iron Bar") ||
                                     Command == "Iron Pipe" && backPack.Contains("Iron Bar"))
                            {
                                CheckChestOpen = true;
                                Console.WriteLine("");
                                Console.WriteLine("You pry open the Chest with the Iron Bar!");
                                Console.WriteLine("There is a Vial in here. Do you want to pick it up?");
                                Console.WriteLine("");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Add("Vial");
                                    ChestItem.Replace("Vial", "");
                                    Console.WriteLine("You picked up the Vial.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "No")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You left the Vial in the Chest.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Do not understand input. Going back to the middle of the room.");
                                    Console.WriteLine("");
                                }
                            }

                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Does not understand input. Going back to the middle of the room");
                                Console.WriteLine("");
                            }
                        }
                    }
                    else if (Command == "Window" || Command == "Go to Window")
                    {
                        Console.WriteLine("");
                        Console.WriteLine(
                            "You look past the Iron Bars through the Window and you see a giant white castle on a green hill.");
                        Console.WriteLine("The castle have four towers that seems to stretch towards the heaven.");
                        Console.WriteLine(
                            "You also see two mountains in the distance that makes the castle even more beautiful.");
                        Console.WriteLine("However you get the feeling that there's no one in the castle.");
                        Console.WriteLine("");
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Open" || Command == "Open Window")
                        {
                            Console.WriteLine("");
                            Console.WriteLine(
                                "The Window is closed and can't be opened. Even if you could open it it's blocked by Iron Bars.");
                            Console.WriteLine("Going back to the middle of the room.");
                            Console.WriteLine("");

                        }
                        else if (Command == "Iron Bar" && FirstRoomIronBarWindow == false ||
                                 Command == "Iron Bars" && FirstRoomIronBarWindow == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(
                                "You've already taken one of the Iron Bars. Besides you couldn't even take another one.");
                        }
                        else if (Command == "Iron Bar" && FirstRoomIronBarWindow == true ||
                                 Command == "Iron Bars" && FirstRoomIronBarWindow == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(
                                "You take a look at the Iron Bars and you notice that one of the bars is loose.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Get Iron Bar" || Command == "Pick Up Iron Bar" ||
                                Command == "Take Iron Bar" || Command == "Pull Iron Bar" || Command == "Take")
                            {
                                Console.WriteLine("");
                                Console.WriteLine(
                                    "You successfully pulled the Iron Bar from the Window and put it in your Backpack.");
                                Console.WriteLine("");
                                backPack.Add("Iron Bar");
                                FirstRoomIronBarWindow = false;

                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You move away from the Window.");
                                Console.WriteLine("");
                            }

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You move away from the Window.");
                            Console.WriteLine("");
                        }
                    }
                    else if (Command == "Table" || Command == "Go To Table")
                    {
                        if (FirstRoomItems.Contains("Rusty Key") && FirstItemIsFound == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(
                                "You look through the debris and the only thing worth noticing is a Rusty Key.");
                            Console.WriteLine("Maybe this can be useful.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            Console.WriteLine("");
                            if (Command == "Rusty Key")
                            {

                                backPack.Add(Command);
                                FirstRoomItems.Remove(Command);

                                Console.WriteLine("You put the Rusty Key in your Backpack.");
                                Console.WriteLine("");
                                FirstItemIsFound = true;
                            }
                            else if (Command == "No")
                            {
                                Console.WriteLine("You leave the Rusty Key on the Table.");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("Could not interpret action");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You go to the Table and check but there is nothing here.");
                        }
                    }
                    else if (Command == "Go East" || Command == "East" || Command == "Door" ||
                             Command == "Inspect Door")
                    {
                        if (FirstDoorOpen == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Go to second room");
                            SecondRoom = true;
                        }
                        else if (FirstDoorOpen == false)
                        {

                            Console.WriteLine("");
                            Console.WriteLine(
                                "You approach the wooden Door. The Door is locked but the lock seems old.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            Console.WriteLine("");
                            if (Command == "Use Rusty Key" || Command == "Rusty Key")
                            {
                                if (backPack.Contains("Rusty Key"))
                                {
                                    Console.WriteLine("You unlocked the Door");
                                    Console.WriteLine("");
                                    FirstDoorOpen = true;
                                    FirstRoom = false;
                                    SecondRoom = true;
                                    backPack.Remove("Rusty Key");
                                }
                            }
                            else if (Command == "Push" || Command == "Break")
                            {
                                if (Hero.Char_Strength >= 10)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You smash the Door open with your unbridled power.");
                                    Console.WriteLine("");
                                    FirstDoorOpen = true;
                                    FirstRoom = false;
                                    SecondRoom = true;
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "The Door is old but is sturdy enough to withstand the force of your impact.");
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Does not recognize action. Please try again");
                                Console.WriteLine("");
                            }
                        }
                    }
                    else if (Command == "Chest" || Command == "Go To Chest")
                    {
                        if (CheckChestOpen == true && ChestItem.Contains("Vial"))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The Chest is opened wide. There is a Vial in here. Do you want to pick it up?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Yes")
                            {
                                backPack.Add("Vial");
                                backPack.Remove("Vial");
                                Console.WriteLine("You picked up the Vial.");
                                Console.WriteLine("");
                            }
                            else if (Command == "No")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You left the Vial in the Chest.");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Do not understand input. Going back to the middle of the room.");
                                Console.WriteLine("");
                            }
                        }


                        else if (CheckChestOpen == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The Chest is beautifully ornated with purple lion emblems on the sides.");
                            Console.WriteLine("You examine it more closely but it seems that you can't open it without a key.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Use Lion Key" || Command == "Lion Key")
                            {
                                CheckChestOpen = true;
                                Console.WriteLine("");
                                Console.WriteLine("You open the Chest with the Lion Key!");
                                Console.WriteLine("There is a Vial in here. Do you want to pick it up?");
                                Console.WriteLine("");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Add("Vial");
                                    backPack.Remove("Vial");
                                    Console.WriteLine("You picked up the Vial.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "No")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You left the Vial in the Chest.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Do not understand input. Going back to the middle of the room.");
                                    Console.WriteLine("");
                                }
                            }
                            else if (Command == "Use Iron Bar" && backPack.Contains("Iron Bar")
                                || Command == "Iron Bar" && backPack.Contains("Iron Bar")
                                || Command == "Iron Pipe" && backPack.Contains("Iron Bar"))
                            {
                                CheckChestOpen = true;
                                Console.WriteLine("");
                                Console.WriteLine("You pry open the Chest with the Iron Bar!");
                                Console.WriteLine("There is a Vial in here. Do you want to pick it up?");
                                Console.WriteLine("");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Add("Vial");
                                    backPack.Remove("Vial");
                                    Console.WriteLine("You picked up the Vial.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "No")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You left the Vial in the Chest.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Do not understand input. Going back to the middle of the room.");
                                    Console.WriteLine("");
                                }
                            }

                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Does not understand input. Going back to the middle of the room");
                                Console.WriteLine("");
                            }
                        }
                    }


                    else if (Command == "Go West" || Command == "West" || Command == "Go South" || Command == "South" ||
                             Command == "Go North" || Command == "North")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You cannot go this way. The only way out seems to be to the East");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Does not understand input. Try again.");
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
                    Console.WriteLine("By the East wall stands a Statue of a knight in battle.\nHe holds a Sword in his right hand.\n");
                    Console.WriteLine("To the North you see an open door.");
                    Console.WriteLine("To the West you see the room you woke up in.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");

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
                                "\nYou walk up to the Statue.\nThe knight has a Sword and armor, but no Shield... ");
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
                                    "| :|               SINE GLADIO,  ET NON MORIERIS                 |: |");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                    Console.WindowHeight / 2 - 6);
                                if (Char_Voc == "Knight")
                                {
                                    Console.WriteLine(
                                   "|: |              WITHOUT THE SWORD, YOU WILL DIE                | :|");

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
                            Console.WriteLine("");
                            Console.WriteLine("Here is a few commands that you can write in this game.");
                            Console.WriteLine("Go North/Go South/Go East/Go West - To move through the game.");
                            Console.WriteLine("Backpack - To show current items in your backpack.");
                            Console.WriteLine(
                                "Tip: Sometimes you can take items from the room you are in, so try write them and see what happens.");
                            Console.WriteLine("");
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
                                Console.WriteLine(
                                    "By the East wall stands a Statue of a knight in battle.\nHe holds a Sword in his right hand.\n");
                                Console.WriteLine("To the North you see an open door.");
                                Console.WriteLine("To the West you see the room you woke up in.");


                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                            }
                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Console.WriteLine("");
                            if (backPack.Count == 0)
                            {
                                Console.WriteLine("You have no items in your Backpack.");
                                Console.Write("");
                            }
                            else
                            {
                                for (int i = 0; i < backPack.Count; i++)
                                {
                                    Console.WriteLine(i + 1 + ": " + backPack[i]);
                                }
                                Console.WriteLine("Press <Enter> to go back");
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
                        else { Console.WriteLine("Does not recognise action. Please try again"); }
                    }
                }




                while (fourthRoom == true)     //////////////////////////       ROOM 4    /////////////////////////////////////
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 - 5);
                    Console.WriteLine("THE TROPHY ROOM");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("The Fourth Room"); //ska ta bort sen
                    Console.ReadLine();


                    // Skriver vilket rum man är i
                    Console.Write("Yor are in the ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Trophy Room");
                    Console.ResetColor();

                    // Hämtar ett kommando från metod
                    Command = GetCommand();

                    // Du skickas till lämplig if-sats beroende på kommandot
                    if (Command == "Status")
                    {
                        // Skriver ut dina stats
                        Hero.TypeStats();
                    }
                    else if (Command == "Backpack")
                    {
                        // Skrier ut ditt inventory
                        Hero.ShowInventory();
                    }
                    else if (Command == "Look")
                    {
                        // Får ny information om rummet
                        List<string>
                            itemsOnFloor =
                                roomFour
                                    .RoomInfo(); // Om man har droppat något från sin väska i rummet får man möjligheten att plocka upp det på en gång
                        if (itemsOnFloor != null)
                        {
                            foreach (var thing in itemsOnFloor)
                            {
                                // Allt man plockar upp läggs i ditt inventory
                                Hero.AddInventory(thing);
                            }
                        }

                        // Om man väljer att plocka ner skölden hamnar den i inventory
                        string item = roomFour.RoomActin();
                        Hero.AddInventory(item);

                    }

                    // Droppar item från inventory 
                    else if (Command == "Drop")
                    {
                        // Inventory skrivs ut och du väljer vad du vill droppa
                        Console.WriteLine("What item do you want to drop?");
                        Hero.ShowInventory();
                        string itemToDrop = FirstToUpper();

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
                    // Lämnar rummet
                    else if (Command == "Go east")
                    {
                        Console.WriteLine("You are leaving the trophy room");
                        fourthRoom = false;
                        ThirdRoom = true;
                    }

                    // Går ej att gå hit
                    else if (Command == "Go north" || Command == "Go west" ||
                             Command == "Go south")
                    {
                        Console.WriteLine("Cant go there, the only exit is to the east");
                    }

                }

                while (fifthRoom == true)
                {

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
                            break;
                            Console.WriteLine("You go to the East");
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
                    Console.Write("Yor are in the ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Trophy Room");
                    Console.ResetColor();
                    roomFour.RoomInfo();

                    while (true)
                    {
                        Command = FirstUpperCase(Console.ReadLine().ToLower());


                        // Hämtar ett kommando från metod
                        //Command = GetCommand();

                        // Du skickas till lämplig if-sats beroende på kommandot
                        if (Command == "Status")
                        {
                            // Skriver ut dina stats
                            Hero.TypeStats();
                        }
                        else if (Command == "Backpack")
                        {
                            // Skrier ut ditt inventory
                            Hero.ShowInventory();
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

                            // Om man väljer att plocka ner skölden hamnar den i inventory
                            string item = roomFour.RoomActin();
                            Hero.AddInventory(item);

                        }

                        // Droppar item från inventory 
                        else if (Command == "Drop")
                        {
                            // Inventory skrivs ut och du väljer vad du vill droppa
                            Console.WriteLine("What item do you want to drop?");
                            Hero.ShowInventory();
                            string itemToDrop = FirstToUpper();

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
                        // Lämnar rummet
                        else if (Command == "Go East")
                        {
                            Console.WriteLine("You are leaving the trophy room");
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


            } while (EndGame == false);


        }





        // Sätter första bokstaven til STOR och resten till små. Förstod inte riktigt den andra metoden vi använder så gjorde en egen ;P
        public static string FirstToUpper()
        {
            string text = Console.ReadLine();
            if (text.Length > 1)
            {
                text = text.First().ToString().ToUpper() + text.Substring(1).ToLower();
            }

            return text;
        }
        public static void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("Here is a few commands that you can write in this game.");
            Console.WriteLine("Go North/Go South/Go East/Go West - To move through the game.");
            Console.WriteLine("Backpack - To show current items in your backpack.");
            Console.WriteLine(
                "Tip: Sometimes you can take items from the room you are in, so try write them and see what happens.");
            Console.WriteLine("If you want more information about commands, type Command. Otherwise, type Back.\n");
            string command = Console.ReadLine().ToLower();
            if (command == "command")
            {
                GetCommand();
            }
            else
            {

            }

        }

        // Alla kommandon du kan skriva från main programmet.
        public static string GetCommand()
        {
            List<string> allCommands = new List<string>();
            allCommands.Add("Go north");
            allCommands.Add("Go south");
            allCommands.Add("Go east");
            allCommands.Add("Go south");
            allCommands.Add("Backpack");
            allCommands.Add("Look");
            allCommands.Add("Take");
            allCommands.Add("Place");
            allCommands.Add("Drop");
            allCommands.Add("Status");
            allCommands.Add("Back");
            allCommands.Add("Help");

            // Loopen kollar att det du skriver är tillåtet
            //do
            //{
            //Console.WriteLine();
            //Console.Write(": ");
            //string command = Console.ReadLine();
            //Console.WriteLine();

            //if (command != "")
            //{
            //    command = command.First().ToString().ToUpper() + command.Substring(1).ToLower();
            //}
            //////////////////////////////////////////////
            ////Console.WriteLine("Exists in Room 1: ");
            ////foreach (var item in FirstRoomItems)
            ////{

            ////    Console.Write(item + Environment.NewLine);
            ////}
            ////Console.WriteLine("");
            //////////////////////////////////////////////
            //if (allCommands.Contains(command))
            //{
            //    if (command == "Help")
            //    {
            //        foreach (var item in allCommands)
            //        {
            //            Console.WriteLine(item);
            //        }
            //    }
            //    else
            //    {
            //        return command;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Unknowned command");
            //    Console.WriteLine("To get a list of all commands type: Help");
            //    Console.WriteLine();
            //}
            Console.WriteLine();
            for (int i = 0; i < allCommands.Count; i++)
            {
                Console.WriteLine(allCommands[i]);
            }
            Console.WriteLine();
            return allCommands[0];

            //} while (true);



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

        }
    }
}