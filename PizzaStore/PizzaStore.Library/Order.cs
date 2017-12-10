using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            pizzastoorder.Add(pizzatoadd);
            TotalPrice += pizzatoadd.GetPrice();
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
