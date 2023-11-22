using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fivecard.model
{
    public class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
