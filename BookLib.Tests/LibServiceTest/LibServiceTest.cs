using BookLib.BL.DTO;
using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.BL.Services;
using BookLib.DAL.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookLib.Tests.LibServiceTest
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
        #region AreEqual
        [Test]
        public void AddAnAuthorAndBook_AreEqual()
        {
            // arrange
            var mock = new Mock<ILibService>();
            var name = "Автор";
            var bookname = "Книга";
            // act
            var result = mock.Object.AddAnAuthorAndBook(name, bookname);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void GetBooks_AreEqual()
        {
            // arrange
            var mock = new Mock<ILibService>();
            IEnumerable<BookInfoDTO> book = new List<BookInfoDTO>();

            // act
            var result = mock.Object.GetBooks();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, book);
        }

        [Test]
        public void DeleteABook_AreEqual()
        {
            // arrange
            var mock = new Mock<ILibService>();
            string book = "Нова";

            // act
            var result = mock.Object.DeleteABook(book);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void DeleteAnAuthor_AreEqual()
        {
            // arrange
            var mock = new Mock<ILibService>();
            string author = "Новий";

            // act
            var result = mock.Object.DeleteAnAuthor(author);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void UpdateProgress_AreEqual()
        {
            // arrange
            var mock = new Mock<ILibService>();
            string book = "Нова";
            string finishpage = "54";

            // act
            var result = mock.Object.UpdateProgress(finishpage, book);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void UpdateBookName_AreEqual()
        {
            // arrange
            var mock = new Mock<ILibService>();
            string book = "Нова";
            string newbookname = "Новіша";

            // act
            var result = mock.Object.UpdateBookName(book, newbookname);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, 0);
        }
        #endregion
        #region Throws_Exception
        [Test]
        public void AddAnAuthorAndBook_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.AddAnAuthorAndBook(null, null)).Throws(new ValidationException("Test Exception", ""));
            
            //Act
             
            //Assert
            Assert.That(() => mock.Object.AddAnAuthorAndBook(null, null), Throws.Exception);
        }

        [Test]
        public void GetBooks_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.GetBooks()).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.GetBooks(), Throws.Exception);
        }

        [Test]
        public void DeleteAnAuthor_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.DeleteAnAuthor(null)).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.DeleteAnAuthor(null), Throws.Exception);
        }

        [Test]
        public void DeleteABook_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.DeleteABook(null)).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.DeleteABook(null), Throws.Exception);
        }

        [Test]
        public void UpdateBookName_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.UpdateBookName(null, null)).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.UpdateBookName(null, null), Throws.Exception);
        }

        [Test]
        public void UpdateProgress_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.UpdateProgress(null, null)).Throws(new ValidationException("Test Exception", ""));

            //Act

            //Assert
            Assert.That(() => mock.Object.UpdateProgress(null, null), Throws.Exception);
        }
        #endregion
    }
}
