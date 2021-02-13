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

namespace BookLib.Tests.HomeControllerTest
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
        #endregion
        #region VerifyOnce
        [Test]
        public void GetBooks_VerifyOnce()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToActionResult result = controller.Index() as RedirectToActionResult;
            // assert
            mock.Verify(a => a.GetBooks(), Times.Once);
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

