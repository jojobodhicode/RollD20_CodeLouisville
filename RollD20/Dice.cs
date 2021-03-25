using System;

namespace RollD20
{
    partial class Program
    {
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
    }
}