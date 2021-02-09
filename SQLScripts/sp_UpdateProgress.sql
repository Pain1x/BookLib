SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_UpdateProgress
    @FinishPage NVARCHAR(10),
    @BookName NVARCHAR(70)
AS 
IF @FinishPage != 'Finished'
BEGIN
    UPDATE ReadingProgress
    SET FinishPage = @FinishPage,IsCompleted = 'No'
    WHERE BooksID=(SELECT ID FROM Books WHERE BookName=@BookName)
END;
ELSE
BEGIN
    UPDATE ReadingProgress
    SET FinishPage = @FinishPage,IsCompleted = 'Yes'
    WHERE BooksID=(SELECT ID FROM Books WHERE BookName=@BookName)
END;
GO
