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
 *  7)  more math + standard input foo + dates
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
                        runBasicVariables();
                        break;
                    case 4:     //What time
                        runWhatTime();
                        break;
                    case 5:     //Math is easy
                        runMath();
                        break;
                    case 6:     //Basic logic
                        runLogic();
                        break;
                    case 7:     //changing variables
                        runWorkWithDates();
                        break;
                    case 99:    //exit
                        keepRunning = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Creates the tutorial's main menu, returning the user's selection
        /// </summary>
        /// <returns>1-7 for an option choice, or 99 for quit</returns>
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
            menuOption[6] = "7) Work with Dates";
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

        /// <summary>
        /// A basic hello world example
        /// </summary>
        private static void runHelloWorld()
        {
            Console.Clear();
            Console.WriteLine("Hello World, it's C#!");

            closeModule();
        }

        /// <summary>
        /// This method prints a menu asking for a first/last name, and then spits out a greeting with the given values.
        /// </summary>
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

            closeModule();
        }

        /// <summary>
        /// A simple example of variables and working with 'em
        /// </summary>
        private static void runBasicVariables()
        {
            //clear the console
            Console.Clear();

            //create 3 variables to hold our 3 variables
            int x = 1;
            int y = 101;
            int z = 1001;

            //print in number format to the console:
            Console.WriteLine("X is " + x); //an implicit toString happens here
            Console.WriteLine("Y is " + y.ToString());  //this is what is really happening above
            Console.WriteLine("Z is {0}", z);   //this is the preferred way of writing console output

            closeModule();
        }

        /// <summary>
        /// Shows time and how to work with basic time functions
        /// </summary>
        private static void runWhatTime()
        {
            //clear console
            Console.Clear();

            Console.WriteLine("System time is represented as the number of 'ticks' (100 nanoseconds is 1 tick)");
            Console.WriteLine("since Midnight, Jan 1st, in the year 0001.");
            Console.WriteLine("There have been {0} ticks since the start of System time.", 
                System.DateTime.Now.ToFileTime().ToString("N"));

            closeModule();
        }

        /// <summary>
        /// This cleans up modules by clearing screen and displaying necessary info
        /// </summary>
        private static void closeModule()
        {

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Demonstrates basic math operations
        /// </summary>
        private static void runMath()
        {
            Console.Clear();

            int x = 0, y = 0;
            string xPick = "Pick an integer to assign to X: ";
            string yPick = "Pick an integer to assign to Y: ";

            bool validInput = false;

            Console.WriteLine("C# is an excellent tool for math. For example, let's create two variables:");
            
            //keep looping until the x variable is filled
            while (!validInput)
            {
                Console.WriteLine(xPick);
                if (int.TryParse(Console.ReadLine(), out x))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("That is not a valid integer, please try again.");
                }
            }

            validInput = false;
            //keep looping until the y variable is filled
            while (!validInput)
            {
                Console.WriteLine(yPick);
                if (int.TryParse(Console.ReadLine(), out y))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("That is not a valid integer, please try again.");
                }
            }

            //now we have an x and y
            Console.WriteLine("To add, use the '+' sign: {0} + {1} = {2}", x, y, x + y);
            Console.WriteLine("To subtract, use the '-' sign: {0} - {1} = {2}", x, y, x - y);
            Console.WriteLine("To multiply, use the '*' sign: {0} * {1} = {2}", x, y, x * y);
            Console.WriteLine("To divide, use the '/' sign (you only get the whole number, not the remainder: {0} / {1} = {2}"
                , x, y, x / y);
            Console.WriteLine("To get the remainder, use the '%' (modulus) sign: {0} % {1} = {2}",
                x, y, x % y);
            Console.WriteLine("So, {0} divided by {1} = {2} remainder {3}", x, y, x / y, x % y);
            Console.WriteLine("There are a lot of other functions in the Math. library, such as squareroot, etc");
            Console.WriteLine("The square root of {0} is Math.sqrt({0}) = {1}", x * y, Math.Sqrt(x * y));

            closeModule();
        }

        /// <summary>
        /// This method demonstrates algorithmic thinking. The goal is to find an algorithm to create the first 100
        /// numbers of the following sequence: 1, -2, 3, -4, 5, etc.
        /// </summary>
        private static void runLogic()
        {
            Console.Clear();

            //when looking at the sequence, we see a pattern - every even number is negative
            //we can determine a number is even if it's modulus of 2 (n % 2) is 0
            //therefore, we can simply loop from 1 through 100, modding by 2, and multiplying the
            //result by -1 when appropriate
            //since we want 5to print the whole sequence at once, we'll need to use a string type, and when
            //working with Strings, StringBuilder is generally the best class to use.
            StringBuilder output = new StringBuilder();
            for (int i = 1; i <= 100; i++)
            {
                int x = i;
                if (x % 2 == 0)
                    x *= -1;
                output.Append(x);

                //we don't want to add a comma separator for the last number
                if (i < 100)
                    output.Append(", ");
            }

            Console.WriteLine(output);

            closeModule();
        }

        /// <summary>
        /// This demonstrates reading input and working with the result
        /// </summary>
        private static void runWorkWithDates()
        {
            Console.Clear();

            string prompt = "Please enter your birthday in MM/DD/YYYY format: ";
            bool validInput = false;
            DateTime birthday = DateTime.Now;

            while (!validInput)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (!DateTime.TryParse(input, out birthday))
                {
                    Console.WriteLine("Invalid date or format");
                }
                else
                {
                    validInput = true;
                }

            }

            //now determine how many years, months, days, hours, minutes, and seconds old you are
            int years = DateTime.Now.Year - birthday.Year;
            
            //find the months...
            int months = DateTime.Now.Month - birthday.Month;

            //this heuristic corrects for the year wrap-around
            if (months < 0)
                months += 12;

            //find the days...
            int days = DateTime.Now.Day - birthday.Day;
            //this corrects for days
            if (days < 0)
                days *= -1;

            //find the hours
            int hours = DateTime.Now.Hour - birthday.Hour;
            //correct for hour wrapper
            if (hours < 0)
                hours += 24;

            //find the minutes
            int minutes = DateTime.Now.Minute - birthday.Minute;
            //correct for 60 minute wrap-around
            if (minutes < 0)
                minutes += 60;

            //find the seconds
            int seconds = DateTime.Now.Second - birthday.Second;
            //correct for 60 second wrap-around
            if (seconds < 0)
                seconds += 60;

            Console.WriteLine("You are {0} years, {1} months, {2} days, {3} hours, {4} minutes, and {5} seconds old.",
                years, months, days, hours, minutes, seconds);

            closeModule();
        }
    }
}
