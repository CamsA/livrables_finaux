using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen.Model;



namespace KitchenTests
{
    [TestClass]
    public class DBConnectTests
    {
        [TestMethod]
        public void ConstructTest()
        {
          db = new Kitchen.Model.DBConnect;
            Assert.AreEqual(0, 0);
        }
    }
}
