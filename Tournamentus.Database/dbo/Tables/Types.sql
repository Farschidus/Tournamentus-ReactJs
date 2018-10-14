CREATE TABLE [dbo].[Types](
	[TypeName] [nvarchar](16) NOT NULL
)
GO

-- Primary key
ALTER TABLE [dbo].[Types]
	ADD CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED ([TypeName] ASC)
GO


