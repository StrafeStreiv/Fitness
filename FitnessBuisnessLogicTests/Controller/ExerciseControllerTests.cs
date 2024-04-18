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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10, 50));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(2));
            // Assert
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}