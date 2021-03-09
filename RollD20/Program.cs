using System;

namespace RollD20
{
    class Program
    {
        static void Main()
        {
            //Introducer();
            //DiceTypeCollector();
            //NumberOfDiceCollector();
            //DiceRoller();
            //Looper()
        }

        public static string Introducer(string Introduction)
        {
            Console.WriteLine("Hello! This is the RollD20 console app developed by Jordan Neumann written in C#.");
            Console.WriteLine("This DnD inspired app rolls die with user input a given number of times.");
            return null;
        }

        public static string DiceTypeCollector(string diceType)
        {
            Console.WriteLine("What kind of dice would you like to roll?");
            Console.WriteLine("Examples include d4, d6, d8, d10, d12, d20, or d100");
            diceType = Console.ReadLine();
            return diceType;
        }


        public static int NumberOfDiceCollector(string diceNumber)
        {
            Console.WriteLine("How many dice would you like to roll? (Please limit number of dice to 100)");
            diceNumber = Console.ReadLine();
            int diceNumberInt = Int32.Parse(diceNumber);
            return diceNumberInt;
        }

        /* public static string[] DiceRoller(DiceType, NumberOfDice)
        {
            Console.WriteLine("Rolling dice...");
        }

        public static string Looper(string LoopAnswer)
        {
            Console.WriteLine("Would you like to roll again?");
            LoopAnswer = Console.ReadLine();
            if(LoopAnswer == "y" || "yes")
            {
            Main();
            }
            else if(LoopAnswer == "n" || "no")
            {
            Console.WriteLine("Thanks for using Roll D20!");
            exit
            }
            else
            {
            Console.WriteLine("Please input either 'yes' or 'no'")
        } */
    }
}
