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
        private int orderhour;
        private int orderminutes;

        public Order()
        {
            pizzastoorder = new List<Pizza>();
            TotalPrice = 0.0;
            orderhour = DateTime.Now.Hour;
            orderminutes = DateTime.Now.Minute;
        }

        public List<Pizza> GetPizzasInOrder()
        {
            return pizzastoorder;
        }
        public void AddPizzatoOrder(Pizza pizzatoadd)
        {
            if (pizzastoorder.Count < 12 && TotalPrice + pizzatoadd.GetPrice() <= 500.00)
            {
                pizzastoorder.Add(pizzatoadd);
                TotalPrice += pizzatoadd.GetPrice();
            }
            else
            {
                Debug.WriteLine("Error! Cannot order more than 12 pizzas, and price cannot exceed 500 US Dollars.");
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
