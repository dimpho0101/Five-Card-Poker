using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fivecard.model
{
    public class Player
    {
        public List<Card> Hand { get; set; }

        public void DisplayHand()
        {
            //    foreach (var card in Hand)
            //{
            //  Console.WriteLine("1) " + card);
            //}

            for (int key = 0; key < Hand.Count; ++key)
            {

                Console.WriteLine(key + ")" + Hand[key].Rank + " " + Hand[key].Suit);
            }

        }
    }
}
