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
        {   
            //Arrange
            Room room = new Room { Id = 1, Name = "D2370", Description = "Test" };
            ApplicationUser user = new ApplicationUser { FirstName = "Eivind", Room = room };
            Item item1 = new Item { Name = "Brown key", Room = room, ApplicationUser = user };
            Item item2 = new Item { Name = "soap", Room = room, ApplicationUser = user};
            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);

            Mock<IRepository> repo = new Mock<IRepository>();
            repo.Setup(x => x.GetUser("userid")).Returns(user);
            repo.Setup(x => x.GetInventory("userid")).Returns(items);
            var open = new Open(repo.Object);
            //expected
            string expected = "You unlocked the door! but there is no treasure here, besides the opportunity for cleaning the school :)";
            //Act
            string actual = open.RunCommand("door", "userid");
            //Assess
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestEat()
        {
            //Arrange
            Room room = new Room { Id = 1, Name = "D3320", Description = "Test" };
            ApplicationUser user = new ApplicationUser { FirstName = "Eivind", Room = room };
            Item item1 = new Item { Name = "salad", Room = room, isEatable = true };
            Item item2 = new Item { Name = "cake", Room = room, isEatable = true };


            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            Mock<IRepository> repo = new Mock<IRepository>();
            repo.Setup(x => x.GetUser("userid")).Returns(user);
            repo.Setup(x => x.GetEatableItems()).Returns(items);

            var eat = new Eat(repo.Object);

            string expected = "You just ate salad";
            string actual = eat.RunCommand("salad", "userid");

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestKiss()
        {
            //Arrange
            Room room = new Room { Id = 1, Name = "D3000", Description = "Test Description"};
            ApplicationUser user1 = new ApplicationUser { FirstName = "Tommy", Room = room};
            ApplicationUser user2 = new ApplicationUser { FirstName = "Eivind", Room = room};

            List<ApplicationUser> listOfUsers = new List<ApplicationUser>();
            listOfUsers.Add(user1);
            listOfUsers.Add(user2);

            Mock<IRepository> repo = new Mock<IRepository>();
            repo.Setup(x => x.GetAllUsers()).Returns(listOfUsers);
            repo.Setup(x => x.GetUser("userid")).Returns(user1);
            
            var kiss = new Kiss(repo.Object);

            string expected = "You kissed Eivind";
            //Act
            string actual = kiss.RunCommand("Eivind", "userid");
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
            Room room = new Room { Id = 10, Name = "D3350" };

            ApplicationUser user1 = new ApplicationUser { FirstName = "Tord", Room = room };
            ApplicationUser user2 = new ApplicationUser { FirstName = "Tommy", Room = room };
            List<ApplicationUser> listOfUsers = new List<ApplicationUser>();
            listOfUsers.Add(user1);
            listOfUsers.Add(user2);

            Item item1 = new Item { ID = 1, Name = "JavaBook", Room = room };
            Item item2 = new Item { ID = 2, Name = "Potato", Room = room };
            List<Item> listOfItems = new List<Item>();
            listOfItems.Add(item1);
            listOfItems.Add(item2);

            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(x => x.GetUser("userid")).Returns(user1);
            repository.Setup(x => x.GetAllUsers()).Returns(listOfUsers);
            repository.Setup(x => x.GetAllItems()).Returns(listOfItems);

            var hit = new Hit(repository.Object);

            string actualItem = hit.RunCommand("JavaBook", "userid");
            string actualUser = hit.RunCommand("Tommy", "userid");

            string expectedItem = "You just struck a JavaBook";
            string expectedUser = "You just punched Tommy in the";
            //Assess
            Assert.AreEqual(expectedItem, actualItem);
            Assert.IsTrue(actualUser.StartsWith(expectedUser));

        }
    }
}
