using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HINAdventures.classes;
using Moq;
using HINAdventures.Models;
using System.Collections.Generic;
/**
 * Unit Testing follow three simple steps:
 * 1: Arrange - Create objects and prepare everything needed to test functionality
 * 2: Act – Execute and get the output
 * 3: Assert – Compare final output with expected Output
 * 
 **/ 

namespace HINAdventures.Tests.Controllers
{
    [TestClass]
    public class IRepositoryTest
    {
        private Mock<IRepository> repos;

        [TestInitialize]
        public void setupindex()
        {
            repos = new Mock<IRepository>();
        }
        [TestMethod]
        public void TestIRepository()
        {
            List<String> fakeRooms = new List<String> {
               // new Room { Name = "Linux", ConnectedRooms = null, Description = "Do bist eine schl***e"},
               // new Room { Name = "Gang", ConnectedRooms = null, Description = "Test room"}};
            "linux",
            "test room" 
            };

           // var getGame = new Mock<IRepository>();
          

            //repos.Setup(x => x.getAvailableRooms("1")).Returns(fakeRooms);

            //Assert.AreEqual<string>("linux", "linux");


           // String result = fakeRooms.
             

            /*
             *  public List<String> getAvailableRooms(String userID)
        {            
            List<String> list = new List<String>();
            ApplicationUser user = db.Users.Where(u => u.Id == userID).FirstOrDefault();

            //user.Room.ConnectedRooms
            //var EnteredRoom = db.Rooms.Where(r => r.Name == argument).FirstOrDefault();
            

            foreach (Room room in user.Room.ConnectedRooms)
                list.Add(room.Name);
                //if (room == user.Room)
                   // list.Add(room.Name);     
            
            return list;
        }*/

                /*
          
          *  repos.Setup(x => x.GetAllBlogs()).Returns(fakeBlogs);
            var controller = new BlogController(repos.Object);

            var result = (ViewResult)controller.Index();

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Blog));
                 * 
                 * 
            Assert.IsNotNull(result, "ViewResult is null");
            var op = result.ViewData.Model as List<Blog>;
            Assert.AreEqual(2, op.Count, "Got wrong number of blogs");

                */

            // 3: newProduct.ExpectGet(p => p.Id).Returns(1);
   //4: newProduct.ExpectGet(p => p.Name).Returns("Bushmills");
        }
    }
}
