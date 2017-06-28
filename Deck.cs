using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{   /// <summary>
    /// A deck will be like a stack of cards
    /// </summary>
    public class Deck : Stack<Card>
    {
        public Deck(IEnumerable<Card> collection) : base(collection) { }
        public Deck() : base(52) { } //number of cards

        public Card this[int index]
        {
            get
            {
                Card item;

                if (index >= 0 && index <= this.Count - 1)
                {
                    item = this.ToArray()[index];
                }
                else
                {
                    item = null;
                }
                return item;
            }
        }

        public double Value  //value of the deck
        {
            get
            {
                return BlackjackRules.HandValue(this);
            }
        }
    }
}
