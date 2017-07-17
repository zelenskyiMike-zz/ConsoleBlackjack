using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{

    public static class BlackjackRules
    {

        public static string[] cards_values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public static string[] cards_suits = { " HEART", " DIAMOND", " CLUB", " SPADE" };

   
        public static Deck NewDeck
        {
            get
            {
                Deck deck = new Deck();
                int value;

                foreach (string cards_suit in cards_suits)
                {
                    foreach (string cards_value in cards_values)
                    {
                        value = Int32.TryParse(cards_value, out value) ? value : cards_value == "A" ? 1 : 10;
                        deck.Push(new Card(cards_value, cards_suit, value));
                    }
                }
                return deck;
            }
        }

       
        public static Deck ShuffledDeck
        {
            get
            {
                return new Deck(NewDeck.OrderBy(card => System.Guid.NewGuid()).ToArray());
            }
        }

        public static double HandValue(Deck deck)
        {
            int value_when_ace_equals_one = deck.Sum(count => count.Value);

            double aces = deck.Count(count => count.Suit == "A");
            double value_when_ace_equals_eleven = aces > 0 ? value_when_ace_equals_one + (10 * aces) : value_when_ace_equals_one;
            return new double[] { value_when_ace_equals_one, value_when_ace_equals_eleven }
                    .Select(handValue => new
                    {
                        handValue,
                        weight = Math.Abs(handValue - 21) + (handValue > 21 ? 100 : 0)
                    }).OrderBy(n => n.weight).First().handValue;
        }

       public static bool CanDillerHit(Deck deck, int standLimit)
        {
            return deck.Value < standLimit;
        }

        public static bool CanPlayerHit(Deck deck)
        {
            return deck.Value < 21;
        }

        public static GameResult GetResult(Member player, Member dealer)
        {
            GameResult gameResult = GameResult.Pending; 

            double playerValue = HandValue(player.Hand);
            double dealerValue = HandValue(dealer.Hand);

            
            if (playerValue <= 21)
            {
                if (playerValue != dealerValue)
                {
                    double mostClosestValue = new double[] { playerValue, dealerValue }.Select(handValue => new
                    {
                        handValue,
                        weight = Math.Abs(handValue - 21) + (handValue > 21 ? 100 : 0)
                    }).OrderBy(n => n.weight).First().handValue;

                    
                    if (playerValue == mostClosestValue)
                    {
                        gameResult = GameResult.Win;
                        Game.chips += Game.rate*2;
                        Game.rate = 0;
                    }
                    else 
                    {
                        gameResult = GameResult.Lose;
                        Game.rate = 0;
                    }
                }

                if (playerValue == dealerValue)
                {
                    gameResult = GameResult.Draw;
                    Game.chips += Game.rate;
                    Game.rate = 0;

                }
            }
            if (playerValue >= 21)
            {
                gameResult = GameResult.Lose;
                Game.rate = 0;
            }

            return gameResult;

        }
    }
}
