using System;
using System.Collections.Generic;
using System.Text;

/*  The ConsoleIntro project is intended to teach children (primarily my sons Luke, 12, and Jacob, 6)
 *  some of the basics of C# programming. It consists of several different modules that a child can 
 *  execute and modify to start understanding the basics. It is intended to be done side-by-side with an adult,
 *  such as a parent, so it makes a lot of assumptions that you are having a conversation, and not just sitting your
 *  kid in front of a computer and saying 'Here, learn to program.'
 *  
 *  It's important to remember that this is designed for children, so readability should take precedence over
 *  elegance
 *  
 *  1)  A basic 'hello world' program
 *  2)  a program which reads name from standard ninput and greets accordingly
 *  3)  basic variable use
 *  4)  current date and time
 *  5)  Simple maths
 *  6)  sequential printing - really primitive logic/algorithm foo
 *  7)  more math + standard input foo
 *  
 *  The idea for this (and the inspiration for a lot of these exercises) come from 
 *  "Fundamentals of Computer Programming with C#", Nakov, et. al., 2013. Very good book, and they deserve a lot 
 *  of credit.
 * 
 *  This is the 'Xeth Open Source License Agreement':
 *  You are free to modify, copy, or otherwise fuck with this all you'd like. It would be nice to get credit,
 *  but it's not like this is some huge accomplishment, so if not it's no big deal. If we ever meet at a 
 *  conference or something and you buy me a beer, that would also be cool. 
 * 
 *  And also, monkeys rule.
 * */

namespace ConsoleIntro
{
    //MainMenu class creates a while loop which displays and control the main menu and exit criteria
    class ConsoleIntro
    {
        //This is a program entry point. Every program needs an entry point; in C#, that is the 'Main' function.
        //Here we will create a loop that displays a mainmenu. When the user presses a selection, the
        //function will hand-off control to the right class. When the user presses Escape, the program exits.
        static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                int menuChoice = runMainMenu();

                switch (menuChoice)
                {
                    case 1:     //hello world
                        runHelloWorld();
                        break;
                    case 2:     //Who are you
                        runWhoAreYou();
                        break;
                    case 3:     //Variables
                        break;
                    case 4:     //What time
                        break;
                    case 5:     //Math is easy
                        break;
                    case 6:     //Basic logic
                        break;
                    case 7:     //changing variables
                        break;
                    case 99:    //exit
                        keepRunning = false;
                        break;
                }
            }
        }

        private static int runMainMenu()
        {
            //we are going to create Strings which make our main menu options, then we will output
            //those strings to the console. This way the user knows what to do. We have 7 options plus
            //an escape option, so we will use 8 strings. We create an array, then set it's size to 8 (remember, 
            //c# counting starts at 0!
            String[] menuOption;
            menuOption = new String[8];
            int userChoice;

            menuOption[0] = "1) Hello C#!";
            menuOption[1] = "2) Who are you?";
            menuOption[2] = "3) Variables?";
            menuOption[3] = "4) What time is it?";
            menuOption[4] = "5) Math is easy (for computers...)";
            menuOption[5] = "6) Basic logic";
            menuOption[6] = "7) Changing variables";
            menuOption[7] = "...or, press any other key to exit";


            //we used an array above so we could demonstrate a for loop. We're going to loop through
            //the array and print out the contents of each line. We then store the value the user pressed
            //in an integer variable.
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(menuOption[i]);
            }

            ConsoleKeyInfo keyPressed = Console.ReadKey(false); //setting the arg to false lets the user see their choice

            //switch statements let you create a list of different possibilities
            switch (keyPressed.KeyChar)
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                    if (int.TryParse(keyPressed.KeyChar.ToString(), out userChoice))
                    {
                        return userChoice;
                    }
                    break;
                default:
                    //this means the user pressed 'any other key'
                    return 99;
            }

            //if we reach here for some reason, return 99
            return 99;
        }

        private static void runHelloWorld()
        {
            Console.Clear();
            Console.WriteLine("Hello World, it's C#!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void runWhoAreYou()
        {
            Console.Clear();
            String firstName;
            String lastName;

            //get the user's first name. Let them quit if they're bored
            String directions = "Enter your first name, or just press enter to quit";
            Console.WriteLine(directions);
            firstName = Console.ReadLine();

            if (firstName.Length == 0)
            {
                Console.Clear();
                return;
            }

            //get the user's last name. Let them quit if they're bored
            directions = "Enter your last name, or just press enter to quit";
            Console.WriteLine(directions);
            lastName = Console.ReadLine();

            if (lastName.Length == 0)
            {
                Console.Clear();
                return;
            }

            //if we reach here, we have a first and last name. Output, and clean up.
            Console.WriteLine("Hello, {0}! It's nice to meet one of the fine {1} clan again!", firstName, lastName);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
