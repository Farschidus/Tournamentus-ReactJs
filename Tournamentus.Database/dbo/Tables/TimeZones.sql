CREATE TABLE dbo.Timezones(
	TimezoneId nvarchar(50) NOT NULL,
	BaseUtcOffsetInMinutes int NOT NULL,
	DisplayName nvarchar(100) NOT NULL
)
GO

--Primary key
ALTER TABLE dbo.Timezones
	ADD CONSTRAINT PK_Timezones PRIMARY KEY CLUSTERED (TimezoneId ASC)
GO