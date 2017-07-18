using System;
using System.Reflection;
using System.Diagnostics;

namespace ConsoleBlackjack
{
    class Game
    {
        public static int chips = Chips.BuyChips();
        public static int rate = 0;
        
        public static void ShowStats(GameModel gameModel)
        {
            
            Console.WriteLine("Dealer");
            foreach (Card card in gameModel.Dealer.Hand)
            {
                Console.WriteLine(String.Format("{0}{1}", card.ID, card.Suit));
            }

            Console.WriteLine("\n"+gameModel.Dealer.Hand.Value+" points");

            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Me");
            foreach (Card card in gameModel.Player.Hand)
            {
                Console.WriteLine(String.Format("{0}{1}", card.ID, card.Suit));
            }

            Console.WriteLine("\n" + gameModel.Player.Hand.Value + " points");
            Console.WriteLine("\nYour rate " + rate + " chips");
            Console.WriteLine("You totally have " + chips + " chips now");
            Console.WriteLine(Environment.NewLine);

        }

        public static void CheckResult(string input)
        {
            
            int blind = 1;
            chips -= blind;
            rate += blind;
            GameModel gameModel = new GameModel(17);

            ShowStats(gameModel);

            while (gameModel.Result == GameResult.Pending)
            {
                input = Console.ReadLine();
                Console.Clear();
                try
                {
                    if (input.ToLower() == "hit")
                    {
                        gameModel.Hit();
                        ShowStats(gameModel);
                    }

                    if (input.ToLower() == "stand")
                    {
                        gameModel.Stand();
                        ShowStats(gameModel);
                        
                    }
                    if (input.ToLower() == "double")
                    {
                        gameModel.DoubleRate();
                        ShowStats(gameModel);
                    }
                    if (input.ToLower() != "hit" && input.ToLower() != "stand" && input.ToLower() != "double")
                    {
                        ShowStats(gameModel);
                        throw new Exception("Wrong command");
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                
            }
            Console.WriteLine(gameModel.Result);
            
            Console.WriteLine("if you want to play again and you have some chips - just press any key");

        }

    }
}
