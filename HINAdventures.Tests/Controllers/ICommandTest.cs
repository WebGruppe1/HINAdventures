using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HINAdventures.classes;
using Moq;

namespace HINAdventures.Tests.Controllers
{
    [TestClass]
    public class ICommandTest
    {
        [TestMethod]
        public void TestICommand()
        {

            var enterCommandTest = new Mock<ICommand>();
            var helpCommandTest = new Mock<ICommand>();

            var drinkCommandTest = new Mock<ICommand>();

           // var result = drinkCommandTest.


         //   repos.Setup(x => x.GetAllBlogs()).Returns(fakeBlogs);
           // var controller = new BlogController(repos.Object);

            // 3: newProduct.ExpectGet(p => p.Id).Returns(1);
            //4: newProduct.ExpectGet(p => p.Name).Returns("Bushmills");
        }
    }

}
