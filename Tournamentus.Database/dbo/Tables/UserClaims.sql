CREATE TABLE dbo.UserClaims (
    UserClaimId  INT            IDENTITY (1, 1) NOT NULL,
    UserId       INT            NOT NULL,
    ClaimType    NVARCHAR (MAX) NULL,
    ClaimValue   NVARCHAR (MAX) NULL
)
GO

-- Primary key
ALTER TABLE dbo.UserClaims
	ADD CONSTRAINT PK_UserClaims PRIMARY KEY CLUSTERED (UserClaimId ASC)
GO

-- Foreign key
ALTER TABLE dbo.UserClaims
    ADD CONSTRAINT FK_UserClaims_UserId FOREIGN KEY (UserId) REFERENCES dbo.Users (UserId) 
	ON DELETE CASCADE
GO

-- Index
CREATE NONCLUSTERED INDEX IX_UserClaims_UserId ON dbo.UserClaims (UserId ASC);