using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen.Model;

namespace KitchenTests.Model
{
    [TestClass]
    public class ChefTests
    {
        [TestMethod]
        public void Test_GiveRecipe()
        {
            UnderTask underTask = new UnderTask
            {
                TimeNeeded = 2000
            };

            Tasks task = new Tasks();
            task.UnderTasksList.Add(underTask);

            Chef chef = new Chef
            {
                WaitingTask = task
            };

            chef.GiveRecipe();

            Assert.IsTrue(underTask.IsDone);


        }
    }
}
