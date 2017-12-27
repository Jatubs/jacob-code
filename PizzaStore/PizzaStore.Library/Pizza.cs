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
            Small, Medium, Large
        }
        public enum Toppings
        {
            Cheese, Sausage, Pepperoni, Bacon, Chicken, Beef, GreenPeppers, BananaPeppers, Onions, Mushrooms, Olives
        }
        private int crusttype = 1;
        private int size = 2;
        private List<int> toppingslist;
        private int[] toppings2 = new int[5];
        public double price { get; set; }
        private int orderhour;
        private int orderminutes;
        public  string pizzaname { get; set; }
        private int numberof;
        public Pizza()
        {
            Enum.GetNames(typeof(Crusts)).ToString();
            crusttype = 1;
            size = 2;
            toppingslist = new List<int> { 0 };
            price = 9.99;
            orderhour = DateTime.Now.Hour;
            orderminutes = DateTime.Now.Minute;
            pizzaname = "Default";
        }
        public List<int> ParseToppings(string toppings)
        {
            List<int> stringval = new List<int>();
            string str = "This is a test";
            str = toppings.Replace(" ", String.Empty);
            str = str.Replace(",", String.Empty);
            for (int i = 0; i < str.Length; i++)
            {
                stringval.Add(Convert.ToInt32(str[i]));
            }

            return stringval;
        }
        public int ParseSize(string sizeval)
        {
            switch (sizeval)
            {
                case "Small":
                    return (int)Sizes.Small;
                case "Medium":
                    return (int)Sizes.Medium;
                case "Large":
                    return (int)Sizes.Large;

            }
            return (int)Sizes.Medium;
        }
        public int ParseCrust(string crustval)
        {
            if (crustval == "Thin")
            {
                return 0;
            }
            else if (crustval == "Pan")
            {
                return 1;
            }
            else if (crustval == "Stuffed")
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        public Pizza(int crust, int pizzasize, double priceval, string name, string toppings)
        {
            crusttype = crust;
            size = pizzasize;
            price = priceval;
            pizzaname = name;
            toppingslist = ParseToppings(toppings);
        }
        public Pizza(string name, string sizeval, string toppings, string crust, float priceval, string numberofval)
        {
            pizzaname = name;
            size = ParseSize(sizeval);
            toppingslist = ParseToppings(toppings);
            numberof = Convert.ToInt32(numberofval);
            price = (double)priceval;
            crusttype = ParseCrust(crust);
        }
        public int Getnumberof()
        {
            return numberof;
        }
        public void SetName(string type)
        {
            pizzaname = type;
        }

        public string GetName()
        {
            return pizzaname;
        }

        public List<string> GetListOfToppings()
        {
            List<string> returnval = new List<string> { "Cheese", "Sausage", "Pepperoni", "Bacon", "Chicken", "Beef", "GreenPeppers", "BananaPeppers", "Onions", "Mushrooms", "Olives" };
            string[] temp = Enum.GetNames(typeof(Toppings));
            
            for (int i = 0; i < temp.Length; i++)
            {
                returnval[i] = temp[i];
            }
            return returnval;
        }

        public List<string> GetListOfSizes()
        {
            List<string> returnval = new List<string> { "Personal", "Small", "Medium", "Large", "ExtraLarge" };
            string[] temp = Enum.GetNames(typeof(Sizes));

            for (int i = 0; i < temp.Length; i++)
            {
                returnval[i] = temp[i];
            }
            return returnval;
        }

        public List<string> GetListOfCrusts()
        {
            List<string> returnval = new List<string> { "Thin", "Pan", "Stuffed" };
            string[] temp = Enum.GetNames(typeof(Crusts));

            for (int i = 0; i < temp.Length; i++)
            {
                returnval[i] = temp[i];
            }
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

        public int GetOrderHour()
        {
            return orderhour;
        }
        public int GetOrderMinutes()
        {
            return orderminutes;
        }
    }
}
