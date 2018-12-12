using System;
using Kitchen.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KitchenTests.Model
{
    [TestClass]
    public class DishWasherEmployeeTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Reset the sole instance of ClassToBeTested
            new PrivateType(typeof(Kitchen.Model.Kitchen)).SetStaticField("instance", null);
            new PrivateType(typeof(ExchangeDesk)).SetStaticField("instance", null);
        }

        [TestMethod]
        public void Test_TakeAndDeposite_Crockery()
        {
            Kitchen.Model.Kitchen kitchen = Kitchen.Model.Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.WaitingDirtyCrockery = 10;
            DishWasherEmployee dishWasherEmployee = new DishWasherEmployee();
            dishWasherEmployee.TakeAndDeposite("Cockery", 10);

            Assert.AreEqual(0, exchangeDesk.WaitingDirtyCrockery);
        }

        [TestMethod]
        public void Test_TakeAndDeposite_Crockery2()
        {
            Kitchen.Model.Kitchen kitchen = Kitchen.Model.Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.WaitingDirtyCrockery = 10;
            DishWasherEmployee dishWasherEmployee = new DishWasherEmployee();
            dishWasherEmployee.TakeAndDeposite("Cockery", 10);

            Assert.AreEqual(10, kitchen.DishMachine.DirtyCrockeryStack);
        }

        [TestMethod]
        public void Test_TakeAndDeposite_TableCloth()
        {
            Kitchen.Model.Kitchen kitchen = Kitchen.Model.Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.WaitingDirtyTableClothes = 10;
            DishWasherEmployee dishWasherEmployee = new DishWasherEmployee();
            dishWasherEmployee.TakeAndDeposite("TableCloth", 10);

            Assert.AreEqual(0, exchangeDesk.WaitingDirtyTableClothes);
        }

        [TestMethod]
        public void Test_TakeAndDeposite_TableCloth2()
        {
            Kitchen.Model.Kitchen kitchen = Kitchen.Model.Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.WaitingDirtyTableClothes = 10;
            DishWasherEmployee dishWasherEmployee = new DishWasherEmployee();
            dishWasherEmployee.TakeAndDeposite("TableCloth", 10);

            Assert.AreEqual(10, kitchen.WashingMachine.DirtyTableClothesStacks);
        }

        [TestMethod]
        public void Test_TakeAndDeposite_Napkin()
        {
            Kitchen.Model.Kitchen kitchen = Kitchen.Model.Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.WaitingDirtyNapkins = 10;
            DishWasherEmployee dishWasherEmployee = new DishWasherEmployee();
            dishWasherEmployee.TakeAndDeposite("Napkin", 10);

            Assert.AreEqual(0, exchangeDesk.WaitingDirtyNapkins);
        }

        [TestMethod]
        public void Test_TakeAndDeposite_Napkin2()
        {
            Kitchen.Model.Kitchen kitchen = Kitchen.Model.Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            exchangeDesk.WaitingDirtyNapkins = 10;
            DishWasherEmployee dishWasherEmployee = new DishWasherEmployee();
            dishWasherEmployee.TakeAndDeposite("Napkin", 10);

            Assert.AreEqual(10, kitchen.WashingMachine.DirtyNapkinsStacks);
        }
    }
}
