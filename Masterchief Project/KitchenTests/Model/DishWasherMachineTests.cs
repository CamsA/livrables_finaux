using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen;
using System.Collections.Generic;
using Kitchen.Model;

namespace KitchenTests
{
    [TestClass]
    public class DishWasherMachineTests
    {
        [TestMethod]
        public void TestIsRunning()
        {
            bool IsRunning = true;
            Assert.AreEqual(true, IsRunning);
        }

        [TestMethod]
        public void Test_Wash()
        {
            DishWasherMachine dishmachine = new DishWasherMachine();
            dishmachine.DirtyCrokeryStack = 10;
            
        }
    }
}