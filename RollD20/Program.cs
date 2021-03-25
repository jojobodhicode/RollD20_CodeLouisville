using System;
using System.Collections.Generic;
using System.Linq;

namespace RollD20
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello! This is the RollD20 console app developed by Jordan Neumann written in C#.");
            Console.WriteLine("This DnD inspired app rolls die with user input a given number of times.");
            bool rollDice = true;
            while (rollDice)
            {
                AskQuestionsAndRollDice();
                rollDice = RollDiceAgain();
            }
        }

        static void AskQuestionsAndRollDice()
        {
            int ReturnedDiceType = DiceTypeCollector();
            int ReturnedNumberOfDice = NumberOfDiceCollector();
            DiceRoller(ReturnedDiceType,ReturnedNumberOfDice);
        }

        public static int DiceTypeCollector()
        {
            while(true)
            {
                Console.WriteLine("What kind of dice would you like to roll?");
                Console.WriteLine("Examples include d4, d6, d8, d10, d12, d20, or d100");
                string DiceType = Console.ReadLine();
                DiceType = DiceType.ToLower();
                if (DiceType.Substring(0, 1) == "d")
                {
                    try
                    {
                        string TrimmedDiceType = DiceType.TrimStart('d');
                        int DiceTypeInt = Int32.Parse(TrimmedDiceType);
                        return DiceTypeInt;
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Please format your dice type in the format d + number of sides, ex.d4, d6, d10,...");
                    }
                }

                else
                {
                    Console.WriteLine("Please format your dice type in the format d + number of sides, ex.d4, d6, d10,...");
                }
            } 
        }


        public static int NumberOfDiceCollector()
        {
            while(true)
            {
                Console.WriteLine("How many dice would you like to roll?");
                string DiceNumber = Console.ReadLine();
                try
                {
                    int DiceNumberInt = Int32.Parse(DiceNumber);
                    return DiceNumberInt;
                }

                catch (Exception)
                {
                    Console.WriteLine("Please enter an integer. Ex. 1, 2, 3, ...");
                }
            }
        }

        public class Dice
        {
            public int NumberOfSides;
            public int Result;

            public int DiceRoller()
            {
                Random rnd = new Random();
                int RollerResult = rnd.Next(1, NumberOfSides + 1);
                Result = RollerResult;
                return RollerResult;
            }
        }

        public static void DiceRoller(int ReturnedDiceType, int ReturnedNumberOfDice)
        {
            Console.WriteLine("Rolling dice...");
            List<Dice> dieRolls = new List<Dice>();
            int i;
            for(i=0; i < ReturnedNumberOfDice; i++)
            {
                Dice die = new Dice();
                die.NumberOfSides = ReturnedDiceType;
                int Result = die.DiceRoller();
                dieRolls.Add(die);
                Console.Write(Result + " ");
            }
            
            Console.WriteLine("");

            var queryNatHighestNumber = from die in dieRolls
                                        where die.Result == ReturnedDiceType
                                        select die;

            var NumberOfHighestRolls = 0;

            foreach (Dice die in queryNatHighestNumber)
            {
                NumberOfHighestRolls++;
            }
            Console.WriteLine("You rolled the highest number given the dice type " + NumberOfHighestRolls + " times! Congrats!");
        }
       
        static bool RollDiceAgain()
        {
            while (true)
            {
                Console.WriteLine("Would you like to roll again? Type 'y' or 'yes' for yes, and 'n' or 'no' for no");
                string rollDiceAgain = Console.ReadLine();
                rollDiceAgain = rollDiceAgain.ToLower();
                if (rollDiceAgain == "y" || rollDiceAgain == "yes")
                {
                    return true;
                }
                else if (rollDiceAgain == "n" || rollDiceAgain == "no")
                {
                    return false;
                }
            }
        }
    }
}