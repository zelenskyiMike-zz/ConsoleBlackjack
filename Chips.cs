using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class Chips
    {
        public static int BuyChips(int money)
        {
            int chips = 0;
            Console.WriteLine("  If you want to play - you have to buy some chips.\n" +
                              "  Please, enter how muth money do you want to spend on it");

            if (Int32.TryParse(Console.ReadLine(), out money))
            {
                if(money > 0 )
                Console.WriteLine(money);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("  You can enter only numbers and it must be greater than 0.\n" +
                                 "  Please, enter how muth money do you want to spend on it ");
                Console.ReadLine();
            }
            //try
            //{
            //    money = Int32.Parse(Console.ReadLine());

            //    if (money <= 0)
            //        throw new Exception();
            //}
            //catch (Exception e)
            //{
            //    Console.Clear();
            //    Console.WriteLine("  You can enter only numbers and it must be greater than 0.\n" +
            //                      "  Please, enter how muth money do you want to spend on it ");
            //    Console.WriteLine(money);
            //    Console.ReadLine();
            //}
            ////finally
            //{
            //    Console.Clear();
            //    Console.WriteLine();
            //}

            return chips;
        }
    }
}
