using fivecard.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fivecard.view
{
    internal class ConsoleView
    {
    
    public void DisplayHand(List<Card> hand)
    {
            for (int key = 0; key < hand.Count; ++key)
            {

                Console.WriteLine(key + ")" + hand[key].Rank + " " + hand[key].Suit);
            }
            /*Console.WriteLine("Your hand: \n" + string.Join(", ", hand));*/
        }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }


    }
}
