using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace BookLib.Tests.ControllersTests
{
    [TestFixture]
    class AuthorControllerTest
    {
        #region ViewResultNotNull
        //[Test]
        //public void DeleteAnAuthor_ViewResultNotNull()
        //{
        //    //Arrange
        //    var mock2 = new Mock<IConfiguration>();
        //    var mock = new Mock<ILibService>();
        //    string authorname = "Автор";
        //    mock.Setup(a => a.DeleteAnAuthor(authorname,""));
        //    AuthorController controller = new AuthorController(mock.Object, mock2.Object);

        //    //Act
        //    ViewResult result = controller.DeleteAnAuthor("") as ViewResult;

        //    //Assert
        //    Assert.IsNotNull(result.Model);
        //}
        #endregion
        #region ThrowsException
        [Test]
        public void DeleteAnAuthor_ThrowsException()
        {
            //Arrange
            var mock2 = new Mock<IConfiguration>();
            var mock = new Mock<ILibService>();
            mock.Setup(a => a.DeleteAnAuthor(null, "")).Throws(new ValidationException("Test Exception", ""));
            AuthorController controller = new AuthorController(mock.Object,mock2.Object);
            //Act
            ContentResult result = controller.DeleteAnAuthor("") as ContentResult;
            //Assert
            Assert.That(() => mock.Object.DeleteAnAuthor(null, ""), Throws.Exception);
        }
        #endregion
        #region VerifyOnce
        //[Test]
        //public void DeleteAnAuthor_VerifyOnce()
        //{
        //    // arrange
        //    var mock2 = new Mock<IConfiguration>();
        //    var mock = new Mock<ILibService>();
        //    AuthorController controller = new AuthorController(mock.Object, mock2.Object);
        //    // act
        //    RedirectToActionResult result = controller.DeleteAnAuthor("Новий") as RedirectToActionResult;
        //    // assert
        //    mock.Verify(a => a.DeleteAnAuthor("Новий", ""),Times.Once);
        //}
        #endregion
        #region RedirectToPage_POST
        [Test]
        public void DeleteAnAuthor_RedirectToPage_POST()
        {
            // arrange
            var mock2 = new Mock<IConfiguration>();
            var mock = new Mock<ILibService>();
            AuthorController controller = new AuthorController(mock.Object, mock2.Object);
            // act
            RedirectToPageResult result = controller.RedirectToPage("DeleteAnAuthor");
            //assert
            Assert.IsNotNull(result);
            Assert.That(result.PageName, Is.EqualTo("DeleteAnAuthor"));
        }
        #endregion
        #region CreateAnObject
        [Test]
        public void AuthorController_CreateAnObject()
        {
            // arrange
            var mock2 = new Mock<IConfiguration>();
            string expected = "AuthorController";
            var mock = new Mock<ILibService>();
            // act
            AuthorController controller = new AuthorController(mock.Object,mock2.Object);
            //assert
            Assert.IsNotNull(controller);
            Assert.AreEqual(expected, controller.GetType().Name);
        }
        #endregion
    }
}
