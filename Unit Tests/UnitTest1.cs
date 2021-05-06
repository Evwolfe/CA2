using CA2_OrderSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
       
        [TestMethod]
        public void TestCalc()
        {
            Cart c2 = new Cart();
            Stock nws1 = new Stock() { ProdID = "UT01", Name = "Unit Test Item 1", Price = 15.01, Qty = 1 };
            Stock nws2 = new Stock() { ProdID = "UT02", Name = "Unit Test Item 2", Price = 3.35, Qty = 1 };
            c2.AddItem(nws1);
            c2.AddItem(nws2);

            double cal = (nws1.Price + nws2.Price);

            double retcal = c2.CalcTotal();

            Assert.AreEqual(cal, retcal);
        }
    }
}
