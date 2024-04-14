using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessBuisnessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using FitnessBuisnessLogic.Model;
using System.Linq;

namespace FitnessBuisnessLogic.Controller.Tests
{
    [TestClass()]
    public class EatingFoodControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingFoodController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            // Act
            eatingController.Add(food, 100);
            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}