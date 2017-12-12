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
        public void OrderWithin6Hours()
        {
            Pizza newpizza = new Pizza();
            Customer newcus = new Customer();
            Location newloc = new Location();
            newcus.SetLocationTest(newloc, 6, 0, 13, 0);
            List<string> test = newpizza.GetListOfToppings();
            
            Assert.IsTrue(newcus.SetLocationTest(newloc, 18, 30, 0, 30));
            int x = 0;
        }
        [TestMethod]
        public void OrderCanContainAtLeastOnePizza()
        {
            Order neworder = new Order();
            Pizza newpizza = new Pizza();
            neworder.AddPizzatoOrder(newpizza);

            Assert.IsTrue(neworder.GetPizzasInOrder().Count >= 1);
        }
        [TestMethod]
        public void OrderCanContainNoMoreThanTwelvePizza()
        {
            Order neworder = new Order();
            Pizza newpizza = new Pizza();
            for (int i = 1; i < 20; i++)
            {
                neworder.AddPizzatoOrder(newpizza);
            }

            Assert.IsTrue(neworder.GetPizzasInOrder().Count == 12);
        }
        [TestMethod]
        public void OrderCannotExceed500Dollars()
        {
            Order neworder = new Order();
            Pizza newpizza = new Pizza();
            newpizza.SetPrice(100.00);
            for (int i = 1; i < 20; i++)
            {

                neworder.AddPizzatoOrder(newpizza);
            }

            Assert.IsTrue(neworder.GetTotalPrice() <= 500.00);
        }
        [TestMethod]
        public void NoMoreThan3OrdersAtOnce()
        {
            Customer newcustomer = new Customer();
            Order temporder = new Order();
            newcustomer.AddToOrder(temporder);
            newcustomer.AddToOrder(temporder);
            newcustomer.AddToOrder(temporder);
            newcustomer.AddToOrder(temporder);

            Assert.IsTrue(newcustomer.getorders().Count <= 3);

        }
        [TestMethod]
        public void UserNeedsLocation()
        {
            Customer newcustomer = new Customer();
            Location newloc = new Location();

            newcustomer.SetLocation(newloc);

            Assert.IsTrue(newcustomer.GetLocation().ToString() != "");
            
        }
        [TestMethod]
        public void LocationNeedsInventory()
        {
            Location newloc = new Location();
            Pizza Pepperoni = new Pizza();
            Order neworder = new Order();


            Pepperoni.AddTopping(2);
            Pepperoni.AddTopping(0);
            Pepperoni.SetPrice(12.99);
            Pepperoni.SetCrust(0);
            Pepperoni.SetSize(1);

            newloc.AddInventory(Pepperoni, 100);
            neworder.AddPizzatoOrder(Pepperoni);
            neworder.AddPizzatoOrder(Pepperoni);
            neworder.AddPizzatoOrder(Pepperoni);

            Assert.IsTrue(newloc.VerifySale(neworder));
        }
    }
}
