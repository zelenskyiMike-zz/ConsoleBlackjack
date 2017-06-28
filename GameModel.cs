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

            //Clear hands
            Dealer.Hand.Clear();
            Player.Hand.Clear();

            //Gives first two cards to both players

            for (int i = 0; ++i < 3;)
            {
                Dealer.Hand.Push(MainDeck.Pop());
                Player.Hand.Push(MainDeck.Pop());
            }
        }

        /// <summary>
        /// allow player to hit. Dealer automatically hit when player stands.
        /// </summary>
        public void Hit()
        {
            if (BlackjackRules.CanPlayerHit(Player.Hand) && Result == GameResult.Pending)
            {
                Player.Hand.Push(MainDeck.Pop());
            }
        }

        /// <summary>
        /// When user stands , allows the Dealer to continue hitting until standLimit or bust.
        /// Then sets game results.
        /// </summary>
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
    }
}
