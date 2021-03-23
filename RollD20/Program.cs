using System;

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
            DiceRoller(ReturnedDiceType, ReturnedNumberOfDice);
        }

        public static int DiceTypeCollector()
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
                    return DiceTypeCollector();
                }
            }

            else
            {
                Console.WriteLine("Please format your dice type in the format d + number of sides, ex.d4, d6, d10,...");
                return DiceTypeCollector();
            }
        }


        public static int NumberOfDiceCollector()
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
                return NumberOfDiceCollector();
            }
        }

        public static int[] DiceRoller(int ReturnedDiceType, int ReturnedNumberOfDice)
        {
            Console.WriteLine("Rolling dice...");
            int i;
            int[] DieArray = new int[ReturnedNumberOfDice];
            for (i = 0; i < ReturnedNumberOfDice; i++)
            {
                Random rnd = new Random();
                int RollerResult = rnd.Next(1, ReturnedDiceType + 1);
                DieArray[i] = RollerResult;
                Console.Write(DieArray[i] + " ");
            }
            Console.WriteLine(" ");
            return DieArray;

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