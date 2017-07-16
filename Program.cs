using System;


namespace ConsoleBlackjack
{
    class Program
    {
        public static void Main()
        {
            string input = "";
            int money = 0;

            //Chips.BuyChips();

            Console.WriteLine(Chips.BuyChips().ToString());
            Console.ReadLine();
            //do
            //{
            //    Game.CheckResult(input);

            //    Console.ReadLine();
            //    Console.Clear();
            //} while (Console.ReadKey().Key != ConsoleKey.Escape);



        }
    }
}
