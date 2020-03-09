CREATE PROCEDURE [dbo].[spGetUsers]
AS
BEGIN
    SELECT
        [Id],
        [Email],
        [FirstName],
        [LastName]
    FROM [dbo].[User]
END