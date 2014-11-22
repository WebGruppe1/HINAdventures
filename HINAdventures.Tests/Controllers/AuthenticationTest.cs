using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HINAdventures.classes;
using HINAdventures.Controllers;
using Moq;
using System.Web.Mvc;
using HINAdventures.Models;
/**
 * AuthenticationTest.cs
 * 
 * The goal with this unit test is testing user authentication.
 * 
 * T.Fredriksen 21.11.14
 **/
namespace HINAdventures.Tests.Controllers
{
    [TestClass]
    public class AuthenticationTest
    {
        private Mock<IRepository> repos;
        public HomeController CreateControllerForUser(string userName)
        {
            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            var controller = new HomeController();
            controller.ControllerContext = mock.Object;
            return controller;
        }

        [TestInitialize]
        public void setupindex()
        {
            repos = new Mock<IRepository>();
        }
        [TestMethod]
        public void TestIndexMethod()
        {


            var controller = CreateControllerForUser("testuser@example.com");

            var result = controller.User as ViewResult;


            //  Assert.IsInstanceOfType(result.ViewData.Model, typeof(ApplicationUser));

        }
    }
}
