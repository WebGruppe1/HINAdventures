using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HINAdventures.classes;
using HINAdventures.Models;
using Moq;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestIntro()
        {
            //Arrange
            string expected = "Welcome to HINAdventures Dag!\nThis game will let you play in a simulation of Narvik University College\nTo see all available rooms from the room you are in type 'scout'\nTo move to another room type 'Enter roomnumber'\nYou can also chat to other people in the chat below.\nFor a full list of commands type 'Help'\nEnjoy the game!\n\nTest Description\nYou see 2 doors labeled 'D3001', 'D3002'.\n";
            Room enteredRoom = new Room { Id = 1, Name = "D3000", Description = "Test Description", ConnectedRooms = new List<Room>()};
            Room connectedRoom1 = new Room { Id = 2, Name = "D3001" };
            Room connectedRoom2 = new Room { Id = 3, Name = "D3002" };

            enteredRoom.ConnectedRooms.Add(connectedRoom1);
            enteredRoom.ConnectedRooms.Add(connectedRoom2);
            ApplicationUser user = new ApplicationUser { FirstName = "Dag", Room = enteredRoom };

            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(x => x.GetUser("userid")).Returns(user);
            var intro = new Intro(repository.Object);

            //Act
            string actual = intro.RunCommand("userid");

            //Assess
            Assert.AreEqual(expected, actual);
        }
    }
}
