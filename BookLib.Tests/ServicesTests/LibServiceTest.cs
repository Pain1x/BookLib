using BookLib.BL.DTO;
using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.BL.Services;
using BookLib.DAL.Repositories;
using BookLib.WebApp.Controllers;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace BookLib.Tests.ServicesTests
{
    [TestFixture]
    class LibServiceTest
    {
        #region CreateAnObject
        [Test]
        public void LibService_CreateAnObject()
        {
            // arrange
            string expected = "LibService";
            UnitOfWork unit = new UnitOfWork();
            // act
            LibService libService = new LibService(unit);
            //assert
            Assert.IsNotNull(libService);
            Assert.AreEqual(expected, libService.GetType().Name);
        }

        [Test]
        public void ValidationException_CreateAnObject()
        {
            // arrange
            string expected = "ValidationException";
            // act
            ValidationException ex = new ValidationException("Test Exception", "");
            //assert
            Assert.IsNotNull(ex);
            Assert.AreEqual(expected, ex.GetType().Name);
        }

        [Test]
        public void BookInfoDTO_CreateAnObject()
        {
            // arrange
            string expected = "BookInfoDTO";
            // act
            BookInfoDTO book = new BookInfoDTO();
            //assert
            Assert.IsNotNull(book);
            Assert.AreEqual(expected, book.GetType().Name);
        }
        #endregion
        #region Throws_Exception
        [Test]
        public void AddAnAuthorAndBook_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.AddAnAuthorAndBook(null, null, "")).Throws(new ValidationException("Test Exception", ""));
            
            //Act
             
            //Assert
            Assert.That(() => mock.Object.AddAnAuthorAndBook(null, null, ""), Throws.Exception);
        }

        [Test]
        public void GetBooks_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.GetBooks("")).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.GetBooks(""), Throws.Exception);
        }

        [Test]
        public void DeleteAnAuthor_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.DeleteAnAuthor(null, "")).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.DeleteAnAuthor(null, ""), Throws.Exception);
        }

        [Test]
        public void DeleteABook_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.DeleteABook(null, "")).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.DeleteABook(null, ""), Throws.Exception);
        }

        [Test]
        public void UpdateBookName_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.UpdateBookName(null, null, "")).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.UpdateBookName(null, null, ""), Throws.Exception);
        }

        [Test]
        public void UpdateProgress_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.UpdateProgress(null, null, "")).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.UpdateProgress(null, null, ""), Throws.Exception);
        }
        #endregion
        #region VerifyOnce
        [Test]
        public void GetBooks_VerifyOnce()
        {
            //Arrange
            var mock2 = new Mock<IConfiguration>();
            var mock = new Mock<ILibService>();
            mock.Setup(x => x.GetBooks(""));
            HomeController controller = new HomeController(mock.Object, mock2.Object);

            //Act
            controller.Index();

            //Assert
            mock.Verify(x => x.GetBooks(""), Times.Once);
        }

        [Test]
        public void AddAnAuthorAndBook_VerifyOnce()
        {
            //Arrange
            var mock2 = new Mock<IConfiguration>();
            string bookname = "Книга";
            string authorname = "Автор";
            var mock = new Mock<ILibService>();
            mock.Setup(x => x.AddAnAuthorAndBook(authorname, bookname, ""));
            BookController controller = new BookController(mock.Object, mock2.Object);

            //Act
            controller.AddAnAuthorAndBook(authorname, bookname);

            //Assert
            mock.Verify(x => x.AddAnAuthorAndBook(authorname, bookname, ""), Times.Once);
        }
        [Test]
        public void UpdateBookName_VerifyOnce()
        {
            //Arrange
            var mock2 = new Mock<IConfiguration>();
            string bookname = "Книга";
            string newbookname = "Нова";
            var mock = new Mock<ILibService>();
            mock.Setup(x => x.UpdateBookName(newbookname, bookname, ""));
            BookController controller = new BookController(mock.Object, mock2.Object);

            //Act
            controller.UpdateBookName(newbookname, bookname);

            //Assert
            mock.Verify(x => x.UpdateBookName(newbookname, bookname, ""), Times.Once);
        }
        [Test]
        public void DeleteABook_VerifyOnce()
        {
            //Arrange
            var mock2 = new Mock<IConfiguration>();
            string bookname = "Книга";
            var mock = new Mock<ILibService>();
            mock.Setup(x => x.DeleteABook(bookname, ""));
            BookController controller = new BookController(mock.Object, mock2.Object);

            //Act
            controller.DeleteABook(bookname);

            //Assert
            mock.Verify(x => x.DeleteABook(bookname, ""), Times.Once);
        }

        [Test]
        public void UpdateProgress_VerifyOnce()
        {
            //Arrange
            var mock2 = new Mock<IConfiguration>();
            string bookname = "Книга";
            string finishpage = "Нова";
            var mock = new Mock<ILibService>();
            mock.Setup(x => x.UpdateProgress(finishpage, bookname, ""));
            BookController controller = new BookController(mock.Object, mock2.Object);

            //Act
            controller.UpdateProgress(finishpage, bookname);

            //Assert
            mock.Verify(x => x.UpdateProgress(finishpage, bookname, ""), Times.Once);
        }

        [Test]
        public void DeleteAnAuthor_VerifyOnce()
        {
            //Arrange
            var mock2 = new Mock<IConfiguration>();
            string authorname = "Автор";
            var mock = new Mock<ILibService>();
            mock.Setup(x => x.DeleteAnAuthor(authorname, ""));
            AuthorController controller = new AuthorController(mock.Object, mock2.Object);

            //Act
            controller.DeleteAnAuthor(authorname);

            //Assert
            mock.Verify(x => x.DeleteAnAuthor(authorname, ""), Times.Once);
        }
        #endregion
    }
}
