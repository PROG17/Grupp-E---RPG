﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Rooms
    {
        private string command;
        private int roomNumber;

        private bool CheckChestOpen = false;
        bool CauldronIsFull = true;
        string charVoc;
        List<string> roomItems = new List<string>();

        // Bools för olika event i alla rum

        #region First Room Bool

        public bool castleSeen { get; set; }


        private bool ironBar = true;
        private bool KeyFound = false;
        private bool doorOpenWithKey = false;
        private bool doorOpenWithForce = false;

        public bool doorOpend { get; set; }
        #endregion

        #region Second Room Bool

        bool ShieldOnStatue = false;
        public static bool vaseBroken = false;
        public static bool HiddenDoorOpen = false;



        #endregion

        #region Third room Bool

        bool AlchemyTable = true;
        bool UsingAlchTable = true;

        #endregion



        #region Forth Room Bools

        private bool paintingOnFloor = false;
        private bool LionKeyTaken = false;
        private bool LookedInMirror = false;
        private bool shieldIsMissing = false;


        #endregion


        // När man skapar ett nytt rum får det ett rumsnummer 
        public Rooms(int RoomNumber)
        {
            this.roomNumber = RoomNumber;
        }

        // Lägger till items i rätts rums itemlista
        public void AddRoomItem(string item)
        {
            if (!roomItems.Contains(item))
            {
                roomItems.Add(item);

            }

        }

        // Plockar bort items ur respektives lista
        public void RemoveRoomItem(string item)
        {
            roomItems.Remove(item);

        }

        // Skriver ut alla items i rummet
        public void TypeRoomList()
        {

            foreach (var item in roomItems)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item);
            }
        }


        // Info om varje rum
        // Om man tidigare har släppt items i rummet kan en lista returneras med de item man vill ta tillbaks
        public List<string> RoomInfo()
        {

            if (roomNumber == 1)
            {

                Console.WriteLine("\nThe room you are in has a wooden Door and one Window that seems to be blocked by Iron Bars.");
                Console.WriteLine("You also see a beautifully ornated Chest.");
                Console.WriteLine("To the East you see a Door that's shut. Besides it you see a Table with some debris on it.\n");

                List<string> returnItems = ItemsOnFloor();
                return returnItems;

            }

            if (roomNumber == 2)
            {

                Console.WriteLine("\nYou are in the hallway, and there is a piedestal by the South wall.");
                if (vaseBroken == false)
                {
                    Console.WriteLine("On the piedestal stands an ancient Vase.");
                    if (charVoc == "Warlock")
                    {
                        Console.WriteLine("Something feels strange about the Vase");
                    }
                    if (ShieldOnStatue == false)
                    {
                        Console.WriteLine(
                        "By the East wall stands a Statue of a knight in battle.\nHe holds a sword in his right hand.\n");
                    }
                    else
                    {
                        Console.WriteLine(
                     "By the East wall stands a Statue of a knight in battle.\nHe holds a Sword in his right hand.\n" +
                     "He now holds a Shield in his left hand.\n");
                    }
                }
                Console.WriteLine("To the North you see an open door.");
                Console.WriteLine("To the West you see the room you woke up in.\n\n\n");
                List<string> returnItems = ItemsOnFloor();
                return returnItems;



            }
            if (roomNumber == 3)
            {

                Console.WriteLine("");
                Console.WriteLine("As soon as you enter this room you are met with the most intoxicating smell that you'll dream of.");
                Console.WriteLine("The room is quite foggy so it takes a while to see that there's only a Table in the room," +
                    " and a door to the west.");
                Console.WriteLine("The smell seems to originate from the Table.\n");

                List<string> returnItems = ItemsOnFloor();
                return returnItems;

            }
            if (roomNumber == 4)
            {
                Console.WriteLine("This is a big room with lots of trophies on the walls! \nA big Carpet on the floor, Mirror on the wall and a big Painting of a castle");
                if (shieldIsMissing == false)
                {
                    Console.WriteLine("But the one thing that really draws to your attention is a big silver Shield.\n");
                }

                List<string> returnItems = ItemsOnFloor();
                return returnItems;
            }
            if (roomNumber == 5)
            {
                Console.WriteLine("You are inside a small room with a ladder going to the roof, near some barrels.");
                Console.WriteLine("The sunlight is glowing through the opening and you feel you are close to escaping.");


            }
            return null;
        }


        private List<string> ItemsOnFloor()
        {
            List<string> returnItems = new List<string>();

            if (roomItems.Count > 0)
            {
                Console.WriteLine("You see items on the ground!");
                foreach (var item in roomItems)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("Do you want to pick it up? Yes/No");
                    command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (command == "Yes" || command == "Take")
                    {
                        returnItems.Add(item);
                    }
                    else
                    {
                        Console.WriteLine("You left {0} on the floor", item);
                    }

                }

                foreach (var item in returnItems)
                {
                    RemoveRoomItem(item);
                }
                return returnItems;
            }
            return null;
        }

        // Alla händelser som sker i ett rum 
        public void RoomAction(Character hero, string command)
        {
            if (roomNumber == 1)
            {

                if (command == "Chest")
                {
                    if (CheckChestOpen == true)
                    {

                        Console.WriteLine("\nThe chest is opened wide. The chest is empty.\n");

                    }

                    else if (CheckChestOpen == false)
                    {

                        Console.WriteLine("\nThe Chest is beautifully ornated with purple lion emblems on the sides.");
                        Console.WriteLine("You examine it more closely but it seems that you can't open it without a key.");
                        Console.WriteLine("Try to open chest? Yes/No?\n");
                        command = FirstUpperCase(Console.ReadLine().ToLower());

                        if (command == "Yes" && (hero.CheckBackPack("Lion Key") || hero.CheckBackPack("Iron Bar")))
                        {
                            CheckChestOpen = true;
                            Console.WriteLine("");
                            if (hero.CheckBackPack("Lion Key"))
                            {
                                hero.UsedItem("Lion Key");
                                Console.WriteLine("\nYou open the Chest with the Lion Key!");
                            }
                            else
                            {
                                Console.WriteLine("You pry open the Chest with the Iron Bar!");
                            }
                            Console.WriteLine("There is a Vial in here. You placed it in your backpack!\n");
                            hero.AddInventory("Vial");

                        }
                        else if (command != "Yes")
                        {
                            Console.WriteLine("\nYou left the chest closed.\n");
                        }
                        else
                        {
                            Console.WriteLine("\nYou are missing a required item to open the chest.\n");
                        }

                    }
                }

                if (command == "Window")
                {
                    castleSeen = true;
                    Console.WriteLine("\nYou look past the Iron Bars through the Window and you see a giant white castle on a green hill.");
                    Console.WriteLine("The castle have four towers that seems to stretch towards the heaven.");
                    Console.WriteLine("You also see two mountains in the distance that makes the castle even more beautiful.");
                    Console.WriteLine("However you get the feeling that there's no one in the castle.\n");

                    Console.WriteLine("Do you want to open the window? Yes/No\n");
                    command = FirstUpperCase(Console.ReadLine().ToLower());

                    if (command == "Yes")
                    {

                        Console.WriteLine("\nThe Window is closed and can't be opened. Even if you could open it it's blocked by Iron Bars.");

                        if (ironBar == true)
                        {
                            Console.WriteLine("You also see that one of the iron bars is loose. Do you want to try and take it?\n");
                            command = FirstUpperCase(Console.ReadLine().ToLower());
                            
                            if (hero.Char_Strength > 7 && command == "Yes")
                            {
                                Console.WriteLine("\nWith your mighty strength it was no problem and the iron bar was added to your backpack.\n");
                                hero.AddInventory("Iron Bar");
                                ironBar = false;
                            }
                            else
                            {
                                Console.WriteLine("\nYou decide not to try and take the iron bar.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere's no other iron bar that you can take away.\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nYou move away from the window.\n");
                    }

                }

                if (command == "Table")
                {
                    if (KeyFound == false)
                    {

                        Console.WriteLine("\nYou look through the debris and the only thing worth noticing is a Rusty Key.");
                        Console.WriteLine("Maybe this can be useful.");
                        Console.WriteLine("Do you want to pick it up? Yes/No\n");
                        command = FirstUpperCase(Console.ReadLine().ToLower());

                        if (command == "Yes" || command == "Take")
                        {

                            KeyFound = true;
                            hero.AddInventory("Rusty Key");
                        }
                        else
                        {
                            Console.WriteLine("\nYou left the table with the Rusty Key still on it.\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nAll you see is the old table with some debris on it. Nothing more interesting can be found here.\n");
                    }
                }
                if (command == "Inspect")
                {
                    Console.WriteLine("What do you want to inspect?");
                    command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (command == "Bread" && hero.CheckBackPack("Bread"))
                    {
                        Console.WriteLine("\nIt seems to be white barley bread. It's still quite fresh and should be eaten when feeling down.");
                        Console.WriteLine("Item effect: +20 hitpoints\n");
                    }
                    else if (command == "Green Vial" && hero.CheckBackPack("Green Vial"))
                    {
                        Console.WriteLine("\nThis green looking liquid that you got from the alchemy table looks like it came from a swamp.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");
                    }
                    else if (command == "White Vial" && hero.CheckBackPack("White Vial"))
                    {
                        Console.WriteLine("\nThe scent coming from the white liquid seems to penetrate the glass vial. The liquid is silky white.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");

                    }
                    else if (command == "Vial" && hero.CheckBackPack("Vial"))
                    {
                        Console.WriteLine("\nYou got this item from a chest where you started. You can maybe use this if you want to drink something.\n");
                    }
                    else if (command == "Iron Bar" && hero.CheckBackPack("Iron Bar"))
                    {
                        Console.WriteLine("\nAn iron bar that you took from the first room. Maybe you can use this to open something by force.\n");
                    }
                    else if (command == "Rusty Key" && hero.CheckBackPack("Rusty Key"))
                    {
                        Console.WriteLine("\nThis key is covered in rust. Though you suspect that it still will work, if you can find the lock that match the key that is.\n");
                    }
                    else if (command == "Lion Key" && hero.CheckBackPack("Lion Key"))
                    {
                        Console.WriteLine("\nYou have not seen a more extravagant key in your life before. The base of this key is a lions head.\n");
                    }
                    else if (command == "Shield" && hero.CheckBackPack("Shield"))
                    {
                        Console.WriteLine("\nThis is a silver shield that looks like it was forged yesterday.");
                        Console.WriteLine("Upon further inspection you realise that this shield should not be used in combat. and is only for decoration.\n");
                    }
                }
                if (command == "Door")
                {
                    charVoc = hero.Char_Vocation;           // Sätter Vocation lokalt. Utnyttjar att hero läses in i denna metod.
                    Console.WriteLine("\nYou approach the wooden door.");

                    if (doorOpend == false)
                    {
                        Console.WriteLine("The door is locked but the lock seems old.");
                        Console.WriteLine("Try opening the door? Yes/No\n");
                        command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (command == "Yes")
                        {
                            if (hero.CheckBackPack("Rusty Key"))
                            {
                                hero.UsedItem("Rusty Key");
                                Console.WriteLine("\nYou opened the door with the Rusty Key.\n");
                                doorOpend = true;
                                doorOpenWithKey = true;
                            }
                            else if (!hero.CheckBackPack("Rusty Key"))
                            {

                                Console.WriteLine("\nYou tried to open the door but you did not have the right key. Do you want to try and push it open? Yes/No\n");
                                command = FirstUpperCase(Console.ReadLine().ToLower());
                                if (command == "Yes")
                                {
                                    if (hero.Char_Strength > 11)
                                    {
                                        Console.WriteLine("\nYou smash the Door open with your unbridled power.\n");
                                        doorOpend = true;
                                        doorOpenWithForce = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThe Door is old but is sturdy enough to withstand the force of your impact.\n");
                                    }
                                }
                            }

                        }


                        else
                        {
                            Console.WriteLine("You left the door closed...\n");
                        }

                    }
                    else
                    {
                        if (doorOpenWithKey == true)
                        {
                            Console.WriteLine("\nThe door is already open.\n");
                        }
                        else if (doorOpenWithForce == true)
                        {
                            Console.WriteLine("\nThe door is smashed to pieces.\n");
                        }
                    }
                }


            }
            if (roomNumber == 2)
            {
                if (command == "Vase" || command == "Ancient Vase" || command == "Take Vase" ||
                            command == "Use Vase" || command == "Use Ancient Vase")
                {
                    if (vaseBroken == false)
                    {
                        Console.WriteLine("It is a beautiful ancient vase but it is really dusty...\nDo you want to pick it up? Yes/No");
                        command = FirstUpperCase(Console.ReadLine());
                        if (command == "Yes" || command == "Take")
                        {
                            Random arrowRnd = new Random();
                            int arrowDamage = arrowRnd.Next(20, 50);
                            Console.WriteLine("\nThe Vase is a trap! \n");
                            Console.WriteLine(
                                $"Arrows shoot out from the south wall and you loose {arrowDamage} HP!");
                            hero.Hp -= arrowDamage;
                            Console.WriteLine("Your Current HP is " + hero.Hp +
                                              ".\nThe Vase broke in to Vase Shards\n");

                            vaseBroken = true;
                            AddRoomItem("Vase Shards");
                        }
                        else
                        {
                            Console.WriteLine("You left the vase untouched");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The Vase is broken...");
                    }
                }
                else if (command == "Inspect")
                {
                    Console.WriteLine("What do you want to inspect?");
                    command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (command == "Bread" && hero.CheckBackPack("Bread"))
                    {
                        Console.WriteLine("\nIt seems to be white barley bread. It's still quite fresh and should be eaten when feeling down.");
                        Console.WriteLine("Item effect: +20 hitpoints\n");
                    }
                    else if (command == "Green Vial" && hero.CheckBackPack("Green Vial"))
                    {
                        Console.WriteLine("\nThis green looking liquid that you got from the alchemy table looks like it came from a swamp.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");
                    }
                    else if (command == "White Vial" && hero.CheckBackPack("White Vial"))
                    {
                        Console.WriteLine("\nThe scent coming from the white liquid seems to penetrate the glass vial. The liquid is silky white.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");

                    }
                    else if (command == "Vial" && hero.CheckBackPack("Vial"))
                    {
                        Console.WriteLine("\nYou got this item from a chest where you started. You can maybe use this if you want to drink something.\n");
                    }
                    else if (command == "Iron Bar" && hero.CheckBackPack("Iron Bar"))
                    {
                        Console.WriteLine("\nAn iron bar that you took from the first room. Maybe you can use this to open something by force.\n");
                    }
                    else if (command == "Rusty Key" && hero.CheckBackPack("Rusty Key"))
                    {
                        Console.WriteLine("\nThis key is covered in rust. Though you suspect that it still will work, if you can find the lock that match the key that is.\n");
                    }
                    else if (command == "Lion Key" && hero.CheckBackPack("Lion Key"))
                    {
                        Console.WriteLine("\nYou have not seen a more extravagant key in your life before. The base of this key is a lions head.\n");
                    }
                    else if (command == "Shield" && hero.CheckBackPack("Shield"))
                    {
                        Console.WriteLine("\nThis is a silver shield that looks like it was forged yesterday.");
                        Console.WriteLine("Upon further inspection you realise that this shield should not be used in combat. and is only for decoration.\n");
                    }
                }
                else if (command == "Statue" || command == "East" || command == "Go East")
                {
                    if (ShieldOnStatue == false)
                    {
                        Console.WriteLine("\nYou walk up to the Statue.\nThe knight has a sword and armor, but no Shield... ");
                        Console.WriteLine("There is a Plate with an inscription at the foot of the Statue.");
                       
                        command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (command == "Plate" || command == "Read")
                        {
                            Console.Clear();
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 11);
                            Console.WriteLine("+-------------------------------------------------------------------+");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 10);
                            Console.WriteLine("| = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = |");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 9);
                            Console.WriteLine("|{>/-------------------------------------------------------------/<}|");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 8);
                            Console.WriteLine("|: |                                                             | :|");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 7);
                            Console.WriteLine("| :|                      MIHI OPUS EST CLYPEUS                  |: |");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 6);
                            if (hero.Char_Vocation == "Knight")
                            {
                                Console.WriteLine("|: |                        I NEED MY SHIELD                     | :|");

                            }
                            else
                            {
                                Console.WriteLine("|: |                                                             | :|");
                            }
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 5);
                            Console.WriteLine("| :|                                                             |: |");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 4);
                            Console.WriteLine("|{>/-------------------------------------------------------------/<}|");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 3);
                            Console.WriteLine("| = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = |");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                                Console.WindowHeight / 2 - 2);
                            Console.WriteLine("+-------------------------------------------------------------------+");
                                                        
                            Console.ReadKey();
                            Console.Clear();
                            Console.SetCursorPosition(0, 30);
                        }

                        else { Console.WriteLine("\nYou walk back to the center of the room."); }

                            if (hero.CheckBackPack("Shield"))
                        {
                            Console.WriteLine("\nDo you want to put the Shield on the statue? Yes/No\n");
                            command = FirstUpperCase(Console.ReadLine().ToLower());
                            if (command == "Yes")
                            {
                                hero.UsedItem("Shield");
                                RemoveRoomItem("Shield");
                                ShieldOnStatue = true;
                                HiddenDoorOpen = true;
                                Console.WriteLine("\nYou put the Shield on its right place!\nThe walls starts to shake, and you hear a loud noise from the room to the North\n");
                            }
                            else if (command == "No")
                            {
                                Console.WriteLine("\nThe Shield remains in your Backpack\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You should look around for that missing Shield...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The statue stands tall with it's sword and shield!");
                    }


                }

                #region Gamla Statue command

                //else if (command == "Statue" || command == "East" || command == "Go East")
                //{
                //    Console.WriteLine("\nYou walk up to the Statue.\nThe knight has a sword and armor, but no Shield... ");
                //    Console.WriteLine("There is a Plate with an inscription at the foot of the Statue.");


                //    string Command = FirstUpperCase(Console.ReadLine().ToLower());
                //    if (Command == "Plate" || Command == "Read Plate" || Command == "Inscription" ||
                //        Command == "Read")
                //    {
                //        Console.Clear();
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 11);
                //        Console.WriteLine(
                //            "+-------------------------------------------------------------------+");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 10);
                //        Console.WriteLine(
                //            "| = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = |");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 9);
                //        Console.WriteLine(
                //            "|{>/-------------------------------------------------------------/<}|");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 8);
                //        Console.WriteLine(
                //            "|: |                                                             | :|");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 7);
                //        Console.WriteLine(
                //            "| :|                      MIHI OPUS EST CLYPEUS                  |: |");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 6);
                //        if (hero.Char_Vocation == "Knight")
                //        {
                //            Console.WriteLine(
                //           "|: |                        I NEED MY SHIELD                     | :|");

                //        }
                //        else
                //        {
                //            Console.WriteLine(
                //                "|: |                                                             | :|");
                //        }
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 5);
                //        Console.WriteLine(
                //            "| :|                                                             |: |");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 4);
                //        Console.WriteLine(
                //            "|{>/-------------------------------------------------------------/<}|");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 3);
                //        Console.WriteLine(
                //            "| = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = : = |");
                //        Console.SetCursorPosition(Console.WindowWidth / 2 - 35,
                //            Console.WindowHeight / 2 - 2);
                //        Console.WriteLine(
                //            "+-------------------------------------------------------------------+");

                //        Console.ReadLine();
                //        Console.Clear();
                //        Console.SetCursorPosition(0, 30);
                //        Console.WriteLine("You walk back to the center of the room.");
                //    }
                //    else if (Command == "No")
                //    {
                //        Console.WriteLine("You walk back to the center of the room.");
                //    }
                //    else
                //    {
                //        Console.WriteLine("\n?\n");
                //        Console.WriteLine("You walk back to the center of the room.");
                //    }
                //}

                #endregion

                #region Gamla shield command

                //else if (command == "Shield" || command == "Use Shield")
                //{
                //    if (!hero.CheckBackPack("Shield") && ShieldOnStatue == false) // Om skölden inte är i ryggan eller på statyn.
                //    {
                //        Console.WriteLine("\nThe Statue seems to be missing its Shield...\n");
                //    }
                //    else if (ShieldOnStatue == true)    // Om skölden är uppe på statyn
                //    {
                //        Console.WriteLine("\nThe Shield is now in its right place!\n");
                //    }
                //    else if (hero.CheckBackPack("Shield"))
                //    {
                //        Console.WriteLine("\nDo you want to put the Shield on the statue?\n");
                //        command = FirstUpperCase(Console.ReadLine().ToLower());
                //        if (command == "Yes")
                //        {
                //            hero.UsedItem("Shield");
                //            RemoveRoomItem("Shield");
                //            ShieldOnStatue = true;
                //            HiddenDoorOpen = true;
                //            Console.WriteLine("\nYou put the Shield on its right place!\nThe walls starts to shake, and you hear a loud noise from the room to the North\n");
                //        }
                //        else if (command == "No") { Console.WriteLine("\nThe Shield remains in your Backpack\n"); }
                //        else { Console.WriteLine("Does not recognise action. Please try again"); }
                //    }
                // }



                #endregion


                else if (command == "Vase Shards" || command == " Take Vase Shards")
                {
                    if (roomItems.Contains("Vase Shards"))
                    {
                        Console.WriteLine("\nDo you want to take the Vase Shards from the ground?");
                        command = FirstUpperCase(Console.ReadLine().ToLower());
                        if (command == "Yes")
                        {
                            hero.AddInventory("Vase Shards");
                            roomItems.Remove("Vase Shards");
                            Console.WriteLine("You pick up the Vase Shards.\n");
                        }
                        else if (command == "No")
                        {
                            Console.WriteLine("\nYou left the Vase Shards on the floor.\n");
                        }

                        else
                        {
                            Console.WriteLine("Does not recognise action. Please try again\n");
                        }
                    }
                }
            }

            if (roomNumber == 3)
            {
                if (command == "Inspect")
                {
                    Console.WriteLine("What do you want to inspect?");
                    command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (command == "Bread" && hero.CheckBackPack("Bread"))
                    {
                        Console.WriteLine("\nIt seems to be white barley bread. It's still quite fresh and should be eaten when feeling down.");
                        Console.WriteLine("Item effect: +20 hitpoints\n");
                    }
                    else if (command == "Green Vial" && hero.CheckBackPack("Green Vial"))
                    {
                        Console.WriteLine("\nThis green looking liquid that you got from the alchemy table looks like it came from a swamp.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");
                    }
                    else if (command == "White Vial" && hero.CheckBackPack("White Vial"))
                    {
                        Console.WriteLine("\nThe scent coming from the white liquid seems to penetrate the glass vial. The liquid is silky white.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");

                    }
                    else if (command == "Vial" && hero.CheckBackPack("Vial"))
                    {
                        Console.WriteLine("\nYou got this item from a chest where you started. You can maybe use this if you want to drink something.\n");
                    }
                    else if (command == "Iron Bar" && hero.CheckBackPack("Iron Bar"))
                    {
                        Console.WriteLine("\nAn iron bar that you took from the first room. Maybe you can use this to open something by force.\n");
                    }
                    else if (command == "Rusty Key" && hero.CheckBackPack("Rusty Key"))
                    {
                        Console.WriteLine("\nThis key is covered in rust. Though you suspect that it still will work, if you can find the lock that match the key that is.\n");
                    }
                    else if (command == "Lion Key" && hero.CheckBackPack("Lion Key"))
                    {
                        Console.WriteLine("\nYou have not seen a more extravagant key in your life before. The base of this key is a lions head.\n");
                    }
                    else if (command == "Shield" && hero.CheckBackPack("Shield"))
                    {
                        Console.WriteLine("\nThis is a silver shield that looks like it was forged yesterday.");
                        Console.WriteLine("Upon further inspection you realise that this shield should not be used in combat. and is only for decoration.\n");
                    }
                }
                else if (command == "Table")
                {

                    if (CauldronIsFull == true)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You approach the Table and it seems to be a Table of an alchemist.");
                        Console.WriteLine("The smell that's filling this room seems to come from the two Cauldron.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("You approach the alchemist table and the smell from the cauldrons is still in the air");
                        Console.WriteLine("But both of the cauldrons are empty.");
                        Console.WriteLine("");

                        if (hero.CheckBackPack("Green Vial") || hero.CheckBackPack("White Vial"))
                        {
                            Console.WriteLine("Maybe you should try to use the vial in your backpack.");
                        }
                        else
                        {

                        }
                    }


                    if (CauldronIsFull == true)
                    {

                        Console.WriteLine("");
                        Console.WriteLine("The right cauldron is filled with White liquid. It also releases a scent that's almost irresistable.");
                        Console.WriteLine("The left cauldron is Green and almost looks ominous. It doesn't smell like anything.");
                        if (hero.Char_Intelligence >= 10)
                        {
                            Console.WriteLine("Due to your high intelligence you figure out that the White cauldron might be really dangerous to consume...");
                        }

                        if (hero.CheckBackPack("Vial"))
                        {
                            Console.WriteLine();
                            Console.WriteLine("You seem to have a Vial in your backpack that could be filled with one of the two poisons...");
                            Console.WriteLine("Witch one do you want to fill your vial with? The Wite ore Green one?");
                            Console.WriteLine("");
                            command = FirstUpperCase(Console.ReadLine().ToLower());

                            if (command == "White" || command == "Green")
                            {
                                Console.WriteLine("");
                                Console.WriteLine($"You fill the vial with the {command} liquid. As you are done, all the liquid in the cauldrons vanish.");
                                Console.WriteLine("");
                                hero.UsedItem("Vial");
                                hero.AddInventory($"{command} Vial");
                                CauldronIsFull = false;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("You walk away from the cauldrons.");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You should find something that can store the potions and come back...");
                        }


                    }

                }

                #region Rum3 

                //if (command == "Table")
                //{

                //    bool AlchemyTable = true;
                //    if (CauldronIsFull == true)
                //    {
                //        Console.WriteLine("");
                //        Console.WriteLine("You approach the Table and it seems to be a Table of an alchemist.");
                //        Console.WriteLine("The smell that's filling this room seems to come from a Cauldron.");
                //        Console.WriteLine("There are two Cauldrons on the alchemy table.");
                //        Console.WriteLine("The cauldron to the right seems to release the scent into the room," +
                //            " whilst the other is scentless.");
                //        Console.WriteLine("");
                //    }
                //    else
                //    {
                //        Console.WriteLine("");
                //        Console.WriteLine("You approach the table and it seems to be a table of an alchemist.");
                //        Console.WriteLine("The smell that's filling this room seems to come from a Cauldron.");
                //        Console.WriteLine("There are two Cauldrons on the alchemy table.");
                //        Console.WriteLine("Both of the cauldrons are empty.");
                //        Console.WriteLine("");
                //    }

                //    while (AlchemyTable == true)
                //    {

                //        command = FirstUpperCase(Console.ReadLine().ToLower());
                //        if (command == "Drink" || command == "Take A Sip" || command == "Cauldron")
                //        {
                //            if (CauldronIsFull == true)
                //            {
                //                Console.WriteLine("");
                //                Console.WriteLine("You must use a container to drink from.");
                //                Console.WriteLine("");
                //            }
                //            else
                //            {
                //                Console.WriteLine("");
                //                Console.WriteLine("There is not any liquid left in the cauldrons.");
                //                Console.WriteLine("");
                //            }


                //        }
                //        else if (command == "Use Vial" || command == "Vial" || command == "Fill Vial" || command == "Fill" && hero.CheckBackPack("Vial") && CauldronIsFull == true)
                //        {
                //            bool UsingAlchTable = true;

                //            while (UsingAlchTable == true)
                //            {
                //                Console.WriteLine("");
                //                Console.WriteLine("The right cauldron is filled with white liquid." +
                //                    " It also releases a scent that's almost irresistable.");
                //                Console.WriteLine("The left cauldron is green and almost looks ominous. " +
                //                    "It doesn't smell like anything.");
                //                if (hero.Char_Intelligence >= 10)
                //                {
                //                    Console.WriteLine("Due to your high intelligence you figure out that the right cauldron might be " +
                //                        "really dangerous to consume...");
                //                }
                //                Console.WriteLine("Which one do you want to use the vial on?");
                //                Console.WriteLine("");
                //                command = FirstUpperCase(Console.ReadLine().ToLower());

                //                if (command == "Right" || command == "White")
                //                {
                //                    Console.WriteLine("");
                //                    Console.WriteLine("You fill the vial with the white liquid. " +
                //                        "As you are done, all the liquid in the cauldrons vanish.");
                //                    Console.WriteLine("");
                //                    hero.UsedItem("Vial");
                //                    hero.AddInventory("Vial filled with white liquid");
                //                    CauldronIsFull = false;
                //                    AlchemyTable = false;
                //                    UsingAlchTable = false;
                //                }
                //                else if (command == "Left" || command == "Green")
                //                {
                //                    Console.WriteLine("");
                //                    Console.WriteLine("You fill the vial with the green liquid. " +
                //                        "As you are done, all the liquid in the cauldrons vanish.");
                //                    Console.WriteLine("");
                //                    hero.UsedItem("Vial");
                //                    hero.AddInventory("Vial filled with green liquid");
                //                    CauldronIsFull = false;
                //                    AlchemyTable = false;
                //                    UsingAlchTable = false;
                //                }
                //                else if (command == "Back")
                //                {
                //                    Console.WriteLine("");
                //                    Console.WriteLine("You move away from the alchemy table.");
                //                    Console.WriteLine("");
                //                    UsingAlchTable = false;
                //                }

                //                else
                //                {
                //                    Console.WriteLine("");
                //                    Console.WriteLine("Does not understand input. Try again.");
                //                    Console.WriteLine("");
                //                }
                //            }

                //        }
                //        else if (command == "Use Vial" && hero.CheckBackPack("Vial")
                //            || command == "Vial" && hero.CheckBackPack("Vial")
                //            || command == "Fill Vial" && hero.CheckBackPack("Vial")
                //            || command == "Fill" && hero.CheckBackPack("Vial"))
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("There is no liquid left in the cauldrons to fill the container with.");
                //            Console.WriteLine("");
                //        }
                //        else if (command == "Use Vial" && !hero.CheckBackPack("Vial") && CauldronIsFull == true
                //            || command == "Vial" && !hero.CheckBackPack("Vial") && CauldronIsFull == true
                //            || command == "Fill Vial" && !hero.CheckBackPack("Vial") && CauldronIsFull == true
                //            || command == "Fill" && !hero.CheckBackPack("Vial") && CauldronIsFull == true)
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("You don't have a container to fill.");
                //            Console.WriteLine("");
                //        }
                //        else if (command == "Use Vial" && !hero.CheckBackPack("Vial")
                //            || command == "Vial" && !hero.CheckBackPack("Vial")
                //            || command == "Fill Vial" && !hero.CheckBackPack("Vial")
                //            || command == "Fill" && !hero.CheckBackPack("Vial"))
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("You don't have a container to fill. But even so, there isn't even any liquid left here.");
                //            Console.WriteLine("");
                //        }
                //        else if (command == "Right" && CauldronIsFull == true)
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("The right cauldron is filled with white liquid. It also releases a scent that's almost irresistable.");
                //            Console.WriteLine("");

                //        }
                //        else if (command == "Right")
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("The cauldron is empty.");
                //            Console.WriteLine("");
                //        }
                //        else if (command == "Left" && CauldronIsFull == true)
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("The left cauldron is green and almost looks ominous. It doesn't smell like anything.");
                //            Console.WriteLine("");
                //        }
                //        else if (command == "Left")
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("The cauldron is empty.");
                //            Console.WriteLine("");
                //        }
                //        else if (command == "Back")
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("You move away from the alchemy table.");
                //            Console.WriteLine("");
                //            AlchemyTable = false;
                //        }
                //        else
                //        {
                //            Console.WriteLine("");
                //            Console.WriteLine("Does not understand input. Try again.");
                //            Console.WriteLine("");
                //        }


                //    }
                //}
                //else
                //{

                //}

                #endregion
            }
            if (roomNumber == 4)
            {
                if (command == "Carpet")
                {
                    Console.WriteLine("You're standing on a carpet and looking up in the ceiling, there is a huge chandelier and you are hoping it won't fall down on you.");
                }

                if (command == "Painting")
                {
                    // Itro text ligger i Program klassen
                    if (paintingOnFloor == false)
                    {
                        Console.WriteLine("And it looks like there is something behind it...");
                        Console.WriteLine("Take down the painting? Yes/No");
                        command = GetCommand();

                        if (command == "Yes" || command == "Take")
                        {
                            paintingOnFloor = true;
                            if (hero.Char_Agility < 8)
                            {
                                Console.WriteLine("OH CLUMSY YOU!");

                                hero.HpDamage(20, "dropping the painting on your head");

                            }
                            else
                            {

                                Console.WriteLine("You placed the painting on the floor");
                            }
                            Console.WriteLine(
                                "Behind it you see a hole in the wall. Guess the painting WAS hiding something");
                            Console.WriteLine("Do you dare place your hand in the hole? Yes/No");
                            command = GetCommand();
                            if (command == "Yes" || command == "Take")
                            {
                                Console.WriteLine("You reach in and manage to grab a Key!");
                                Console.WriteLine("The key is golden and have a Lions head on it.");
                                hero.AddInventory("Lion Key");
                                LionKeyTaken = true;
                            }
                            else
                            {
                                Console.WriteLine("You left the hole untouched. But you can always come back...");
                            }


                        }
                        else
                        {
                            Console.WriteLine("You left the paining on the wall");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The painting is laying on the floor and you can see the hole that the paining was covering");
                        if (LionKeyTaken == false)
                        {
                            Console.WriteLine("There could still be something in there...");
                            Console.WriteLine("Do you dare place your hand in the hole this time? Yes/No");
                            command = GetCommand();
                            if (command == "Yes" || command == "Take")
                            {
                                Console.WriteLine("You reach in and manage to grab a key!");
                                Console.WriteLine("The key is golden and have a Lions head on it.");
                                hero.AddInventory("Lion Key");
                                LionKeyTaken = true;
                            }
                            else
                            {
                                Console.WriteLine("You left the hole untouched. But you can always come back...");
                            }
                        }
                    }

                }
                if (command == "Inspect")
                {
                    Console.WriteLine("What do you want to inspect?");
                    command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (command == "Bread" && hero.CheckBackPack("Bread"))
                    {
                        Console.WriteLine("\nIt seems to be white barley bread. It's still quite fresh and should be eaten when feeling down.");
                        Console.WriteLine("Item effect: +20 hitpoints\n");
                    }
                    else if (command == "Green Vial" && hero.CheckBackPack("Green Vial"))
                    {
                        Console.WriteLine("\nThis green looking liquid that you got from the alchemy table looks like it came from a swamp.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");
                    }
                    else if (command == "White Vial" && hero.CheckBackPack("White Vial"))
                    {
                        Console.WriteLine("\nThe scent coming from the white liquid seems to penetrate the glass vial. The liquid is silky white.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");

                    }
                    else if (command == "Vial" && hero.CheckBackPack("Vial"))
                    {
                        Console.WriteLine("\nYou got this item from a chest where you started. You can maybe use this if you want to drink something.\n");
                    }
                    else if (command == "Iron Bar" && hero.CheckBackPack("Iron Bar"))
                    {
                        Console.WriteLine("\nAn iron bar that you took from the first room. Maybe you can use this to open something by force.\n");
                    }
                    else if (command == "Rusty Key" && hero.CheckBackPack("Rusty Key"))
                    {
                        Console.WriteLine("\nThis key is covered in rust. Though you suspect that it still will work, if you can find the lock that match the key that is.\n");
                    }
                    else if (command == "Lion Key" && hero.CheckBackPack("Lion Key"))
                    {
                        Console.WriteLine("\nYou have not seen a more extravagant key in your life before. The base of this key is a lions head.\n");
                    }
                    else if (command == "Shield" && hero.CheckBackPack("Shield"))
                    {
                        Console.WriteLine("\nThis is a silver shield that looks like it was forged yesterday.");
                        Console.WriteLine("Upon further inspection you realise that this shield should not be used in combat. and is only for decoration.\n");
                    }
                }
                if (command == "Mirror")
                {
                    if (LookedInMirror == false)
                    {
                        hero.Char_Agility += 3;
                        LookedInMirror = true;
                    }
                    Console.WriteLine("You see yourself and you are looking good!");
                }

                if (command == "Shield" || command == "Silver Shield")
                {
                    if (shieldIsMissing == false)
                    {
                        Console.WriteLine("You look closely at the Shield and realise that you can take it with you!");
                        Console.WriteLine("Do you want to take it with you? Yes/No");
                        string action = GetCommand();
                        if (action == "Yes" || action == "Take")
                        {
                            shieldIsMissing = true;
                            RemoveRoomItem("Shield");
                            hero.AddInventory("Shield");


                        }
                        else { Console.WriteLine("You left the Shield on the wall."); }
                    }
                    else
                    {
                        if (hero.CheckBackPack("Shield"))
                        {
                            Console.WriteLine("You already have the shield in your backpack.");
                        }
                        else
                        {
                            Console.WriteLine("The shield is missing... maybw you have dropped it in another room or placed it somewhere.");
                        }
                    }

                }

            }
            if (roomNumber == 5)
            {
                if (command == "Inspect")
                {
                    Console.WriteLine("What do you want to inspect?");
                    command = FirstUpperCase(Console.ReadLine().ToLower());
                    if (command == "Bread" && hero.CheckBackPack("Bread"))
                    {
                        Console.WriteLine("\nIt seems to be white barley bread. It's still quite fresh and should be eaten when feeling down.");
                        Console.WriteLine("Item effect: +20 hitpoints\n");
                    }
                    else if (command == "Green Vial" && hero.CheckBackPack("Green Vial"))
                    {
                        Console.WriteLine("\nThis green looking liquid that you got from the alchemy table looks like it came from a swamp.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");
                    }
                    else if (command == "White Vial" && hero.CheckBackPack("White Vial"))
                    {
                        Console.WriteLine("\nThe scent coming from the white liquid seems to penetrate the glass vial. The liquid is silky white.");
                        Console.WriteLine("You are not sure what effect this item will give if consumed.\n");

                    }
                    else if (command == "Vial" && hero.CheckBackPack("Vial"))
                    {
                        Console.WriteLine("\nYou got this item from a chest where you started. You can maybe use this if you want to drink something.\n");
                    }
                    else if (command == "Iron Bar" && hero.CheckBackPack("Iron Bar"))
                    {
                        Console.WriteLine("\nAn iron bar that you took from the first room. Maybe you can use this to open something by force.\n");
                    }
                    else if (command == "Rusty Key" && hero.CheckBackPack("Rusty Key"))
                    {
                        Console.WriteLine("\nThis key is covered in rust. Though you suspect that it still will work, if you can find the lock that match the key that is.\n");
                    }
                    else if (command == "Lion Key" && hero.CheckBackPack("Lion Key"))
                    {
                        Console.WriteLine("\nYou have not seen a more extravagant key in your life before. The base of this key is a lions head.\n");
                    }
                    else if (command == "Shield" && hero.CheckBackPack("Shield"))
                    {
                        Console.WriteLine("\nThis is a silver shield that looks like it was forged yesterday.");
                        Console.WriteLine("Upon further inspection you realise that this shield should not be used in combat. and is only for decoration.\n");
                    }
                }
            }

        }


        // En metod med lista på alla kommandon som ska kunna användas från Rooms klassen. 
        // Sätter och returnerar en sträng som motsvarar ditt val
        public string GetCommand()
        {
            List<string> Commands = new List<string>();
            Commands.Add("Yes");
            Commands.Add("No");
            Commands.Add("Take");
            Commands.Add("Drop");

            do
            {
                string choice = FirstUpperCase(Console.ReadLine().ToLower());

                if (Commands.Contains(choice))
                {
                    return choice;
                }

                if (choice == "Help")
                {
                    Console.WriteLine();
                    foreach (var itemCommand in Commands)
                    {
                        Console.WriteLine(itemCommand);
                    }
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("Unknown command");
                    Console.WriteLine("Type \"help\" to see available commands");
                }
            } while (true);

        }

        static string FirstUpperCase(string text)//Gör om all input till konsolen (BANAN) till bara stor förstabokstav (Banan)
        {
            text = new CultureInfo("en-US").TextInfo.ToTitleCase(text);
            return text;
        }


    }
}


