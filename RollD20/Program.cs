using System;

namespace RollD20
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello! This is the RollD20 console app developed by Jordan Neumann written in C#.");
            Console.WriteLine("This DnD inspired app rolls die with user input a given number of times.");
            AskQuestionsAndRollDice();
        }

        static void AskQuestionsAndRollDice()
        {
            int ReturnedDiceType = DiceTypeCollector();
            int ReturnedNumberOfDice = NumberOfDiceCollector();
            DiceRoller(ReturnedDiceType, ReturnedNumberOfDice);
            Looper();
        }

        public static int DiceTypeCollector()
        {
            Console.WriteLine("What kind of dice would you like to roll?");
            Console.WriteLine("Examples include d4, d6, d8, d10, d12, d20, or d100");
            string DiceType = Console.ReadLine();
            string TrimmedDiceType = DiceType.TrimStart('d');
            int DiceTypeInt = Int32.Parse(TrimmedDiceType);
            return DiceTypeInt;
        }


        public static int NumberOfDiceCollector()
        {
            Console.WriteLine("How many dice would you like to roll?");
            string DiceNumber = Console.ReadLine();
            int DiceNumberInt = Int32.Parse(DiceNumber);
            return DiceNumberInt;
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
                Console.WriteLine(DieArray[i]);
            }
            return DieArray;
            
        }

        public static void Looper()
        {
            Console.WriteLine("Would you like to roll again? Type 'y' for yes, or 'n' for no.");
            string LoopAnswer = Console.ReadLine();
            if(LoopAnswer == "y")
            {
                AskQuestionsAndRollDice();
            }
            else if(LoopAnswer == "n")
            {
                Console.WriteLine("Thanks for using Roll D20!");
                return;
            }
            else
            {
                Console.WriteLine("Please input either 'y' or 'n'");
                Looper();
            } 
        }
    }
}
