CREATE TABLE dbo.TournamentUsers(
	TournamentId smallint NOT NULL,
	UserId int NOT NULL
)
GO


-- Primary key
ALTER TABLE dbo.TournamentUsers
	ADD CONSTRAINT PK_TournamentUsers PRIMARY KEY CLUSTERED (TournamentId ASC, UserId ASC)
GO


-- Foreign keys
ALTER TABLE dbo.TournamentUsers 
	ADD CONSTRAINT FK_TournamentUsers_Tournaments FOREIGN KEY(TournamentId) REFERENCES dbo.Tournaments (TournamentId)
GO

ALTER TABLE dbo.TournamentUsers
	ADD CONSTRAINT FK_TournamentUsers_Users FOREIGN KEY(UserId) REFERENCES dbo.Users (UserId)
GO