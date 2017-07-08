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
            
            Console.WriteLine("  If you want to play - you have to buy some chips.\n" +
                              "  Please, enter how muth money do you want to spend on it");
            string inputValue = Console.ReadLine();
            

            bool IsItMoney(string input)
            {
                if (String.IsNullOrEmpty(input))
                { return false; }

                if (input == "[0-9]")
                { return true; }

                else return false;
            }


            if (!IsItMoney(inputValue))
            {
                Console.WriteLine("You can enter only numbers and it must be greater than 0.\n" +
                                 "  Please, enter how muth money do you want to spend on it");
               
            }
            if (IsItMoney(inputValue))
            {
                money = Int32.Parse(inputValue);
                Console.WriteLine(inputValue + "$");
            }
            Console.ReadLine();
            //return chips;
        }
    }
}
