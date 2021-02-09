SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_SelectBooks
AS
SELECT Authors.Name as AuthorsName, BookName,ReadingProgress.IsCompleted,ReadingProgress.FinishPage FROM Books
JOIN Authors ON Authors.ID=Books.AuthorsID
JOIN ReadingProgress ON ReadingProgress.BooksID=Books.ID
ORDER BY AuthorsName
GO
