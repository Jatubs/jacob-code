using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Library
{
    public class Pizza
    {
        public enum Crusts
        {
            Thin, Pan, Stuffed
        }
        public enum Sizes
        {
            Personal, Small, Medium, Large, ExtraLarge
        }
        public enum Toppings
        {
            Cheese, Sausage, Pepperoni, Bacon, Chicken, Beef, GreenPeppers, BananaPeppers, Onions, Mushrooms, Olives
        }
        private int crusttype = 1;
        private int size = 2;
        private List<int> toppingslist;
        private double price;
        private string ordertime;

        public Pizza()
        {
            
            crusttype = 1;
            size = 2;
            toppingslist = new List<int> { 0 };
            price = 9.99;
            ordertime = DateTime.Now.ToString("h:mm:ss tt");
        }

        public Pizza(int crust, int pizzasize, double priceval, string ordertimeval)
        {
            crusttype = crust;
            size = pizzasize;
            price = priceval;
            ordertime = ordertimeval;
        }

        public List<string> GetListOfToppings()
        {
            List<string> returnval = new List<string> { "Cheese", "Sausage", "Pepperoni", "Bacon", "Chicken", "Beef", "GreenPeppers", "BananaPeppers", "Onions", "Mushrooms", "Olives" };

            return returnval;
        }

        public List<string> GetListOfSizes()
        {
            List<string> returnval = new List<string> { "Personal", "Small", "Medium", "Large", "ExtraLarge" };

            return returnval;
        }

        public List<string> GetListOfCrusts()
        {
            List<string> returnval = new List<string> { "Thin", "Pan", "Stuffed" };

            return returnval;
        }

        public void SetCrust(int type)
        {
            crusttype = type;
        }

        public int GetCrust()
        {
            return crusttype;
        }

        public void SetSize(int type)
        {
            size = type;
        }

        public int GetSize()
        {
            return size;
        }

        public void AddTopping(int type)
        {
            toppingslist.Add(type);
        }

        public List<int> GetToppings()
        {
            return toppingslist;
        }

        public void SetPrice(double type)
        {
            price = type;
        }

        public double GetPrice()
        {
            return price;
        }

        public void SetOrderTime(string type)
        {
            ordertime = type;
        }

        public string GetOrderTime()
        {
            return ordertime;
        }
    }
}
