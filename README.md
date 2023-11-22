# Five-Card-Poker


## Five-Card Draw Poker Console Application
### Overview
This console-based application is designed to simulate a simplified version of the classic poker variant, Five-Card Draw. In this variant, each player is dealt a hand of 5 cards, with the option to swap any number of those cards for new ones. However, in this particular implementation, there is no card swapping allowed. Players will compete against each other based on the standard 5-card poker hand rankings.

## Features
Dealing Hands: The application deals a hand of 5 cards to each player participating in the game.

Hand Evaluation: The program evaluates and compares poker hands based on the standard 5-card poker hand rankings (e.g., pairs, two pairs, three of a kind, straight, flush, full house, etc.).

Console Interface: The entire interaction with the application is done through the console, providing a user-friendly experience.

Built with C#, Dapper, and SQL Server: The application is developed using the C# programming language. Dapper, a simple object mapper for .NET and SQL Server, is employed for data access and management.

## Prerequisites
.NET SDK
SQL Server

##Getting Started
Clone the repository to your local machine.

bash
Copy code
git clone [https://github.com/your-username/five-card-draw-poker.git]
Open the project in your preferred C# development environment (e.g., Visual Studio).

Set up the SQL Server database using the provided scripts.

Configure the database connection string in the application.

Build and run the application.

## Database Schema
The application utilizes a SQL Server database to store and manage game-related data. The database schema includes tables for players, hands, and game history.
