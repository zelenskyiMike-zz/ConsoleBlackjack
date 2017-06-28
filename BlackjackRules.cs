using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    /// <summary>
    /// game rules representation
    /// </summary>
    public static class BlackjackRules
    {

        public static string[] cards_values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public static string[] cards_suits = { " HEART", " DIAMOND", " CLUB", " SPADE" };

        /// <summary>
        /// returns a new deck
        /// </summary>
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

        /// <summary>
        /// returns a shiffled deck
        /// </summary>
        public static Deck ShuffledDeck
        {
            get
            {
                return new Deck(NewDeck.OrderBy(card => System.Guid.NewGuid()).ToArray());
            }
        }

        /// <summary>
        /// calculating value of points in hand
        /// Here is tho totals for aces that return the most clothest one
        /// to "less than or equal to 21" result
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
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

        //other rules
        /// <summary>
        /// Check if dealer can hit given current value of hand
        /// Assume dealer will always stand on 17 and not hit on soft 17
        /// Hence standLimit
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="standLimit"></param>
        /// <returns></returns>
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
            GameResult gameResult = GameResult.Pending; //???

            double playerValue = HandValue(player.Hand);
            double dealerValue = HandValue(dealer.Hand);

            //player win condition
            if (playerValue <= 21)
            {
                if (playerValue != dealerValue)
                {
                    double mostClosestValue = new double[] { playerValue, dealerValue }.Select(handValue => new
                    {
                        handValue,
                        weight = Math.Abs(handValue - 21) + (handValue > 21 ? 100 : 0)
                    }).OrderBy(n => n.weight).First().handValue;

                    gameResult = playerValue == mostClosestValue ? GameResult.Win : GameResult.Lose;

                }

                else
                {
                    gameResult = GameResult.Draw;
                }
            }
            else
            {
                gameResult = GameResult.Lose;
            }

            return gameResult;

        }
    }
}
