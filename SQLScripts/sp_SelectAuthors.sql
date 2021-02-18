CREATE PROCEDURE dbo.sp_SelectAuthors
AS
    SELECT Name FROM Authors
    ORDER BY Name
GO

EXECUTE dbo.sp_SelectAuthors 
GO