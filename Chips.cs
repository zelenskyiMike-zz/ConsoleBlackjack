using System;
using System.Text.RegularExpressions;

namespace ConsoleBlackjack
{
    class Chips
    {
        public static int BuyChips(/*string inputValue*/)
        {
            int money = 0;
            int chips = 0;
            var regex = new Regex(@"^\d+$");
            int chipsValue = 0;

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
                money = Int32.Parse(inputValue);

                if (money < 10)
                {
                    chipsValue = 1;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips each with a face value of {1} dollars", chips, chipsValue);
                }
                if (money >= 10 && money <= 100)
                {
                    chipsValue = 5;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips each with a face value of {1} dollars", chips, chipsValue);
                }
                if (money > 100 && money <= 500)
                {
                    chipsValue = 10;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips with a face value of {1} dollars", chips, chipsValue);

                }
                if (money > 500 && money <= 1000)
                {
                    chipsValue = 50;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips each with a face value of {1} dollars", chips, chipsValue);
                }
                if (money > 500 && money <= 1000)
                {
                    chipsValue = 50;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips each with a face value of {1} dollars", chips, chipsValue);
                }
                if (money > 1000 && money <= 5000)
                {
                    chipsValue = 100;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips each with a face value of {1} dollars", chips, chipsValue);
                }
                if (money > 5000 && money <= 50000)
                {
                    chipsValue = 1000;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips each with a face value of {1} dollars", chips, chipsValue);
                }
                if (money > 50000)
                {
                    chipsValue = 5000;
                    chips = money / chipsValue;
                    Console.WriteLine("You have {0} chips each with a face value of {1} dollars", chips, chipsValue);
                }
                Console.ReadLine();
            }

            return chips;
        }
    }
}
