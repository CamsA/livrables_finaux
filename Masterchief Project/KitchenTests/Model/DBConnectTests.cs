using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen;

namespace KitchenTests
{
    [TestClass]
    public class DBConnectTests
    {
        DBConnect Connectiontest = null;

        [TestMethod]
        public void TestDBConnectdatasrc()
        {
            Connectiontest = new DBConnect("MasterChiefDB");
            Assert.AreEqual("HENDHOLD", Connectiontest.Datasrc);
        }

        [TestMethod]
        public void TestDBConnect_Try()
        {
            try
            {
                Connectiontest = new DBConnect("MasterChiefDB");
                Assert.IsTrue(true);
            }
            catch(Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestDBConnect_Catch()
        {
            try
            {
                Connectiontest = new DBConnect("LOL");
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
