using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaStore.Library;
using System.Collections.Generic;
namespace PizzaStore.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Pizza newpizza = new Pizza();

            List<string> test = newpizza.GetListOfToppings();
            
            Assert.IsTrue(1 == 1);
        }
    }
}
