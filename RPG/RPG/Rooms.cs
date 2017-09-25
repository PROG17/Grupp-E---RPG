using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Rooms
    {
        private string command;
        private int roomNumber;
        List<string> roomItems = new List<string>();

        // Bools för olika event i alla rum
        private bool shieldIsMissing = false;
        

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
                if (roomNumber == 1) { roomItems.Add(item); }
                if (roomNumber == 2) { roomItems.Add(item); }
                if (roomNumber == 3) { roomItems.Add(item); }
                if (roomNumber == 4) { roomItems.Add(item); }
                if (roomNumber == 5) { roomItems.Add(item); }
            }
           
        }

        // Plockar bort items ur respektives lista
        public void RemoveRoomItem(string item)
        {
            if (roomNumber == 1) { roomItems.Remove(item); }
            if (roomNumber == 2) { roomItems.Remove(item); }
            if (roomNumber == 3) { roomItems.Remove(item); }
            if (roomNumber == 4) { roomItems.Remove(item); }
            if (roomNumber == 5) { roomItems.Remove(item); }
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
            List<string> returnItems = new List<string>();
            if (roomNumber == 1)
            {
                Console.WriteLine(
                            "You are in a square room. It has a wooden Door and a Window that seems to be blocked by Iron Bars.");
                Console.WriteLine(
                    "To the East you see a Door that's shut. Besides it you see a Table with some debris on it.");
                // Console.WriteLine("It seems that someone have taken most of your belongings from your backpack.");
                Console.WriteLine("You also see a beautifully ordinated Chest.");
                Console.WriteLine("Maybe there's something left somewhere in this room.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            if (roomNumber == 2)
            {

            }
            if (roomNumber == 3)
            {

            }
            if (roomNumber == 4)
            {
                Console.WriteLine("This is a big room with lots of trophies on the walls! \nA big Carpet on the floor, Mirror on the wall and a big Painting");
                if (shieldIsMissing == false) 
                {
                    Console.WriteLine("But the one thing that really draws to your attantion is a big ");
                    Console.WriteLine("silver Shield");
                    Console.ResetColor();
                }
                

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

                    }

                    foreach (var item in returnItems)
                    {
                        RemoveRoomItem(item);
                    }
                    return returnItems;
                }
            }
            if (roomNumber == 5)
            {
               
            }
            return null;
        }

        // Alla händelser som sker i ett rum 
        public string RoomActin()
        {
            bool tookItem;
            if (roomNumber == 1)
            {
                return null;
            }
            if (roomNumber == 2)
            {
                return null;
            }
            if (roomNumber == 3)
            {
                return null;
            }
            if (roomNumber == 4)
            {
                do
                {
                    Console.WriteLine("What item do you want to take a close look at?");
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (shieldIsMissing)
                    {
                        Console.WriteLine("Carpet - Painting - Mirror");
                    }
                    else
                    {
                        Console.WriteLine("Carpet - Painting - Mirror - Shield");
                    }
                    
                    Console.ResetColor();
                    Console.Write("To do nothing type: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Back");
                    Console.ResetColor();
                    
                    command = command.First().ToString().ToUpper() + command.Substring(1).ToLower();

                    if (command == "Carpet")
                    {
                        Console.WriteLine("You'r standing on the carpet");
                    }
                    if (command == "Painting")
                    {
                        Console.WriteLine("You are looking at the painting and it seems to be something behind it...");
                    }
                    if (command == "Mirror")
                    {
                        Console.WriteLine("You can see yourself");
                    }
                    if (command == "Shield")
                    {
                        Console.WriteLine("You look closely at the Shield and realise that you can take it with you!");
                        Console.WriteLine("Do you want to take it with you?");
                        string action = GetCommand();
                        if (action == "yes" || action == "take")
                        {
                            shieldIsMissing = true;
                            RemoveRoomItem("Shield");
                            return "Shield";
                        }
                        else { Console.WriteLine("You left the Shield on the wall"); }
                    }

                } while (command != "Back");

                return null;
            }
            if (roomNumber == 5)
            {
                return null;
            }
            return null;

        }

        // En metod med lista på alla kommandon som ska kunna användas från Rooms klassen. 
        // Sätter och returnerar en sträng som motsvarar ditt val
        public string GetCommand()
        {
            List<string> Commands = new List<string>();
            Commands.Add("yes");
            Commands.Add("no");
            Commands.Add("take");
            Commands.Add("drop");

            do
            {
                string choice = Console.ReadLine().ToLower();
                
                if (Commands.Contains(choice))
                {
                    return choice;
                }

                if (choice == "help" || choice == "Help")
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
                    Console.WriteLine("Type help to see avalible commands");
                }
            } while (true);
            
        }




    }
}
