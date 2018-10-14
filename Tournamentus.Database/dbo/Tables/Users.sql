CREATE TABLE dbo.Users (
    UserId               int identity (1, 1) not null,
	TimezoneId			 nvarchar (50) not null,
    Email                nvarchar (256) null,
    EmailConfirmed       bit            not null,
    PasswordHash         nvarchar (512) null,
    SecurityStamp        nvarchar (512) null,
    PhoneNumber          nvarchar (128) null,
    PhoneNumberConfirmed bit            not NULL,
    TwoFactorEnabled     bit            not NULL,
    LockoutEndDateUtc    datetime       null,
    LockoutEnabled       bit            not NULL default 0,
    AccessFailedCount    int            not NULL,
    UserName             nvarchar (256) not null,
    FirstName            nvarchar (256) null,
    LastName             nvarchar (256) null,
    DateCreated          datetime       not null,
    DateUpdated          datetime       not null,
    LastLoginDate        datetime       null,
    PasswordChangeDate   datetime       null
)
go


-- Primary key
alter table dbo.Users 
    add constraint PK_Users primary key clustered (UserId asc)
GO


-- Foreign key
ALTER TABLE dbo.Users
	ADD CONSTRAINT FK_Users_Timezones FOREIGN KEY(TimezoneId) REFERENCES dbo.Timezones (TimezoneId)
GO


-- Constraints
alter table dbo.Users
    add constraint UQ_Users_Email unique nonclustered (Email ASC)
go

alter table dbo.Users
    add constraint UQ_Users_UserName unique nonclustered (UserName ASC)
go


-- Indexes
create nonclustered index IX_Users_Email on dbo.Users (Email)
go

create nonclustered index IX_Users_UserName on dbo.Users (UserName)
go
