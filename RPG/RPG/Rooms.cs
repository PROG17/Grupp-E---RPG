using System;
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
        List<string> roomItems = new List<string>();

        // Bools för olika event i alla rum
        private bool shieldIsMissing = false;

        #region First Room Bool

        private bool ironBar = true;
        private bool KeyFound = false;
        private bool doorOpenWithKey = false;
        private bool doorOpenWithForce = false;

        public bool doorOpend { get; set; }
        #endregion

        #region Forth Room 

        private bool paintingOnFloor = false;
        private bool LionKeyTaken = false;
        private bool LookedInMirror = false;

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
                Console.WriteLine("You also see a beautifully ordinated Chest.");
                Console.WriteLine("To the East you see a Door that's shut. Besides it you see a Table with some debris on it.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                List<string> returnItems = ItemsOnFloor();
                return returnItems;

            }

            if (roomNumber == 2)
            {

               
            }
            if (roomNumber == 3)
            {

            }
            if (roomNumber == 4)
            {
                Console.WriteLine("This is a big room with lots of trophies on the walls! \nA big Carpet on the floor, Mirror on the wall and a big Painting of a castle");
                if (shieldIsMissing == false)
                {
                    Console.WriteLine("But the one thing that really draws to your attantion is a big Silver Shield");
                }

                List<string> returnItems = ItemsOnFloor();
                return returnItems;
            }
            if (roomNumber == 5)
            {

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
                    Console.WriteLine("Do you want to pick it up?");
                    string action = GetCommand();
                    if (action == "yes" || action == "take")
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
                        Console.WriteLine("");
                        Console.WriteLine("The Chest is opened wide. There chest is empty");
                        Console.WriteLine("");

                    }

                    else if (CheckChestOpen == false)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("The Chest is beautifully ornated with purple lion emblems on the sides.");
                        Console.WriteLine("You examine it more closely but it seems that you can't open it without a key.");
                        Console.WriteLine("");
                        Console.WriteLine("Try to open chest? Yes/No?");
                        command = GetCommand();

                        if (command == "Yes" && (hero.CheckBackPack("Lion Key") || hero.CheckBackPack("Iron Bar")))
                        {
                            CheckChestOpen = true;
                            Console.WriteLine("");
                            if (hero.CheckBackPack("Lion Key"))
                            {
                                Console.WriteLine("You open the Chest with the Lion Key!");
                                hero.DropInventory("Lion Key");

                            }
                            else
                            {
                                Console.WriteLine("You pry open the Chest with the Iron Bar!");
                            }
                            Console.WriteLine("There is a Vial in here. You placed it in your backpack!");
                            Console.WriteLine("");
                            hero.AddInventory("Vial");

                        }
                        else if (command != "Yes")
                        {
                            Console.WriteLine("You left the chest unopend...");
                        }
                        else
                        {
                            Console.WriteLine("You are missing an requierd item to open the chest");
                        }

                    }
                }

                if (command == "Window")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You look past the Iron Bars through the Window and you see a giant white castle on a green hill.");
                    Console.WriteLine("The castle have four towers that seems to stretch towards the heaven.");
                    Console.WriteLine("You also see two mountains in the distance that makes the castle even more beautiful.");
                    Console.WriteLine("However you get the feeling that there's no one in the castle.");
                    Console.WriteLine("");

                    Console.WriteLine("Do you want to open the widom? Yes/No");
                    command = GetCommand();

                    if (command == "Yes")
                    {

                        Console.WriteLine("");
                        Console.WriteLine("The Window is closed and can't be opened. Even if you could open it it's blocked by Iron Bars.");

                        if (ironBar == true)
                        {
                            Console.WriteLine("You also see that one of the iorn bars is loos and you try to take it with you.");
                            Console.WriteLine("");

                            if (hero.Char_Strength > 7)
                            {
                                Console.WriteLine("With your mighy strengh it was no problem and the Iorn Bar was added to your backpack");
                                hero.AddInventory("Iron Bar");
                                ironBar = false;
                            }
                            else
                            {
                                Console.WriteLine("You seem to be too weak to take it. If only you hade somthing that made you stronger...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Eaven tho one of the iron bars are missing");
                        }

                    }

                }

                if (command == "Table")
                {
                    if (KeyFound == false)
                    {
                        KeyFound = true;
                        Console.WriteLine("");
                        Console.WriteLine("You look through the debris and the only thing worth noticing is a Rusty Key.");
                        Console.WriteLine("Maybe this can be useful.");
                        Console.WriteLine("You took the Rusty Key and placed it in your backpack");
                        hero.AddInventory("Rusty Key");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("All you see is the old table, but nothing more on it.");
                    }
                }

                if (command == "Door")
                {
                    Console.WriteLine("");
                    Console.WriteLine("You approach the wooden Door.");

                    if (doorOpend == false)
                    {
                        Console.WriteLine("The Door is locked but the lock seems old.");
                        Console.WriteLine("");
                        Console.WriteLine("Try opening the door? Yes/No");
                        command = GetCommand();
                        if (command == "Yes")
                        {
                            if (hero.CheckBackPack("Rusty Key"))
                            {
                                Console.WriteLine("You opend the door with the Rusty Key");
                                hero.DropInventory("Rusty Key");
                                doorOpend = true;
                                doorOpenWithKey = true;
                            }
                            else if (!hero.CheckBackPack("Rusty Key"))
                            {
                                Console.WriteLine("You tried to open the door but you did not have the right key so you tried to push it open");
                            }

                            else if (hero.Char_Strength > 11)
                            {
                                Console.WriteLine("You smash the Door open with your unbridled power.");
                                doorOpend = true;
                                doorOpenWithForce = true;
                            }
                            else
                            {
                                Console.WriteLine("The Door is old but is sturdy enough to withstand the force of your impact.");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You left the door closed...");
                        }

                    }
                    else
                    {
                        if (doorOpenWithKey == true)
                        {
                            Console.WriteLine("The door is alrady open");
                        }
                        else if (doorOpenWithForce == true)
                        {
                            Console.WriteLine("The door is smashed to pieces");
                        }
                    }
                }



            }
            if (roomNumber == 2)
            {

            }
            if (roomNumber == 3)
            {

            }
            if (roomNumber == 4)
            {
                if (command == "Carpet")
                {
                    Console.WriteLine("You'r standing on the carpet and lookig up in the ceiling, there is a huge chandelier and you are hoping it wont fall down on you.");
                }
                if (command == "Painting")
                {
                    Console.WriteLine("You are looking at the painting and it seems to be some kide of castle");

                    if (paintingOnFloor == false)
                    {
                        Console.WriteLine("And it looke like there is someting behind it...");
                        Console.WriteLine("Take down the painting? Yes/No");
                        command = GetCommand();

                        if (command == "Yes" || command == "Take")
                        {
                            paintingOnFloor = true;
                            if (hero.Char_Intelligence < 7)
                            {
                                Console.WriteLine("OH CLUMSY YOU!");
                                Console.WriteLine("You dropped the painting on your head and lost 20 helth...");
                                hero.Hp -= 20;

                            }
                            else
                            {
                                Console.WriteLine("You placed the paning on the floor");
                            }
                            Console.WriteLine("Behind it you see a hole in the wall. Guess the painting WAS hiding something");
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
                                Console.WriteLine("You left the hole untuched. But you can always come back...");
                            }


                        }
                        else
                        {
                            Console.WriteLine("The paining is laying on the floor and you can see the hole that the paining was covering");
                            if (LionKeyTaken == false)
                            {
                                Console.WriteLine("There could still be something in there...");
                                Console.WriteLine("Do you dare place your hand in the hole this time? Yes/No");
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
                                    Console.WriteLine("You left the hole untuched. But you can always come back...");
                                }
                            }
                        }

                    }



                }
                if (command == "Mirror")
                {
                    if (LookedInMirror == false)
                    {
                        hero.Char_Intelligence += 3;
                        LookedInMirror = true;
                    }
                    Console.WriteLine("You see yourself and you are looking good!");
                }

                if (command == "Shield" || command == "Silver Shield")
                {
                    if (shieldIsMissing == false)
                    {
                        Console.WriteLine("You look closely at the Shield and realise that you can take it with you!");
                        Console.WriteLine("Do you want to take it with you?");
                        string action = GetCommand();
                        if (action == "Yes" || action == "Take")
                        {
                            shieldIsMissing = true;
                            RemoveRoomItem("Shield");
                            hero.AddInventory("Shield");


                        }
                        else { Console.WriteLine("You left the Shield on the wall"); }
                    }
                    else
                    {
                        if (hero.CheckBackPack("Shield"))
                        {
                            Console.WriteLine("You allready have the shield in your backpack");
                        }
                        else
                        {
                            Console.WriteLine("The shield is missing... maby you have dropped it in another room");
                        }
                    }

                }

            }
            if (roomNumber == 5)
            {

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
                    Console.WriteLine("Type \"help\" to see avalible commands");
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
