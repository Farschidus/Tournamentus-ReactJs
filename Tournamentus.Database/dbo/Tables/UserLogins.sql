CREATE TABLE dbo.UserLogin (
    LoginProvider NVARCHAR (128) NOT NULL,
    ProviderKey   NVARCHAR (128) NOT NULL,
    UserId        INT            NOT NULL
)
GO


-- Primary key
ALTER TABLE dbo.UserLogin
    ADD CONSTRAINT PK_UserLogins PRIMARY KEY CLUSTERED (LoginProvider ASC, ProviderKey ASC, UserId ASC)
GO

-- Foreign key
ALTER TABLE dbo.UserLogin
    ADD CONSTRAINT FK_UserLogins_UserId FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) ON DELETE CASCADE
GO

-- Idexes
CREATE NONCLUSTERED INDEX IX_UserLogin_UserId ON dbo.UserLogin (UserId ASC);