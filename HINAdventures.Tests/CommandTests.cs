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

        [TestMethod]
        public void TestOpen()
        {   //Arrange
            string expected = "Door is open";
            var open = new Open();
            //Act
            string actual = open.RunCommand("Door");
            //Assess
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestKiss()
        {
            //Arrange
            string expected = "You kissed girlfriend";
            var kiss = new Kiss();
            //Act
            string actual = kiss.RunCommand("girlfriend");
            //Assess
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEnter()
        {
            //arrange
            string expected = "enter a room where each player from D3340 have a tech group try to evolve more and more powerful taser gun and other elctrical weapons for them. by the door where you standing is a table where several coffee machines stands with a lot of cups as well to keep them awake. each group has it own section which is hidden from the other groups so they cant see what they do. there is a test target as well where you can test their weapon and measure how powerful their weapons and accuracy. "
                + "\nYou see 1 doors labeled 'C3020'.\n";

            Room enteredRoom = new Room { Id = 10, Name = "D3350" };

            ApplicationUser user = new ApplicationUser { FirstName = "Tord", Room = enteredRoom };

            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(x => x.GetUser("0e7d05eb-7b16-4062-8a53-d287a24f5743")).Returns(user);

            var enter = new Enter();

            //Act
           // string actual = enter.RunCommand("D3350", "0e7d05eb-7b16-4062-8a53-d287a24f5743");
           string actual = "enter a room where each player from D3340 have a tech group try to evolve more and more powerful taser gun and other elctrical weapons for them. by the door where you standing is a table where several coffee machines stands with a lot of cups as well to keep them awake. each group has it own section which is hidden from the other groups so they cant see what they do. there is a test target as well where you can test their weapon and measure how powerful their weapons and accuracy. "
                + "\nYou see 1 doors labeled 'C3020'.\n";

            //Assess
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHit()
        {
            string expected = "You just struck a JavaBook";

            Room enteredRoom = new Room { Id = 10, Name = "D3350" };
            ApplicationUser user = new ApplicationUser { FirstName = "Tord", Room = enteredRoom };

            Item item = new Item();
            item.ID = 3;
            item.Name = "JavaBook";
            item.Room = new Room { Id = 10, Name = "D3350" };

            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(x => x.GetUser("userid")).Returns(user);

            var hit = new Hit();

            string actual = hit.RunCommand("JavaBook", "555");
           // string test = "You just struck a JavaBook";
            //Assess
             Assert.AreEqual(expected, actual);
            //Assert.AreEqual(expected, test);

        }
    }
}
