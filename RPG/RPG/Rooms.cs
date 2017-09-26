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
        bool CauldronIsFull = true;
        List<string> roomItems = new List<string>();

        // Bools för olika event i alla rum
        private bool shieldIsMissing = false;

        #region First Room Bool

        private bool castleSeen = false;
        private bool ironBar = true;
        private bool KeyFound = false;
        private bool doorOpenWithKey = false;
        private bool doorOpenWithForce = false;

        public bool doorOpend { get; set; }
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
                Console.WriteLine("");
                Console.WriteLine("As soon as you enter this room you are met with the most intoxicating smell that you'll dream of.");
                Console.WriteLine("The room is quite foggy so it takes a while to see that there's only a Table in the room," +
                    " and a door to the west.");
                Console.WriteLine("The smell seems to originate from the Table.");

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
                    castleSeen = true;
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
                                Console.WriteLine("You opened the door with the Rusty Key");
                                hero.DropInventory("Rusty Key");
                                doorOpend = true;
                                doorOpenWithKey = true;
                            }
                            else if (!hero.CheckBackPack("Rusty Key"))
                            {
                                Console.WriteLine("You tried to open the door but you did not have the right key so you tried to push it open");
                            }

                            if (hero.Char_Strength > 11)
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
                if (command == "Table")
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

                        command = FirstUpperCase(Console.ReadLine().ToLower());
                        if ((command == "Drink" && CauldronIsFull == true) || (command == "Take A Sip" && CauldronIsFull == true) || (command == "Cauldron" && CauldronIsFull == true))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You must use a container to drink from.");
                            Console.WriteLine("");

                        }
                        else if ((command == "Drink" && CauldronIsFull == false) || (command == "Take A Sip" && CauldronIsFull == false) || (command == "Cauldron" && CauldronIsFull == false))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("There is not any liquid left in the cauldrons.");
                            Console.WriteLine("");
                        }
                        else if (command == "Use Vial" && hero.CheckBackPack("Vial") && CauldronIsFull == true
                            || command == "Vial" && hero.CheckBackPack("Vial") && CauldronIsFull == true
                            || command == "Fill Vial" && hero.CheckBackPack("Vial") && CauldronIsFull == true
                            || command == "Fill" && hero.CheckBackPack("Vial") && CauldronIsFull == true)
                        {
                            bool UsingAlchTable = true;
                            while (UsingAlchTable == true)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("The right cauldron is filled with white liquid." +
                                    " It also releases a scent that's almost irresistable.");
                                Console.WriteLine("The left cauldron is green and almost looks ominous. " +
                                    "It doesn't smell like anything.");
                                if (hero.Char_Intelligence >= 10)
                                {
                                    Console.WriteLine("Due to your high intelligence you figure out that the right cauldron might be " +
                                        "really dangerous to consume...");
                                }
                                Console.WriteLine("Which one do you want to use the vial on?");
                                Console.WriteLine("");
                                command = FirstUpperCase(Console.ReadLine().ToLower());

                                if (command == "Right" || command == "White")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You fill the vial with the white liquid. " +
                                        "As you are done, all the liquid in the cauldrons vanish.");
                                    Console.WriteLine("");
                                    hero.DropInventory("Vial");
                                    hero.AddInventory("Vial filled with white liquid");
                                    CauldronIsFull = false;
                                    AlchemyTable = false;
                                    UsingAlchTable = false;
                                }
                                else if (command == "Left" || command == "Green")
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("You fill the vial with the green liquid. " +
                                        "As you are done, all the liquid in the cauldrons vanish.");
                                    Console.WriteLine("");
                                    hero.DropInventory("Vial");
                                    hero.AddInventory("Vial filled with green liquid");
                                    CauldronIsFull = false;
                                    AlchemyTable = false;
                                    UsingAlchTable = false;
                                }
                                else if (command == "Back")
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
                        else if (command == "Use Vial" && hero.CheckBackPack("Vial")
                            || command == "Vial" && hero.CheckBackPack("Vial")
                            || command == "Fill Vial" && hero.CheckBackPack("Vial")
                            || command == "Fill" && hero.CheckBackPack("Vial"))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("There is no liquid left in the cauldrons to fill the container with.");
                            Console.WriteLine("");
                        }
                        else if (command == "Use Vial" && !hero.CheckBackPack("Vial") && CauldronIsFull == true
                            || command == "Vial" && !hero.CheckBackPack("Vial") && CauldronIsFull == true
                            || command == "Fill Vial" && !hero.CheckBackPack("Vial") && CauldronIsFull == true
                            || command == "Fill" && !hero.CheckBackPack("Vial") && CauldronIsFull == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You don't have a container to fill.");
                            Console.WriteLine("");
                        }
                        else if (command == "Use Vial" && !hero.CheckBackPack("Vial")
                            || command == "Vial" && !hero.CheckBackPack("Vial")
                            || command == "Fill Vial" && !hero.CheckBackPack("Vial")
                            || command == "Fill" && !hero.CheckBackPack("Vial"))
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You don't have a container to fill. But even so, there isn't even any liquid left here.");
                            Console.WriteLine("");
                        }
                        else if (command == "Right" && CauldronIsFull == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The right cauldron is filled with white liquid. It also releases a scent that's almost irresistable.");
                            Console.WriteLine("");

                        }
                        else if (command == "Right")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The cauldron is empty.");
                            Console.WriteLine("");
                        }
                        else if (command == "Left" && CauldronIsFull == true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The left cauldron is green and almost looks ominous. It doesn't smell like anything.");
                            Console.WriteLine("");
                        }
                        else if (command == "Left")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("The cauldron is empty.");
                            Console.WriteLine("");
                        }
                        else if (command == "Back")
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

                }
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

                    command = Console.ReadLine();
                    command = command.First().ToString().ToUpper() + command.Substring(1).ToLower();

                    if (command == "Carpet")
                    {
                        Console.WriteLine("You'r standing on the carpet");
                    }
                    if (command == "Painting")
                    {
                        if (castleSeen)
                        {
                            Console.WriteLine("The paining i a copy of the castle seen from the iron bard window");
                        }
                        else
                        {
                            Console.WriteLine("You are looking at the painting and it seems to be some kide of castle");
                        }
                        Console.WriteLine("And it looke like there is someting behind it...");

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

                        }
                        else { Console.WriteLine("You left the Shield on the wall"); }
                    }

                } while (command != "Back");

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


