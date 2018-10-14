CREATE TABLE dbo.PredictScores(
	PredictScoreId tinyint IDENTITY(1,1) NOT NULL,
	Score int NOT NULL,
	Description nvarchar(64) NULL
)
GO

-- Primry key
ALTER TABLE dbo.PredictScores
	ADD CONSTRAINT PK_PredictScores PRIMARY KEY CLUSTERED (PredictScoreId ASC)
GO