using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessBuisnessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessBuisnessLogic.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);
            // Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arange
            var userName = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
            
        }
    }
}