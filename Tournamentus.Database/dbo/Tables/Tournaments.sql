CREATE TABLE dbo.Tournaments(
	TournamentId smallint IDENTITY(1,1) NOT NULL,
	TypeName nvarchar(16) NOT NULL,
	RegionName nvarchar(16) NOT NULL,
	[Name] nvarchar(32) NOT NULL,
	Abbreviation nvarchar(8) NOT NULL,
	[Image] nvarchar(32) NULL,
	TimezoneId nvarchar(50) NOT NULL,
	IsActive bit NOT NULL
)
GO

-- Primary key
ALTER TABLE dbo.Tournaments
	 ADD CONSTRAINT PK_Tournaments PRIMARY KEY CLUSTERED (TournamentId ASC)
GO


-- Default value
ALTER TABLE dbo.Tournaments 
	ADD CONSTRAINT DF_Tournaments_IsActive DEFAULT ((0)) FOR IsActive
GO


-- Foreign keys
ALTER TABLE dbo.Tournaments 
	ADD CONSTRAINT FK_Tournaments_Regions FOREIGN KEY(RegionName) REFERENCES dbo.Regions (RegionName)
GO

ALTER TABLE dbo.Tournaments 
	ADD CONSTRAINT FK_Tournaments_Timezones FOREIGN KEY(TimezoneId) REFERENCES dbo.Timezones (TimezoneId)
GO

ALTER TABLE dbo.Tournaments
	ADD CONSTRAINT FK_Tournaments_Types FOREIGN KEY(TypeName) REFERENCES dbo.[Types] (TypeName)
GO