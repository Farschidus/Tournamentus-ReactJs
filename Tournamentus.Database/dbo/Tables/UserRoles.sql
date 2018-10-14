create table dbo.UserRoles (
    UserId int not null,
    RoleId int not NULL
)
GO

-- Primary key
ALTER TABLE dbo.UserRoles 
    ADD CONSTRAINT PK_UserRoles PRIMARY KEY CLUSTERED (UserId ASC, RoleId ASC)
GO


-- Foreign key
ALTER TABLE dbo.UserRoles 
    ADD CONSTRAINT FK_Roles_UserId FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId) 
	ON DELETE CASCADE
GO

ALTER TABLE dbo.UserRoles 
    ADD CONSTRAINT FK_Roles_RoleId FOREIGN KEY (RoleId) REFERENCES dbo.Roles(RoleId) 
	ON DELETE CASCADE
GO


-- Indexes
CREATE NONCLUSTERED INDEX IX_UserRoles_UserId ON dbo.UserRoles(UserId ASC)
GO

CREATE NONCLUSTERED INDEX IX_UserRoles_RoleId ON dbo.UserRoles(RoleId ASC)
GO