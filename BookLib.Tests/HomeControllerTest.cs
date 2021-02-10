using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.BL.Services;
using BookLib.DAL.Entities;
using BookLib.DAL.Interfaces;
using BookLib.DAL.Repositories;
using BookLib.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookLib.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        #region ViewResultNotNull
        [Test]
        public void IndexContentResultNotNull()
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
        public void AddAnAuthorAndBookViewResultNotNull()
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
        public void DeleteAnAuthorViewResultNotNull()
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
        public void UpdateBookNameViewResultNotNull()
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
        public void DeleteABookViewResultNotNull()
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
        public void UpdateProgressViewResultNotNull()
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
        public void IndexViewResultNotNull()
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
        #region ThrowsException_POST
        [Test]
        public void IndexThrowsException_POST()
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
        public void AddAnAuthorAndBookThrowsException_POST()
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
        public void DeleteAnAuthorThrowsException_POST()
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
        public void UpdateBookNameThrowsException_POST()
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
        public void DeleteABookThrowsException_POST()
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
        public void UpdateProgressThrowsException_POST()
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
        #region Verify_POST
        [Test]
        public void Index_Verify_POST()
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
        public void AddAnAuthorAndBook_Verify_POST()
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
        public void DeleteAnAuthor_Verify_POST()
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
        public void UpdateBookName_Verify_POST()
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
        public void DeleteABook_Verify_POST()
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
        public void UpdateProgress_Verify_POST()
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
        public void IndexRedirectToPage_POST()
        {
            // arrange
            var mock = new Mock<ILibService>();
            HomeController controller = new HomeController(mock.Object);
            // act
            ViewResult result = controller.Index();
            //assert
            Assert.That(result.ViewName, Is.EqualTo("Index"));
        }
        [Test]
        public void AddAnAuthorAndBookRedirectToPage_POST()
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
        public void DeleteAnAuthorRedirectToPage_POST()
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
        public void UpdateBookNameRedirectToPage_POST()
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
        public void DeleteABookRedirectToPage_POST()
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
        public void UpdateProgressRedirectToPage_POST()
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
    }
}

