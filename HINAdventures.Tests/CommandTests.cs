using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HINAdventures.classes;
using HINAdventures.Models;

namespace HINAdventures.Tests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void TestHelp()
        {
            //Arrange
            var help = new Help();
            string expected = "List of available commands:";
            //Act
            String result = help.RunCommand();
            //Assess
            Assert.AreEqual(expected, result.Substring(0, 27));

        }
    }
}
