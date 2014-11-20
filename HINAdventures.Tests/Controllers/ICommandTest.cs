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

            var newCommandTest = new Mock<ICommand>();



            // 3: newProduct.ExpectGet(p => p.Id).Returns(1);
            //4: newProduct.ExpectGet(p => p.Name).Returns("Bushmills");
        }
    }

}
