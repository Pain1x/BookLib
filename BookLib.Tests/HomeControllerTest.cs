using BookLib.BL.DTO;
using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.BL.Services;
using BookLib.DAL.Interfaces;
using BookLib.DAL.Repositories;
using BookLib.WebApp.Controllers;
using BookLib.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
namespace BookLib.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        #region ViewResultNotNull
        [Test]
        public void Index_ContentResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            HomeController controller = new HomeController(libServiceTest);
            //Act
            ContentResult result = controller.Index() as ContentResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void AddAnAuthorAndBook_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            HomeController controller = new HomeController(libServiceTest);
            //Act
            ViewResult result = controller.AddAnAuthorAndBook() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void DeleteAnAuthor_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            HomeController controller = new HomeController(libServiceTest);
            //Act
            ViewResult result = controller.DeleteAnAuthor() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void UpdateBookName_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            HomeController controller = new HomeController(libServiceTest);
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
            HomeController controller = new HomeController(libServiceTest);
            //Act
            ViewResult result = controller.DeleteABook() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void UpdateProgress_ViewResultNotNull()
        {
            //Arrange
            IUnitOfWork unitOfWorkTest = new UnitOfWork();
            ILibService libServiceTest = new LibService(unitOfWorkTest);
            HomeController controller = new HomeController(libServiceTest);
            //Act
            ViewResult result = controller.UpdateProgress() as ViewResult;
            //Assert
            Assert.IsNotNull(result);
        }
        [Test]
        public void Index_ViewResultNotNull()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.GetBooks());
            HomeController controller = new HomeController(mock.Object);
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(result.Model);
        }
        #endregion
        #region ThrowsException
        [Test]
        public void GetBooks_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.GetBooks()).Throws(new ValidationException("Test Exception", ""));
            HomeController controller = new HomeController(mock.Object);
            //Act
            ContentResult result = controller.Index() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.GetBooks(), Throws.Exception);
        }
        [Test]
        public void AddAnAuthorAndBook_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.AddAnAuthorAndBook(null, null)).Throws(new ValidationException("Test Exception", ""));
            HomeController controller = new HomeController(mock.Object);
            //Act
            ContentResult result = controller.AddAnAuthorAndBook() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.AddAnAuthorAndBook(null, null), Throws.Exception);
        }
        [Test]
        public void DeleteAnAuthor_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.DeleteAnAuthor(null)).Throws(new ValidationException("Test Exception", ""));
            HomeController controller = new HomeController(mock.Object);
            //Act
            ContentResult result = controller.DeleteAnAuthor() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.DeleteAnAuthor(null), Throws.Exception);
        }
        [Test]
        public void UpdateBookName_ThrowsException()
        {
            //Arrange
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.UpdateBookName(null, null)).Throws(new ValidationException("Test Exception", ""));
            HomeController controller = new HomeController(mock.Object);
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
            HomeController controller = new HomeController(mock.Object);
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
            HomeController controller = new HomeController(mock.Object);
            //Act
            ContentResult result = controller.UpdateProgress() as ContentResult;
            //Assert
            Assert.That(() => mock.Object.UpdateProgress(null, null), Throws.Exception);
        }
        #endregion
        #region VerifyInLibService
        [Test]
        public void GetBooks_VerifyInLibService()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToActionResult result = controller.Index() as RedirectToActionResult;
            // assert
            mock.Verify(a => a.GetBooks());
        }
        [Test]
        public void AddAnAuthorAndBook_VerifyInLibService()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToActionResult result = controller.AddAnAuthorAndBook("Новий", "Нова") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.AddAnAuthorAndBook("Новий", "Нова"));
        }
        [Test]
        public void DeleteAnAuthor_VerifyInLibService()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToActionResult result = controller.DeleteAnAuthor("Новий") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.DeleteAnAuthor("Новий"));
        }
        [Test]
        public void UpdateBookName_VerifyInLibService()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToActionResult result = controller.UpdateBookName("Нова","Новіша") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.UpdateBookName("Нова", "Новіша"));
        }
        [Test]
        public void DeleteABook_VerifyInLibService()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToActionResult result = controller.DeleteABook("Нова") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.DeleteABook("Нова"));
        }
        [Test]
        public void UpdateProgress_VerifyInLibService()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToActionResult result = controller.UpdateProgress("54","Нова") as RedirectToActionResult;
            // assert
            mock.Verify(a => a.UpdateProgress("54", "Нова"));
        }
        #endregion
        #region RedirectToPage_POST
        [Test]
        public void Index_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("Index");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("Index"));
        }
        [Test]
        public void AddAnAuthorAndBook_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("AddAnAuthorAndBook");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("AddAnAuthorAndBook"));
        }
        [Test]
        public void DeleteAnAuthor_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("DeleteAnAuthor");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("DeleteAnAuthor"));
        }
        [Test]
        public void UpdateBookName_RedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
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
            HomeController controller = new HomeController(mock.Object);
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
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("UpdateProgress");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("UpdateProgress"));
        }
        #endregion
        #region CreateAnObject
        [Test]
        public void HomeController_CreateAnObject()
        {
            // arrange
            string expected = "HomeController";
            var mock = new Mock<ILibService>();
            // act
            HomeController controller = new HomeController(mock.Object);
            //assert
            Assert.IsNotNull(controller);
            Assert.AreEqual(expected, controller.GetType().Name);
        }
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
            ValidationException ex = new ValidationException("Test Exception","");
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
        [Test]
        public void BookInfoViewModel_CreateAnObject()
        {
            // arrange
            string expected = "BookInfoViewModel";
            // act
            BookInfoViewModel book = new BookInfoViewModel();
            //assert
            Assert.IsNotNull(book);
            Assert.AreEqual(expected, book.GetType().Name);
        }
        #endregion
    }
}

