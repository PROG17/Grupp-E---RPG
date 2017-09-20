﻿using System;
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
            bool FirstDoorOpen = false;
            bool FirstItemIsFound = false;
            string Char_Name = "David";
            string Char_Voc = "Cool";
            string Command = "";
            int Char_Max_HP = 0;
            int Char_Current_HP = 0;
            int Char_Strength = 0;
            int Char_Agility = 0;
            int Char_Intelligence = 0;
            List<string> Char_Backpack = new List<string>();
            Char_Backpack.Add("Rusty Key");
            Char_Backpack.Add("Bread");
            List<string> FirstRoomItems = new List<string>();
            FirstRoomItems.Add("Spike");

            Char_Name = FirstUpperCase(WelcomeName(Char_Name));
            Char_Voc = FirstUpperCase(WelcomeVoc(Char_Voc));

            Character GetClassHP = new Character();
            Char_Max_HP = GetClassHP.GetHP(Char_Max_HP, Char_Voc);
            Char_Current_HP = Char_Max_HP;
            Character Stats = new Character();
            Stats.GetStats(Char_Voc, out Char_Strength, out Char_Agility, out Char_Intelligence);
            Character AddItem = new Character();


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
            while (FirstRoom == true)
            {
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
                if (Command == "Inventory" || Command == "Backpack" || Command == "Inv")
                {
                    Console.WriteLine("");
                    if (Char_Backpack.Count == 0)
                    {
                        Console.WriteLine("You have no items in your backpack.");
                        Console.Write("");
                    }
                    else
                    {
                        for (int i = 0; i < Char_Backpack.Count; i++)
                        {
                            Console.WriteLine(i + 1 + ": " + Char_Backpack[i]);
                        }
                        Console.WriteLine("Press <Enter> to go back");
                    }
                    Console.WriteLine("");
                    Command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (Command == "Drop" || Command == "Remove")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Which item do you want to drop?");
                        Console.WriteLine("");
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (Char_Backpack.Contains(Command))
                        {
                            Char_Backpack.Remove(Command);
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
                else if (Command == "Table" || Command == "Go To Table")
                {
                    if (FirstRoomItems.Contains("Spike") && FirstItemIsFound == false)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You see a 3 inch Spike under the table. Do you want to pick it up?");
                        Console.WriteLine("");
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        Console.WriteLine("");
                        if (Command == "Yes")
                        {

                            Char_Backpack.Add("Spike");
                            FirstRoomItems.Remove("Spike");

                            Console.WriteLine("You put the Spike in your backpack.");
                            Console.WriteLine("");
                            FirstItemIsFound = true;
                        }
                        else if (Command == "No")
                        {
                            Console.WriteLine("You leave the Spike under the table.");
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
                else if (Command == "Go East" || Command == "East" || Command == "Door")
                {
                    while (FirstDoorOpen == false)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You approach the wooden door. The door is locked but the lock seems old.");
                        Console.WriteLine("");
                        Command = FirstUpperCase(Console.ReadLine().ToLower());
                        Console.WriteLine("");
                        if (Command == "Use Rusty Key" || Command == "Rusty Key")
                        {
                            if (Char_Backpack.Contains("Rusty Key"))
                            {
                                Console.WriteLine("You unlocked the door");
                                Console.WriteLine("");
                                FirstDoorOpen = true;
                                FirstRoom = false;
                                Char_Backpack.Remove("Rusty Key");
                            }
                        }
                        else if (Command == "Push" || Command == "Break")
                        {
                            if (Char_Strength >= 10)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You smash the door open with your unbridled power.");
                                Console.WriteLine("");
                                FirstDoorOpen = true;
                                FirstRoom = false;
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
                        break;
                    }
                    //HÄR SKA NÄSTA RUM BÖRJA

                }

                Console.WriteLine("");
                Console.WriteLine("Välkommen till nästa rum!");
                Console.ReadLine();



                //Console.WriteLine("Exists in Room 1: ");
                //foreach (var item in FirstRoomItems)
                //{

                //    Console.Write(item + Environment.NewLine);
                //}
                //Console.WriteLine("");

            }

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
        public static string WelcomeVoc(string vocation)//Detta körs vid starten och sparar ditt voc (ifall du skriver fel blir det WL
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 5);
            Console.WriteLine("Welcome to the Age of Labyrinths.");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Please select a vocation:");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 1);
            Console.WriteLine("Barbarian, Knight, Thief, Warlock");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 1);
            vocation = Console.ReadLine().ToLower();

            if (vocation == "barbarian" || vocation == "knight" || vocation == "thief" || vocation == "warlock")
            {

            }
            else
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 3);
                Console.Write("Non-existant vocation.");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 4);
                Console.Write("To punish you, you will be playing as a Warlock.");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 5);
                Console.Write("Press Enter to advance.");
                vocation = "warlock";
                Console.ReadLine();
            }
            return vocation;
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