using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Library
{
    public class Customer
    {
        private string Name;
        private string Address;
        private List<Pizza> history;
        private Location chosenlocation;

        public Customer()
        {
            Name = "Balls Mahoney";
            Address = "1234 NoPizza Blvd";
            history = new List<Pizza>();
        }
        public void SetName(string nameval)
        {
            Name = nameval;
        }
        public string GetName()
        {
            return Name;
        }

        public void SetAddress(string addressval)
        {
            Address = addressval;
        }
        public string GetAddress()
        {
            return Address;
        }
        public List<Pizza> GetHistory()
        {
            return history;
        }
        public void AddToHistory(Pizza pizzatoadd)
        {
            history.Add(pizzatoadd);
        }
        public void SetLocation(Location locval)
        {
            chosenlocation = locval;
        }
        public Location GetLocation()
        {
            return chosenlocation;
        }
    }
}
