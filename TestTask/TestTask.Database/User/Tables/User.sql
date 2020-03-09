CREATE TABLE [dbo].[User]
(
    [Id] INT NOT NULL IDENTITY (1, 1),
    [Email] NVARCHAR(64) NOT NULL,
    [FirstName] NVARCHAR(32),
    [LastName] NVARCHAR(32),
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
)

GO

CREATE NONCLUSTERED INDEX [IX_User_Email] ON [dbo].[User] ([Email])