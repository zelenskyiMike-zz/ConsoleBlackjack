using System;
using System.Text.RegularExpressions;

namespace ConsoleBlackjack
{
    class Chips
    {
        public static void BuyChips()
        {
            int money = 0;
            int chips = 0;
            var regex = new Regex(@"^\d+$");
            
            Console.WriteLine("  If you want to play - you have to buy some chips.\n" +
                              "  Please, enter how muth money do you want to spend on it");
            string inputValue = Console.ReadLine();

            
            while (!regex.IsMatch(inputValue) || inputValue == "0")
            {
                Console.WriteLine("Try again " + inputValue);
                inputValue = Console.ReadLine();
                

            }
            if (regex.IsMatch(inputValue))
            {
                Console.WriteLine("Fine " + inputValue);
                Console.ReadLine();
            }

            
        }
    }
}
