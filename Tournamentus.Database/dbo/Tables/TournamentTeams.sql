CREATE TABLE dbo.TournamentTeams(
	TournamentTeamId int IDENTITY(1,1) NOT NULL,
	TournamentId smallint NOT NULL,
	TeamId smallint NOT NULL,
	GroupName nvarchar(16) NOT NULL,
	PlayoffTitle nvarchar(16) NULL,
	InGroupResults nvarchar(256) NULL
)
GO

-- Primary key
ALTER TABLE dbo.TournamentTeams
	ADD CONSTRAINT PK_TournamentTeams PRIMARY KEY CLUSTERED (TournamentTeamId ASC)
GO

-- Foreign keys
ALTER TABLE dbo.TournamentTeams 
	ADD CONSTRAINT FK_TournamentTeams_Groups FOREIGN KEY(GroupName) REFERENCES dbo.Groups (GroupName)
GO

ALTER TABLE dbo.TournamentTeams 
	ADD CONSTRAINT FK_TournamentTeams_Playoffs FOREIGN KEY(PlayoffTitle) REFERENCES dbo.Playoffs (PlayoffTitle)
GO

ALTER TABLE dbo.TournamentTeams 
	ADD CONSTRAINT FK_TournamentTeams_Teams FOREIGN KEY(TeamId) REFERENCES dbo.Teams (TeamId)
GO

ALTER TABLE dbo.TournamentTeams 
	ADD CONSTRAINT FK_TournamentTeams_Tournaments FOREIGN KEY(TournamentId) REFERENCES dbo.Tournaments (TournamentId)
GO

