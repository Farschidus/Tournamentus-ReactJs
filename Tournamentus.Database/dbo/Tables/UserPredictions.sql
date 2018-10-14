CREATE TABLE dbo.UserPredictions(
	UserPredictId int IDENTITY(1,1) NOT NULL,
	UserId int NOT NULL,
	MatchId int NOT NULL,
	PredictScoreId tinyint NULL,
	Prediction nvarchar(8) NOT NULL
)
GO

-- Primary key
ALTER TABLE dbo.UserPredictions
	ADD CONSTRAINT PK_UserPredicts PRIMARY KEY CLUSTERED (UserPredictId ASC)
GO


-- Foreign keys
ALTER TABLE dbo.UserPredictions
	ADD CONSTRAINT FK_UserPredictions_Matches FOREIGN KEY(MatchId) REFERENCES dbo.Matches (MatchId)
GO

ALTER TABLE dbo.UserPredictions
	ADD CONSTRAINT FK_UserPredictions_PredictScores FOREIGN KEY(PredictScoreId) REFERENCES dbo.PredictScores (PredictScoreId)
GO

ALTER TABLE dbo.UserPredictions
	ADD CONSTRAINT FK_UserPredictions_Users FOREIGN KEY(UserId) REFERENCES dbo.Users (UserId)
GO

