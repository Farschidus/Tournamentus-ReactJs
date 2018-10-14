CREATE TABLE dbo.Regions(
	RegionName nvarchar(16) NOT NULL
)
GO

ALTER TABLE dbo.Regions
	ADD CONSTRAINT PK_Regions PRIMARY KEY CLUSTERED (RegionName ASC)
go

