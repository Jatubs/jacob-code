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
        private SortedDictionary<String, int> inventory;
        private string Address;
        private string Name;

        public Location()
        {
            Address = "1234 Loadsapizza Avenue";
            recordofsales = new List<Order>();
            inventory = new SortedDictionary<String, int>();
        }
        public List<Order> GetSales()
        {
            return recordofsales;
        }
        public SortedDictionary<String,int> GetInventory()
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
        public void AddSale(Order saleval, Customer customerval = null)
        {
            recordofsales.Add(saleval);
            if (customerval != null)
            {
                customerval.AddToHistory(saleval);
            }
        }
        public bool VerifySale(Order saleval, Customer customerval = null)
        {
            int pizzasaddedcounter = 0;
            for (int i = 0; i < saleval.GetPizzasInOrder().Count; i++)
            {
                if (inventory.ContainsKey(saleval.GetPizzasInOrder()[i].GetName()))
                {
                    if (inventory[saleval.GetPizzasInOrder()[i].GetName()] >= 1)
                    {
                        AddSale(saleval, customerval);
                        pizzasaddedcounter += 1;
                    }
                }
            }
            if (pizzasaddedcounter == saleval.GetPizzasInOrder().Count)
            {
                return true;
            }
            return false;
        }
        public void AddInventory(String pizzaname, int quantity)
        {
            inventory.Add(pizzaname, quantity);
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string nameval)
        {
            Name = nameval;
        }
    }
}
