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
        public void OrderWithin2Hours()
        {
            Pizza newpizza = new Pizza();
            Customer newcus = new Customer();
            Location newloc = new Location();
            newcus.SetLocationTest(newloc, 6, 0, 13, 0);
            List<string> test = newpizza.GetListOfToppings();

            Assert.IsTrue(newcus.SetLocationTest(newloc, 18, 30, 20, 30));
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
            Pepperoni.SetName("Pepperoni");
            newloc.AddInventory(Pepperoni.GetName(), 100);
            neworder.AddPizzatoOrder(Pepperoni);
            neworder.AddPizzatoOrder(Pepperoni);
            neworder.AddPizzatoOrder(Pepperoni);

            Assert.IsTrue(newloc.VerifySale(neworder));
            Pizza newpizza = new Pizza();
            newpizza.AddTopping(4);
            newpizza.SetName("Test");
            Order neworder2 = new Order();

            neworder2.AddPizzatoOrder(newpizza);

            Assert.IsFalse(newloc.VerifySale(neworder2));
        }
        [TestMethod]
        public void CanOnlyHaveOneLocation()
        {
            Customer newcustomer = new Customer();
            Location loc1 = new Location();
            Location loc2 = new Location();
            newcustomer.SetLocation(loc1);
            newcustomer.SetLocation(loc2);

            Assert.IsTrue(newcustomer.GetLocation() == loc2 && newcustomer.GetLocation() != loc1);
        }
        [TestMethod]
        public void HasAccount()
        {
            Customer newcustomer = new Customer();

            Assert.IsTrue(newcustomer.GetUsername() != "" && newcustomer.GetPassword() != "");
        }
        [TestMethod]
        public void CanSuggestOrder()
        {
            Customer newcustomer = new Customer();
            Order neworder = new Order();
            Pizza Pepperoni = new Pizza();
            Location newloc = new Location();

            Pepperoni.AddTopping(2);
            Pepperoni.AddTopping(0);
            Pepperoni.SetPrice(12.99);
            Pepperoni.SetCrust(0);
            Pepperoni.SetSize(1);
            Pepperoni.SetName("Pepperoni");
            neworder.AddPizzatoOrder(Pepperoni);
            newcustomer.AddToOrder(neworder);
            newloc.AddInventory("Pepperoni", 100);
            newloc.VerifySale(neworder, newcustomer);
            Assert.IsTrue(newcustomer.suggestOrder() != null);
        }
    }
}
