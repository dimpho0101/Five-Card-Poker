using Dapper;

using fivecard.controller;

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fivecard.Repository
{
    public class GameHistoryRepository
    {
        private readonly string connectionString;

        public GameHistoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Game> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Game>("SELECT * FROM GameHistory");
            }
        }

        public Game GetById(int GameID)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Game>("SELECT * FROM GameHistory WHERE GameID = @GameID", new { GameID });
            }
        }

        public void Add(string winner, string username)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"USE FiveCard; INSERT INTO GameHistory (Winner, UserID) VALUES (@Winner, (Select UserID from Users where username = @username))", new { winner, username });
            }
        }

        public void Update(Game game)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"USE FiveCard;UPDATE GameID SET username = @username, pword = @pword WHERE Id = @Id", game);
            }
        }

        public void Delete(int GameID)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM GameHistory WHERE GameID = @GameID", new { GameID });
            }
        }
    }
}
