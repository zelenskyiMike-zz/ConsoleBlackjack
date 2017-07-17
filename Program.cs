using System;


namespace ConsoleBlackjack
{
    class Program
    {
        public static void Main()
        {
            string input = "";

            do
            {
                Game.CheckResult(input);

                Console.ReadLine();
                Console.Clear();
            } while (Game.chips != 0 /*Console.ReadKey().Key != ConsoleKey.Escape*/);



        }
    }
}
