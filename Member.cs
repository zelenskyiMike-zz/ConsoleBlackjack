using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    /// <summary>
    /// representation of Diller and a Player
    /// </summary>
    public class Member
    {
        public Deck Hand;

        public Member()
        {
            Hand = new Deck();
        }
    }
}
