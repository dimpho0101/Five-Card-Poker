using Dapper;
using fivecard.model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fivecard.Repository
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Users> GetAll()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<Users>(@"USE FiveCard;SELECT Username FROM Users");
            }
        }

        public Users GetById(int UserID)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Users>("SELECT * FROM Users WHERE UserID = @UserID", new { UserID });
            }
        }

        public Users GetByUsername(string Username)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Users>(@"USE FiveCard;SELECT Username,UserID FROM Users WHERE Username = @Username", new { Username });
            }
        }


        public void Add(Users user)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"USE FiveCard; INSERT INTO Users (username) VALUES (@username)", user);
                //dbConnection.Execute(@"USE FiveCard; INSERT INTO Users (username, pword) VALUES (@username, CONVERT(VARBINARY(256), HASHBYTES('SHA2_256', '@pword')))", user);
            }
        }

        public void Update(Users user)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Users SET username = @username, pword = @pword WHERE Id = @Id", user);
            }
        }

        public void Delete(int UserID)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Users WHERE UserID = @UserID", new { UserID });
            }
        }
    }
}
