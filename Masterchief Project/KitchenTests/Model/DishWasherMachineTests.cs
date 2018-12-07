using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kitchen.Model;

namespace KitchenTests.Model
{
    [TestClass]
    public class DishWasherMachineTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Reset the sole instance of ClassToBeTested
            new PrivateType(typeof(Kitchen.Model.Kitchen)).SetStaticField("instance", null);
        }

        [TestMethod]
        public void Test_Wash()
        {
            DishWasherMachine dishmachine = new DishWasherMachine();
            dishmachine.DirtyCrockeryStack = 10;
            dishmachine.Wash(10);
            Assert.AreEqual(0, dishmachine.DirtyCrockeryStack);
        }
        [TestMethod]
        public void Test_Wash2()
        {
            DishWasherMachine dishmachine = new DishWasherMachine();
            dishmachine.DirtyCrockeryStack = 10;
            dishmachine.Wash(10);
            Assert.AreEqual(10, Kitchen.Model.Kitchen.GetInstance.CleanCrokeryStack);
        }
    }
}