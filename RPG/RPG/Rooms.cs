using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Rooms
    {
        private int roomNumber;

        public Rooms(int RoomNumber)
        {
            this.roomNumber = RoomNumber;
        }

        public void RoomInfo()
        {
            string Command = Console.ReadLine().ToLower();
            if (roomNumber == 1)
            {
                // Console.WriteLine("You wake up in a room. It have a wooden door and one window that seems to be blocked by iron bars.");
                Console.WriteLine("You are in bedroom");
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

            }
            if (roomNumber == 5)
            {

            }
        }
    }
}
