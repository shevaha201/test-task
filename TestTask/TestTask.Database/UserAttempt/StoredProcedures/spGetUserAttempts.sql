CREATE PROCEDURE [dbo].[spGetUserAttempts]
    @UserId INT
AS
BEGIN
    SELECT
        [Id],
        [UserId],
        [DateTimeUtc],
        [EnteredSecretValue],
        [IsSuccess]
    FROM [dbo].[UserAttempt]
    WHERE [UserId] = @UserId
END