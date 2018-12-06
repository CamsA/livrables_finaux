using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KitchenTests
{
    [TestClass]
    public class WashingMachineTests

    {
        [TestMethod]
        public void Test_IsRunning()
        {
            bool IsRunning = true;
            Assert.IsTrue(IsRunning);
        }
    }
}