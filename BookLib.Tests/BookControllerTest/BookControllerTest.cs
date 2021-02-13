using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.BL.Services;
using BookLib.DAL.Interfaces;
using BookLib.DAL.Repositories;
using BookLib.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BookLib.Tests.BookControllerTest
{
    [TestFixture]
    class BookControllerTest
    {
        #region ViewResultNotNull
        [Test]
        public void UpdateProgress_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            BookController controller = new BookController(libServiceTest);
            //Act
            ViewResult result = controller.UpdateProgress() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddAnAuthorAndBook_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            BookController controller = new BookController(libServiceTest);
            //Act
            ViewResult result = controller.AddAnAuthorAndBook() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateBookName_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            BookController controller = new BookController(libServiceTest);
            //Act
            ViewResult result = controller.UpdateBookName() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteABook_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            BookController controller = new BookController(libServiceTest);
            //Act
            ViewResult result = controller.DeleteABook() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        #endregion
        #region Throws_Exception
        [Test]
        public void AddAnAuthorAndBook_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.AddAnAuthorAndBook(null, null)).Throws(new ValidationException("Test Exception", ""));
            BookController controller = new BookController(mock.Object);
            //Act
            ContentResult result = controller.AddAnAuthorAndBook() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.AddAnAuthorAndBook(null, null), Throws.Exception);
        }

        [Test]
        public void UpdateBookName_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.UpdateBookName(null, null)).Throws(new ValidationException("Test Exception", ""));
            BookController controller = new BookController(mock.Object);
            //Act
            ContentResult result = controller.UpdateBookName() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.UpdateBookName(null, null), Throws.Exception);
        }

        [Test]
        public void DeleteABook_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.DeleteABook(null)).Throws(new ValidationException("Test Exception", "")); ;
            BookController controller = new BookController(mock.Object);
            //Act
            ContentResult result = controller.DeleteABook() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.DeleteABook(null), Throws.Exception);
        }

        [Test]
        public void UpdateProgress_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.UpdateProgress(null, null)).Throws(new ValidationException("Test Exception", ""));
            BookController controller = new BookController(mock.Object);
            //Act
            ContentResult result = controller.UpdateProgress() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.UpdateProgress(null, null), Throws.Exception);
        }
        #endregion
        #region VerifyOnce
        [Test]
        public void AddAnAuthorAndBook_VerifyOnce()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToActionResult result = controller.AddAnAuthorAndBook("Новий", "Нова") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.AddAnAuthorAndBook("Новий", "Нова"), Times.Once);
        }
        [Test]
        public void UpdateBookName_VerifyOnce()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToActionResult result = controller.UpdateBookName("Нова", "Новіша") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.UpdateBookName("Нова", "Новіша"), Times.Once);
        }
        [Test]
        public void DeleteABook_VerifyOnce()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToActionResult result = controller.DeleteABook("Нова") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.DeleteABook("Нова"), Times.Once);
        }
        [Test]
        public void UpdateProgress_VerifyOnce()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToActionResult result = controller.UpdateProgress("54", "Нова") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.UpdateProgress("54", "Нова"), Times.Once);
        }
        #endregion
        #region RedirectToPage_POST
        [Test]
        public void AddAnAuthorAndBook_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("AddAnAuthorAndBook");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("AddAnAuthorAndBook"));
        }
        [Test]
        public void UpdateBookName_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("UpdateBookName");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("UpdateBookName"));
        }
        [Test]
        public void DeleteABook_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("DeleteABook");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("DeleteABook"));
        }
        [Test]
        public void UpdateProgress_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            BookController controller = new BookController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("UpdateProgress");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("UpdateProgress"));
        }
        #endregion
        #region CreateAnObject
        [Test]
        public void BookController_CreateAnObject()
        {
            // arrange
            string expected = "BookController";
            var mock = new Mock<ILibService>();
            // act
            BookController controller = new BookController(mock.Object);
            //assert
            Assert.IsNotNull(controller);
            Assert.AreEqual(expected, controller.GetType().Name);
        }
        #endregion
    }
}
