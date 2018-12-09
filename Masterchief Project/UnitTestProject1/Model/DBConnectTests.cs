using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen;
using System.Data.SqlClient;
using System.Data;

namespace KitchenTests
{
    [TestClass]
    public class DBConnectTests
    {
        DBConnect Connectiontest = new DBConnect();

        [TestMethod]
        public void ConnectionSourceTest() => Assert.AreEqual("HENDHOLD", Connectiontest.datasrc);
    }
}
