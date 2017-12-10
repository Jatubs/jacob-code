using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Library
{
    public class Location
    {
        private List<Order> recordofsales;
        private SortedDictionary<Pizza, int> inventory;
        private string Address;

        public Location()
        {
            Address = "1234 Loadsapizza Avenue";
            recordofsales = new List<Order>();
            inventory = new SortedDictionary<Pizza, int>();
        }
        public List<Order> GetSales()
        {
            return recordofsales;
        }
        public SortedDictionary<Pizza,int> GetInventory()
        {
            return inventory;
        }
        public string GetAddress()
        {
            return Address;
        }
        public void SetAddress(string addval)
        {
            Address = addval;
        }
        public void AddSale(Order saleval)
        {
            recordofsales.Add(saleval);
        }
        public void AddInventory(Pizza typeofpizza, int quantity)
        {
            inventory.Add(typeofpizza, quantity);
        }
    }
}
