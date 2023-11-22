

DROP DATABASE IF EXISTS FiveCard;


CREATE DATABASE FiveCard;
Use FiveCard;
BEGIN TRY
Begin Transaction;
CREATE TABLE Users(
	UserID INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    Username NVARCHAR(20),
    pword VARBINARY(256)
)

CREATE TABLE GameHistory(
	GameID INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    winner NVARCHAR(20),
	UserID int,
	CONSTRAINT FK_user FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

commit;
END TRY
BEGIN CATCH
    -- Handle errors, rollback transaction, log, etc.
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH;