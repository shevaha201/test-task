CREATE PROCEDURE [dbo].[spGetSettings]
AS
BEGIN
    SELECT
        [Id],
        [Name],
        [IntValue]
    FROM [dbo].[Setting]
END