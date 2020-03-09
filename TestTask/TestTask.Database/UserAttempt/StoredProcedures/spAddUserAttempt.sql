CREATE PROCEDURE [dbo].[spAddUserAttempt]
    @UserId INT,
    @DateTimeUtc DATETIME2,
    @EnteredSecretValue INT,
    @IsSuccess BIT
AS
BEGIN
    INSERT INTO [dbo].[UserAttempt]
        ([UserId],  [DateTimeUtc],  [EnteredSecretValue],   [IsSuccess])
    VALUES
        (@UserId,   @DateTimeUtc,   @EnteredSecretValue,    @IsSuccess)
END