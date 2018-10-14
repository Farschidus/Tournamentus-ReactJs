CREATE TABLE dbo.Teams(
	TeamId smallint IDENTITY(1,1) NOT NULL,
	TypeName nvarchar(16) NOT NULL,
	RegionName nvarchar(16) NOT NULL,
	Name nvarchar(32) NOT NULL,
	Abbreviation nvarchar(8) NOT NULL,
	Image nvarchar(32) NULL
)
GO

-- Primary key
ALTER TABLE dbo.Teams
	ADD CONSTRAINT PK_Teams PRIMARY KEY CLUSTERED (TeamId ASC)
GO

-- Foreign keys
ALTER TABLE dbo.Teams
	ADD CONSTRAINT FK_Teams_Regions FOREIGN KEY(RegionName) REFERENCES dbo.Regions (RegionName)
GO

ALTER TABLE dbo.Teams 
	ADD CONSTRAINT FK_Teams_Types FOREIGN KEY(TypeName) REFERENCES dbo.[Types] (TypeName)
GO