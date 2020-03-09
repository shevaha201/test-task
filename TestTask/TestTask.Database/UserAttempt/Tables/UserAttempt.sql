CREATE TABLE [dbo].[UserAttempt]
(
    [Id] INT NOT NULL IDENTITY (1, 1),
    [UserId] INT NOT NULL,
    [DateTimeUtc] DATETIME2 NOT NULL,
    [EnteredSecretValue] INT NOT NULL,
    [IsSuccess] BIT NOT NULL,
    CONSTRAINT [PK_UserAttempt] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserAttempt_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
)
