using fivecard.helper;
using fivecard.model;
using fivecard.Repository;
using fivecard.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;



namespace fivecard.controller
{
    public class Game
    {
        private Deck deck;
        private Player player1;
        private Player aiPlayer;
        private GameHistoryRepository gameHistoryRepository;
        private ConsoleView view;
  
        private string uName; 
        private string Winner;
        private string Username;

        public Game(string RegdUser)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            deck = new Deck();
            player1 = new Player(); //registered user
            aiPlayer = new Player();
            gameHistoryRepository = new GameHistoryRepository(connectionString);
            view = new ConsoleView();
 
            uName = RegdUser;
        }

        public bool isSwap()
        {
            bool startSwap = true;
            bool processSwap = false;
            string swapReply;
            while (startSwap)
            {
                view.DisplayMessage("\nWould you like to swap cards? (y/n)");
                swapReply = Console.ReadLine().ToLower();
                if (swapReply == "y")
                {
                    //flag processSwap
                    startSwap = false;
                    processSwap = true;

                }
                else if (swapReply == "n")
                {
                    //flag processSwap
                    startSwap = false;
                    processSwap = false;
                }
            }
        
           return processSwap;
        }


        public void swapping() {

  /*          view.DisplayMessage("\nHow many cards Would you like to swap ? (max 3)");*/
            int swap = 0;
            bool cont = true;

            while (cont)
            {
                view.DisplayMessage("\nHow many cards Would you like to swap ? (max 3)");
                string swapReply = Console.ReadLine();
                if (!Int32.TryParse(swapReply, out swap))
                {       
                    view.DisplayMessage("Not a valid number!");
                }
                else
                {
                    if (swap > 3 )
                    {
                        view.DisplayMessage("Not a valid number! max 3");
                    }
                    else
                    {
                        cont = false;
                    }  
                }
            }

            //protect
            if (swap > 0)
            {
                int i = 0;
                bool cont2 = true;

                while (i < swap)
                {

                    int numSwap = 0;
                    while (cont2)
                    {
                        view.DisplayMessage("\nWhich card would you like to swap? select from numbered list below");
                        view.DisplayHand(player1.Hand);
                        string swapSelect = Console.ReadLine();
                        if (!Int32.TryParse(swapSelect, out numSwap))
                        {
                            view.DisplayMessage("Not a valid number!");
                        }
                        else
                        {
                            if (numSwap > (player1.Hand.Count-1))
                            {
                                view.DisplayMessage("Not a valid selection!");
                            }
                            else
                            {
                                cont2 = false;
                            }
                        }
                    }

                    player1.Hand.RemoveAt(numSwap);
                    view.DisplayHand(player1.Hand);
                    i += 1;
                }
                player1.Hand.AddRange(deck.DealHand(swap));

            }
        }

        public void StartGame()
        {
            // Deal hands to players
            player1.Hand = deck.DealHand(5);
            aiPlayer.Hand = deck.DealHand(5);

            // Display users hand
            view.DisplayMessage("\nPlayer 1 Hand:");
            view.DisplayHand(player1.Hand);
            if (isSwap()) {
                swapping();
            }

            view.DisplayMessage("\n----------------------------------Show Down!!!!!!----------------------------------");

            //hand evaluation
            HandEvaluation.HandStrength player1HandRank = HandEvaluation.EvaluateHand(player1.Hand);
            HandEvaluation.HandStrength player2HandRank = HandEvaluation.EvaluateHand(aiPlayer.Hand);

            view.DisplayMessage("\n"+ uName + "'s Hand:");
            view.DisplayHand(player1.Hand);
            view.DisplayMessage("\n" + player1HandRank.ToString());
            

            view.DisplayMessage("\nPlayer 2 Hand:");
            view.DisplayHand(aiPlayer.Hand);
            view.DisplayMessage("\n" + player2HandRank.ToString());


            if (player1HandRank > player2HandRank)
            {
                view.DisplayMessage("\n," + uName+" is the winner with:");
                view.DisplayMessage("\n" + player1HandRank.ToString());
                Winner = uName;

            }
            else if (player1HandRank < player2HandRank)
            {
                view.DisplayMessage("\nPlayer 2 is the winner with:");
                view.DisplayMessage("\n" + player2HandRank.ToString());
                Winner = "Computer";    
            }
            else
            {
                view.DisplayMessage("\nIt's a tie with");

            }
            gameHistoryRepository.Add(Winner, uName);

        }

    }
}
