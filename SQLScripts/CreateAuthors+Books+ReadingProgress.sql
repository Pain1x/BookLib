CREATE TABLE Authors(
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL UNIQUE,
);
GO
CREATE TABLE Books(
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[AuthorsID] [int] NOT NULL REFERENCES Authors(ID) ON DELETE CASCADE,
	[BookName] [nvarchar](70) NOT NULL UNIQUE,
);
GO
CREATE TABLE ReadingProgress(
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[BooksID] [int] NOT NULL REFERENCES Books (ID) ON DELETE CASCADE,
	[IsCompleted] [nvarchar](3) NOT NULL DEFAULT ('Yes'),
	[FinishPage] [nvarchar](8) NULL DEFAULT ('Finished'),
);
GO
