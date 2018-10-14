create table dbo.Roles (
    RoleId int identity (1, 1) not null,
    [Name] nvarchar (256) not null
)
go

-- primary key
alter table dbo.Roles 
    add constraint PK_Roles primary key clustered (RoleId asc)
go

-- indexes
create unique nonclustered index RoleNameIndex on dbo.Roles([Name] asc)
GO