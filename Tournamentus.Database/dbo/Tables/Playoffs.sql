CREATE TABLE dbo.Playoffs(
	PlayoffTitle nvarchar(16) NOT NULL
)
GO

ALTER TABLE dbo.Playoffs
	ADD CONSTRAINT PK_Playoffs PRIMARY KEY CLUSTERED (PlayoffTitle ASC)
GO