using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{

    public class GameModel
    {
        public Member Dealer = new Member();
        public Member Player = new Member();

        public GameResult Result { get; set; }
        public int StandLimit { get; set; }

        public Deck MainDeck;
        //public BlackjackRules freshKDeck;


        public GameModel(int dealerStandLimit)
        {
            Result = GameResult.Pending;

            StandLimit = dealerStandLimit;

            MainDeck = BlackjackRules.ShuffledDeck;


            Dealer.Hand.Clear();
            Player.Hand.Clear();



            for (int i = 0; ++i < 3;)
            {
                Dealer.Hand.Push(MainDeck.Pop());
                Player.Hand.Push(MainDeck.Pop());
            }
        }


        public void Hit()
        {
            if (BlackjackRules.CanPlayerHit(Player.Hand) && Result == GameResult.Pending)
            {
                Player.Hand.Push(MainDeck.Pop());
            }
        }


        public void Stand()
        {
            if (Result == GameResult.Pending)
            {
                while (BlackjackRules.CanDillerHit(Dealer.Hand, StandLimit))
                {
                    Dealer.Hand.Push(MainDeck.Pop());
                }
            }

            Result = BlackjackRules.GetResult(Player, Dealer);
        }

        public void DoubleRate()
        {
            if (Game.chips >= Game.rate)
            {
                Game.chips -= Game.rate;
                Game.rate += Game.rate;
            }
            if (Game.chips < Game.rate)
            {
                Game.rate += Game.chips;
                Game.chips = 0;
                Console.WriteLine("You are going all-in");
            }
            if (Game.chips == 0)
            {
                Console.WriteLine("You can't rate any more because you don't have chips");
            }
        }
    }
}
