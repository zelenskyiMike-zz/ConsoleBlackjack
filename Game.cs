using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class Game
    {

        public static void ShowStats(GameModel gameModel)
        {
            Console.WriteLine("Dealer");
            foreach (Card card in gameModel.Dealer.Hand)
            {
                Console.WriteLine(String.Format("{0}{1}", card.ID, card.Suit));
            }

            Console.WriteLine(gameModel.Dealer.Hand.Value);

            Console.WriteLine(Environment.NewLine);


            Console.WriteLine("Me");
            foreach (Card card in gameModel.Player.Hand)
            {
                Console.WriteLine(String.Format("{0}{1}", card.ID, card.Suit));
            }

            Console.WriteLine(gameModel.Player.Hand.Value);
            Console.WriteLine(Environment.NewLine);

            //Console.Clear();
        }

        public static void Main()
        {
            string input = "";

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
                    if (input.ToLower() != "hit" && input.ToLower() != "stand")
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
            Console.ReadLine();

        }
    }
}
