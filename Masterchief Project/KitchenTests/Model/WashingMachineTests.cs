using Kitchen.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KitchenTests.Model
{
    [TestClass]
    public class WashingMachineTests

    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Reset the sole instance of ClassToBeTested
          //  new PrivateType(typeof(Kitchen.Model.Kitchen)).SetStaticField("instance", null);
        }

        [TestMethod]
        public void Test_Wash()
        {
            WashingMachine washingMachine = new WashingMachine
            {
                DirtyNapkinStacks = 10,
                DirtyTableClothStacks = 10
            };
            washingMachine.Wash(10, 10);
            Assert.AreEqual(0, washingMachine.DirtyNapkinStacks);
            Assert.AreEqual(0, washingMachine.DirtyTableClothStacks);
        }
    }
}