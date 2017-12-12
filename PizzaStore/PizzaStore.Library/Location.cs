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
        public bool VerifySale(Order saleval)
        {
            int pizzasaddedcounter = 0;
            for (int i = 0; i < saleval.GetPizzasInOrder().Count; i++)
            {
                if (inventory[saleval.GetPizzasInOrder()[i]] >= 1)
                {
                    AddSale(saleval);
                    pizzasaddedcounter += 1;
                }
            }
            if (pizzasaddedcounter == saleval.GetPizzasInOrder().Count)
            {
                return true;
            }
            return false;
        }
        public void AddInventory(Pizza typeofpizza, int quantity)
        {
            inventory.Add(typeofpizza, quantity);
        }
    }
}
