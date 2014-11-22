using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using HINAdventures.Models;
using Moq;

namespace HINAdventures.Tests.Controllers
{
    [TestClass]
    public class RedirectionTest
    {
        /*
        [TestMethod]
        public async Task Register_RegisterValidUser_EnsureRedirectToIndexHome()
        {
            // Arrange
            var userManagerStub = new Mock<ApplicationUserManager(ApplicationUser, null)();
            var tcs = new TaskCompletionSource<IdentityResult>();
            tcs.SetResult(new IdentityResult(true));
            userManagerStub.Setup(s => s.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(tcs.Task);

            var signInManagerStub = new Mock<ISignInManager>();
            signInManagerStub.Setup(s => s.SignInAsync(It.IsAny<ApplicationUser>(), It.IsAny<bool>())).Returns(Task.FromResult(true));

            var sut = new AccountController(userManagerStub.Object) { SignInManager = signInManagerStub.Object };

            // Act
            var result = await sut.Register(new RegisterViewModel() { Password = "fakePw" }) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual<string>("Index", result.RouteValues["action"].ToString());
            Assert.AreEqual<string>("Home", result.RouteValues["controller"].ToString());
        } */
    }
}
