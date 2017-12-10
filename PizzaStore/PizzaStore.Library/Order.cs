using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PizzaStore.Library
{
    public class Order
    {
        private List<Pizza> pizzastoorder;
        private double TotalPrice;

        public Order()
        {
            pizzastoorder = new List<Pizza>();
            TotalPrice = 0.0;
        }

        public List<Pizza> GetPizzasInOrder()
        {
            return pizzastoorder;
        }
        public void AddPizzatoOrder(Pizza pizzatoadd)
        {
            if (pizzastoorder.Count < 12 || TotalPrice + pizzatoadd.GetPrice() > 100.00)
            {
                pizzastoorder.Add(pizzatoadd);
                TotalPrice += pizzatoadd.GetPrice();
            }
            else
            {
                Debug.WriteLine("Error! Cannot order more than 12 pizzas, and price cannot exceed 100 US Dollars.");
            }
        }
        public void RemovePizzaFromOrder(Pizza pizzatoremove)
        {
            pizzastoorder.Remove(pizzatoremove);
            TotalPrice -= pizzatoremove.GetPrice();
        }
        public double GetTotalPrice()
        {
            return TotalPrice;
        }
        

    }
}
