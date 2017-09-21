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
            bool FirstDoorOpen = false;
            bool FirstItemIsFound = false;
            bool FirstRoomIronBarWindow = true;
            bool CheckChestOpen = false;
            bool vaseBroken = false;
            bool EndGame = false;
            string Char_Name = "David";
            string Char_Voc = "Cool";
            string Command = "";
            List<string> FirstRoomItems = new List<string>();
            List<string> SecondRoomItems = new List<string>();
            FirstRoomItems.Add("Rusty Key");
            string ChestItem = "Vial";

            // Sätter namn om karaktär 
            // Warlock som defaul
            Char_Name = FirstUpperCase(WelcomeName(Char_Name));
            Char_Voc = FirstUpperCase(WelcomeVoc(Char_Voc));
            if (Char_Voc != "Barbarian" && Char_Voc != "Knight" && Char_Voc != "Thief" && Char_Voc != "Warlock")
            {
                Char_Voc = "Warlock";
            }


            var Hero = new Character(Char_Name, Char_Voc);
            // Hero.SetStats(Char_Voc);

            Console.WriteLine("Strengh: " + Hero.Char_Strength + "\n" + "Agility: " + Hero.Char_Agility + "\n" + "Intellignece: " + Hero.Char_Intelligence + "\n" + "Hp: " + Hero.Hp);
            Console.WriteLine();


            // Hero.CheckBackPack();
            Hero.AddInventory("Nail");
            // Hero.CheckBackPack();
            Console.ReadLine();
            List<string> backPack = Hero.GetBackPack();
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 30, Console.WindowHeight / 2 - 5);
            Console.WriteLine("Welcome {0} to the Age of Labyrinths. You have chosen to be a {1}.", Char_Name, Char_Voc);
            Console.SetCursorPosition(Console.WindowWidth / 2 - 17, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Press enter to start your adventure.");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 19, Console.WindowHeight / 2 - 3);
            Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(0, 30);
            Console.WriteLine("You wake up in a room. It have a wooden door and one window that seems to be blocked by iron bars.");
            Console.WriteLine("To the east you see a door that's shut. Besides it you see a table with some debris under it.");
            Console.WriteLine("It seems that someone have taken most of your belongings from your backpack.");
            Console.WriteLine("Maybe there's something left somewhere in this room.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            do
            {


                while (FirstRoom == true)
                {
                    Console.WriteLine("*****First Room*****");
                    //WriteTop(Char_Name, Char_Backpack.Count, Char_Voc, Char_Current_HP, Char_Max_HP);


                    Command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (Command == "Help")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Here is a few commands that you can write in this game.");
                        Console.WriteLine("Go North/Go South/Go East/Go West - To move through the game.");
                        Console.WriteLine("Backpack - To show current items in your backpack.");
                        Console.WriteLine("Tip: Sometimes you can take items from the room you are in, so try write them and see what happens.");
                        Console.WriteLine("");
                    }
                    else if (Command == "Rum2")        //FUSK FÖR ATT HAMNA I RUM 2
                    {
                        FirstDoorOpen = true;
                        FirstRoom = false;
                        SecondRoom = true;
                    }


                    else if (Command == "Look")
                    {
                        Console.WriteLine("You wake up in a room. It have a wooden door and one window that seems to be blocked by iron bars.");
                        Console.WriteLine("To the east you see a door that's shut. Besides it you see a table with some debris under it.");
                        Console.WriteLine("It seems that someone have taken most of your belongings from your backpack.");
                        Console.WriteLine("Maybe there's something left somewhere in this room.");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                    else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                    {
                        Console.WriteLine("");
                        if (backPack.Count == 0)
                        {
                            Console.WriteLine("You have no items in your backpack.");
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
                        else
                        {

                        }
                    }
                    else if (Command == "Chest" || Command == "Go To Chest")
                    {
                        if (CheckChestOpen == true && ChestItem.Contains("Vial"))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The chest is opened wide. There is a vial in here. Do you want to pick it up?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Yes")
                            {
                                backPack.Add("Vial");
                                ChestItem.Replace("Vial", "");
                                Console.WriteLine("You picked up the vial.");
                                Console.WriteLine("");
                            }
                            else if (Command == "No")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You left the vial in the chest and walk away.");
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
                            Console.WriteLine("The chest is beautifully ornated with purple lion emblems on the sides.");
                            Console.WriteLine("You examine it more closely but it seems that you can't open it without a key.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Use Lion Key" || Command == "Lion Key")
                            {
                                CheckChestOpen = true;
                                Console.WriteLine("");
                                Console.WriteLine("You open the chest with the lion key!");
                                Console.WriteLine("There is a vial in here. Do you want to pick it up?");
                                Console.WriteLine("");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Add("Vial");
                                    ChestItem.Replace("Vial", "");
                                    Console.WriteLine("You pick up the vial.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "No")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You left the vial in the chest and walk away.");
                                    Console.WriteLine("");
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("Do not understand input. Going back to the middle of the room.");
                                    Console.WriteLine("");
                                }
                            }
                            else if (Command == "Use Iron Bar" && backPack.Contains("Iron Bar") || Command == "Iron Bar" && backPack.Contains("Iron Bar") || Command == "Iron Pipe" && backPack.Contains("Iron Bar"))
                            {
                                CheckChestOpen = true;
                                Console.WriteLine("");
                                Console.WriteLine("You pry open the chest with the iron bar!");
                                Console.WriteLine("There is a vial in here. Do you want to pick it up?");
                                Console.WriteLine("");
                                Command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (Command == "Yes")
                                {
                                    backPack.Add("Vial");
                                    ChestItem.Replace("Vial", "");
                                    Console.WriteLine("You pick up the vial.");
                                    Console.WriteLine("");
                                }
                                else if (Command == "No")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You left the vial in the chest and walk away.");
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
                        Console.WriteLine("You look past the iron bars through the window and you see a giant white castle on a Green hill.");
                        Console.WriteLine("The castle have Four towers that seems to stretch towards the heaven.");
                        Console.WriteLine("You also see Two mountains in the distance that makes the castle even more beautiful.");
                        Console.WriteLine("However you get the feeling that there's No one in the castle.");
                        Console.WriteLine("");
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Open" || Command == "Open Window")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The window is closed and can't be opened. Even if you could open it it's blocked by iron bars.");
                            Console.WriteLine("Going back to the middle of the room.");
                            Console.WriteLine("");

                        }
                        else if (Command == "Iron Bar" && FirstRoomIronBarWindow == false || Command == "Iron Bars" && FirstRoomIronBarWindow == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You've already taken one of the iron bars. Besides you couldn't even take another one.");
                        }
                        else if (Command == "Iron Bar" && FirstRoomIronBarWindow == true || Command == "Iron Bars" && FirstRoomIronBarWindow == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You take a look at the iron bars and you notice that one of the bars is loose.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (Command == "Get Iron Bar" || Command == "Pick Up Iron Bar" || Command == "Take Iron Bar" || Command == "Pull Iron Bar")
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You successfully pulled the iron bar from the window and put it in your backpack.");
                                Console.WriteLine("");
                                backPack.Add("Iron Bar");
                                FirstRoomIronBarWindow = false;

                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You move away from the window.");
                                Console.WriteLine("");
                            }

                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You move away from the window.");
                            Console.WriteLine("");
                        }
                    }
                    else if (Command == "Table" || Command == "Go To Table")
                    {
                        if (FirstRoomItems.Contains("Rusty Key") && FirstItemIsFound == false)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You look through the debris and the only thing worth noticing is a Rusty Key.");
                            Console.WriteLine("Maybe this can be useful. Do you want to pick it up?");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            Console.WriteLine("");
                            if (Command == "Yes")
                            {

                                backPack.Add("Rusty Key");
                                FirstRoomItems.Remove("Rusty Key");

                                Console.WriteLine("You put the rusty key in your backpack.");
                                Console.WriteLine("");
                                FirstItemIsFound = true;
                            }
                            else if (Command == "No")
                            {
                                Console.WriteLine("You leave the rusty key on the table.");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("Could not interpret action");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You go to the table and check but there is nothing here.");
                        }
                    }
                    else if (Command == "Go East" || Command == "East" || Command == "Door" || Command == "Inspect Door")
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
                            Console.WriteLine("You approach the wooden door. The door is locked but the lock seems old.");
                            Console.WriteLine("");
                            Command = FirstUpperCase(Console.ReadLine().ToLower());
                            Console.WriteLine("");
                            if (Command == "Use Rusty Key" || Command == "Rusty Key")
                            {
                                if (backPack.Contains("Rusty Key"))
                                {
                                    Console.WriteLine("You unlocked the door");
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
                                    Console.WriteLine("You smash the door open with your unbridled power.");
                                    Console.WriteLine("");
                                    FirstDoorOpen = true;
                                    FirstRoom = false;
                                    SecondRoom = true;
                                }
                                else
                                {
                                    Console.WriteLine("The door is old but is sturdy enough to withstand the force of your impact.");
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



                    else if (Command == "Go West" || Command == "West" || Command == "Go South" || Command == "South" || Command == "Go North" || Command == "North")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You cannot go this way. The only way out seems to be to the east");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Does not understand input. Try again.");
                        Console.WriteLine("");
                    }
                }
                while (SecondRoom == true)    //////////////////////////////////////Rum 2 //////////////////////////////////////////////////
                {
                    Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2 - 5);
                    Console.WriteLine("THE HALLWAY");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
                    Console.WriteLine("The Second Room");  //ska ta bort sen
                    Console.ReadLine();

                    Console.Clear();
                    Console.SetCursorPosition(0, 30);
                    Console.WriteLine("You have entered a hallway. By the south wall you see an ancient Vase on a piedestal.");
                    if (Hero.Char_Intelligence == 10)
                    {
                        Console.WriteLine("\nWith your great perception you see that the Vase has some kind of lever. \nBetter be careful...\n");
                    }
                    Console.WriteLine("By the East wall stands a statue of a knight in battle.\nHis sword is raised, but he seems to be missing something...");
                    Console.WriteLine("To the North you see an open door.");
                    Console.WriteLine("To the West you see the room you woke up in.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    while (true)
                    {
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Command == "Vase" || Command == "Ancient Vase" || Command == "Take Vase" || Command == "Use Vase" || Command == "Use Ancient Vase")
                        {
                            if (vaseBroken == false)
                            {
                                Random arrowRnd = new Random();
                                int arrowDamage = arrowRnd.Next(20, 50);
                                Console.WriteLine("\nThe Vase is a trap! ");
                                Console.WriteLine($"Arrows shoot out from the south and you loose {arrowDamage} HP!");
                                Hero.Hp -= arrowDamage;
                                Console.WriteLine("Your Current HP is " + Hero.Hp + ".\nThe Vase broke in to Shards\n");
                                SecondRoomItems.Add("Vase Shards");
                                vaseBroken = true;
                            }
                            else
                            {
                                Console.WriteLine("The Vase is broken...");
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
                            Console.WriteLine("Tip: Sometimes you can take items from the room you are in, so try write them and see what happens.");
                            Console.WriteLine("");
                        }
                        else if (Command == "Look")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You are in a hallway, and there is a piedestal by the South wall.");
                            if (vaseBroken == false)
                            {
                                Console.WriteLine("On the piedestal stands an ancient Vase.");
                            }
                            else if (!SecondRoomItems.Contains("Vase Shards")) { }
                            else { Console.WriteLine("There are Shards on the floor from the Vase"); }
                            Console.WriteLine("By the East wall stands a statue of a knight in battle.\nHis sword is raised, but he seems to be missing something...\n");
                            Console.WriteLine("To the North you see an open door.");
                            Console.WriteLine("To the West you see the room you woke up in.");


                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                        else if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                        {
                            Console.WriteLine("");
                            if (backPack.Count == 0)
                            {
                                Console.WriteLine("You have no items in your backpack.");
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
                        else if (Command == "Vase Shards" || Command == " Take Vase Shards" || Command == "Use Vase Shards" || Command == "Get Vase Shards")
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
                                    Console.WriteLine("Does not recognize action. Please try again");
                                    Console.WriteLine("");
                                }

                            }
                            else if (backPack.Contains("Vase Shards"))
                            {
                                Console.WriteLine("You can't use Vase Shards here");
                            }

                            else
                            {
                                Console.WriteLine("Does not recognize action. Please try again");
                                Console.WriteLine("");
                            }
                        }
                    }
                }
            } while (EndGame == false);


            //Console.WriteLine("Exists in Room 1: ");
            //foreach (var item in FirstRoomItems)
            //{

            //    Console.Write(item + Environment.NewLine);
            //}
            //Console.WriteLine("");

        }


        public static void GetHelpCommads()
        {
            Console.WriteLine("");
            Console.WriteLine("Here is a few commands that you can write in this game.");
            Console.WriteLine("Go North/Go South/Go East/Go West - To move through the game.");
            Console.WriteLine("Backpack - To show current items in your backpack.");
            Console.WriteLine("Look - To scan the room");
            Console.WriteLine("Tip: Sometimes you can take items from the room you are in, so try write them and see what happens.");
            Console.WriteLine("You can always get this help messages by typing \"Help\"");
            Console.WriteLine("");

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
            Console.WriteLine("Please select a vocation: Barbarian, Knight, Thief, Warlock");
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