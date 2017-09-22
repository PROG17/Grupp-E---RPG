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
        private bool sheildIsMissing = false;
        

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
                Console.WriteLine("You are in bedroom");

                Console.WriteLine("To the east you see a door that's shut. Besides it you see a table with some debris under it.");
                Console.WriteLine("It seems that someone have taken most of your belongings from your backpack.");
                Console.WriteLine("Maybe there's something left somewhere in this room.");

                Console.WriteLine("Use \"Look\" command to see whats here");
            }

            if (roomNumber == 2)
            {

            }
            if (roomNumber == 3)
            {

            }
            if (roomNumber == 4)
            {
                Console.WriteLine("This is a big room with lots of trofies on the walls! \nA big carpet on the floor, mirror on the wall and a big Painting");
                if (sheildIsMissing == false) 
                {
                    Console.WriteLine("But the one thing that really draws to your attantion is a Big ");
                    Console.WriteLine("Silver Shield");
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

                    if (sheildIsMissing)
                    {
                        Console.WriteLine("Carpet - Painting - Mirror");
                    }
                    else
                    {
                        Console.WriteLine("Carpet - Painting - Mirror - Sheild");
                    }
                    
                    Console.ResetColor();
                    Console.Write("To do nothing type: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Back");
                    Console.ResetColor();

                    command = Console.ReadLine();
                    command = command.First().ToString().ToUpper() + command.Substring(1).ToLower();

                    if (command == "Carpet")
                    {
                        Console.WriteLine("You'r standing on the carpet");
                    }
                    if (command == "Painting")
                    {
                        Console.WriteLine("You are looking at the painting and it seems to be somthing behind it...");
                    }
                    if (command == "Mirror")
                    {
                        Console.WriteLine("You can see yourself");
                    }
                    if (command == "Sheild")
                    {
                        Console.WriteLine("You look closely at the shelad and realise that you can take it with you!");
                        Console.WriteLine("Do you want to take it with you?");
                        string action = GetCommand();
                        if (action == "yes" || action == "take")
                        {
                            sheildIsMissing = true;
                            RemoveRoomItem("Sheild");
                            return "Sheild";
                        }
                        Console.WriteLine("You left the sheild on the wall");
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
                string choise = Console.ReadLine().ToLower();
                
                if (Commands.Contains(choise))
                {
                    return choise;
                }

                if (choise == "help")
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
                    Console.WriteLine("Unknowned command");
                    Console.WriteLine("Type help to see avalible commands");
                }
            } while (true);
            
        }




    }
}
