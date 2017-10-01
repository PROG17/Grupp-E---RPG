using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG
{
    class ASCII
    {
        public void WelcomeStart()
        {
            string presents = "Group E presents";
            string company = "A Easy Company© game";
            Console.CursorVisible = false;
            FadeIn(presents);
            FadeOut(presents);
            FadeIn(company);
            FadeOut(company);
            FadeInTitle(); //String för titel finns i metoden

            Thread.Sleep(8000);
            Console.Clear();
        }
        public void FadeIn(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(text);
            Thread.Sleep(1000);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);
            Thread.Sleep(500);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Thread.Sleep(500);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void FadeOut(string text)
        {
            Thread.Sleep(1000);
            //Console.SetCursorPosition((Console.WindowWidth / 2) - text.Length, Console.WindowHeight / 2);
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(text);
            //Thread.Sleep(500);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Thread.Sleep(500);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(text);
            Thread.Sleep(500);
            Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2 - 2);
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public void Win()
        {
            Console.CursorVisible = false;
            Console.Clear();
            var win = new[]
            {
                @"    .",
                @"   / \",
                @"   | |",
                @"   |.|",
                @"   |.|",
                @"   |:|      __      ",
                @" ,_|:|_,   /  )      ",
                @"   (Oo    / _I_",
                @"    +\ \  || __| ",
                @"       \ \||___|   ",
                @"         \ /.:.\-\          ",
                @"          |.:. /-----\              ",
                @"          |___|::oOo::|",
                @"          /   |:<_T_>:|",
                @"         |_____\ ::: /",
                @"           | |  \ \:/",
                @"           | |   | |",
                @"           \ /   | \___",
                @"           / |   \_____\",
                @"           `-'",


            };
            var wintext = new[]
            {
                @"Y",
                @"o",
                @"u",
                @"",
                @"W",
                @"i",
                @"n",
                @"!",

            };
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < win.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(win[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < win.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(win[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < win.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(win[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < win.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(win[i]);
            }
            Thread.Sleep(1000);
            for (int i = 0; i < wintext.Length; i++)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition((Console.WindowWidth / 2 - 8) + i, (Console.LargestWindowHeight) / 2 - 2);
                Console.Write(wintext[i]);
            }
            Console.ReadLine();
        }
        public void GameOver()
        {
            Console.CursorVisible = false;
            Console.Clear();

            var death = new[]
            {
                @"             ...",
                @"           ;::::;",
                @"          ;::::; :;",
                @"        ;:::::'   :;",
                @"       ;:::::;     ;.",
                @"      ,:::::'       ;           OOO\",
                @"      ::::::;       ;          OOOOO\",
                @"      ;:::::;       ;         OOOOOOOO",
                @"     ,;::::::;     ;'         / OOOOOOO",
                @"   ;:::::::::`. ,,,;.        /  / DOOOOOO",
                @"  .';:::::::::::::::::;,     /  /     DOOOO",
                @" ,::::::;::::::;;;;::::;,   /  /        DOOO",
                @";`::::::`'::::::;;;::::: ,#/  /          DOOO",
                @":`:::::::`;::::::;;::: ;::#  /            DOOO",
                @"::`:::::::`;:::::::: ;::::# /              DOO",
                @"`:`:::::::`;:::::: ;::::::#/               DOO",
                @" :::`:::::::`;; ;:::::::::##                OO",
                @" ::::`:::::::`;::::::::;:::#                OO",
                @" `:::::`::::::::::::; '`:;::#                O",
                @" `:::::`::::::::;' /  / `:#",
                @"  ::::::`:::::;'  /  /   `#",
            };
            var died = new[]
            {
                @"Y",
                @"o",
                @"u",
                @"",
                @"D",
                @"i",
                @"e",
                @"d",

            };
            var gameover = new[]
            {
                @"G",
                @"a",
                @"m",
                @"e",
                @"",
                @"O",
                @"v",
                @"e",
                @"r",
            };
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < death.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(death[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < death.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(death[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < death.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(death[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < death.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 20, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(death[i]);
            }
            Thread.Sleep(1000);
            for (int i = 0; i < died.Length; i++)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition((Console.WindowWidth / 2 - 6) + i, (Console.LargestWindowHeight) / 2 - 2);
                Console.Write(died[i]);
            }
            Thread.Sleep(2000);
            for (int i = 0; i < gameover.Length; i++)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition((Console.WindowWidth / 2 - 5) + i, (Console.LargestWindowHeight) / 2 - 1);
                Console.Write(gameover[i]);
            }


        }
        public void FadeInTitle()
        {
            var undertitle = new[]
            {
                @"A",
                @"g",
                @"e",
                @"",
                @"O",
                @"f",
                @"",
                @"L",
                @"a",
                @"b",
                @"y",
                @"r",
                @"i",
                @"n",
                @"t",
                @"h",
            };
            var ageoflabyrinth = new[]
        {
            @" ___________________________________________________ ",
            @"//                                                  \\",
            @"||   _________________________________<\            |||",
            @"<>   \________________________________[]########]   |||",
            @"||                                    </            |||",
            @"<>           ___                      __            |||",
            @"||          / _ \                    / _|           |||",
            @"<>         / /_\ \ __ _  ___    ___ | |_            |||",
            @"||         |  _  |/ _` |/ _ \  / _ \|  _|           |||",
            @"<>         | | | | (_| |  __/ | (_) | |             |||",
            @"||         \_| |_/\__, |\___|  \___/|_|             |||",
            @"<>                 __/ |                            |||",
            @"||                |___/                             |||",
            @"<>  _           _                _       _   _      |||",
            @"|| | |         | |              (_)     | | | |     |||",
            @"<> | |     __ _| |__  _   _ _ __ _ _ __ | |_| |__   |||",
            @"|| | |    / _` | '_ \| | | | '__| | '_ \| __| '_ \  |||",
            @"<> | |___| (_| | |_) | |_| | |  | | | | | |_| | | | |||",
            @"|| \_____/\__,_|_.__/ \__, |_|  |_|_| |_|\__|_| |_| |||",
            @"<>                     __/ |                        |||",
            @"||                    |___/                         |||",
            @"<>            />_________________________________   |||",
            @"||   [########[]________________________________/   |||",
            @"<>            \>                                    |||",
            @"\\__________________________________________________//",
            };
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < ageoflabyrinth.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(ageoflabyrinth[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < ageoflabyrinth.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(ageoflabyrinth[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < ageoflabyrinth.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(ageoflabyrinth[i]);
            }
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < ageoflabyrinth.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2 - 14) + i);
                Console.Write(ageoflabyrinth[i]);
            }
            Thread.Sleep(1000);
            for (int i = 0; i < undertitle.Length; i++)
            {
                Thread.Sleep(100);
                Console.SetCursorPosition((Console.WindowWidth / 2 - 6) + i, (Console.LargestWindowHeight) / 2);
                Console.Write(undertitle[i]);
            }
        }
    }
}
