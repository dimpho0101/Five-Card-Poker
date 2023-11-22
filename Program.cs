using Dapper;
using fivecard.model;
using fivecard.Repository;
using fivecard.controller;
using fivecard.view;
using Microsoft.Data.SqlClient;

namespace fivecard
{
    public class Program
    {

        private static ConsoleView view;

        static void Main(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            view = new ConsoleView();

            view.DisplayMessage("Welcome to Five-Card Draw Poker!");

            //REG handler
            view.DisplayMessage("Please enter a username");
            view.DisplayMessage("Username:");
            String uname = Console.ReadLine();


            view.DisplayMessage("Hi " + uname);
  
            var urepository = new UserRepository(connectionString);



            Users userList = urepository.GetByUsername(uname);
            if (userList is null )
            {
                //register
                urepository.Add(new Users { username = uname });
            }
            else
            {
                view.DisplayMessage("Welcome back!");
            }


            Game pokerGame = new Game(uname);

           //ensure game loops
            bool keepPlaying = true;
            while (keepPlaying)
            {
                pokerGame.StartGame();
                
                Console.WriteLine("\nWould you like to play again? y/n");
                
                string option = Console.ReadLine();
                if (option.ToLower() == "y")
                {
                    view.DisplayMessage("Welcome back!New Round.");
                }
                else if (option.ToLower() == "n")
                {
                    view.DisplayMessage("Game has ended.");
                    keepPlaying = false;
                }
            }  
        }
     
        }
}
