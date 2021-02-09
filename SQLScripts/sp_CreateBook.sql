SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_CreateBook
    @BookName NVARCHAR(70),
    @AuthorName NVARCHAR(50)
AS
IF(SELECT Name FROM Authors WHERE Name=@AuthorName)=@AuthorName
BEGIN
    INSERT Books
    VALUES
((SELECT ID FROM Authors where Name=@AuthorName),@BookName)
END;
ELSE
BEGIN
INSERT Authors
VALUES
(@AuthorName);
INSERT Books
VALUES
    ((SELECT ID FROM Authors where Name=@AuthorName),@BookName)
END;
GO
