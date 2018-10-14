CREATE TABLE dbo.Matches(
	MatchId int IDENTITY(1,1) NOT NULL,
	HomeTeamId int NOT NULL,
	GuestTeamId int NOT NULL,
	Result nvarchar(8) NULL,
	DateAndTime datetime NULL
)
GO

 -- Primary key
ALTER TABLE dbo.Matches 
    ADD CONSTRAINT PK_Matches PRIMARY KEY CLUSTERED (MatchId ASC)
GO


-- Foreign key
ALTER TABLE dbo.Matches  
	ADD CONSTRAINT FK_Matches_TournamentTeams FOREIGN KEY(HomeTeamId) REFERENCES dbo.TournamentTeams (TournamentTeamId)
GO

ALTER TABLE dbo.Matches 
	ADD CONSTRAINT FK_Matches_TournamentTeams1 FOREIGN KEY(GuestTeamId) REFERENCES dbo.TournamentTeams (TournamentTeamId)
GO

