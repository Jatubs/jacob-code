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
        private List<Order> history;
        private Location chosenlocation;
        private static List<Order> currentorders;
        bool haschosen;
        private string username;
        private string password;
        
        public Customer()
        {
            Name = "Balls Mahoney";
            Address = "1234 NoPizza Blvd";
            history = new List<Order>();
            currentorders = new List<Order>();
            haschosen = false;
            chosenlocation = new Location();
            chosenlocation.SetAddress("1235 NoPizza Blvd");
            username = "Default";
            password = "1234";

        }
        public Order suggestOrder()
        {
            if (history.Count > 0)
            {
                return history[0];
            }
            else
            {
                return null;
            }
        }
        public void SetUsername(string userval)
        {
            username = userval;
        }
        public string GetUsername()
        {
            return username;
        }
        public void SetPassword(string passval)
        {
            password = passval;
        }
        public string GetPassword()
        {
            return password;
        }
        public List<Order> getorders()
        {
            return currentorders;
        }
        public bool AddToOrder(Order addval)
        {
            if (currentorders.Count < 3)
            {
                currentorders.Add(addval);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RemoveOrder(Order addval)
        {
            currentorders.Remove(addval);
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
        public List<Order> GetHistory()
        {
            return history;
        }
        public void AddToHistory(Order pizzatoadd)
        {
            history.Add(pizzatoadd);
        }
        public void SetLocation(Location locval)
        {
            if (!haschosen || currentorders.Count == 0)
            {
                chosenlocation = locval;
                if (currentorders.Count > 0)
                {
                    haschosen = true;
                }
            }
            else if (currentorders[0].GetOrderHour() >= 21 && currentorders[0].GetOrderHour() <= 23)
            {
                if (DateTime.Now.Hour + 24 >= currentorders[0].GetOrderHour() + 2 && DateTime.Now.Minute >= currentorders[0].GetOrderMinutes())
                {
                    chosenlocation = locval;
                }
            }
            else if (DateTime.Now.Hour >= currentorders[0].GetOrderHour() + 2 && DateTime.Now.Minute >= currentorders[0].GetOrderMinutes())
            {
                chosenlocation = locval;
            }
        }
        public bool SetLocationTest(Location locval, int orderhour, int ordermin, int currenthour, int currentmin)
        {
            if (!haschosen)
            {
                chosenlocation = locval;
                haschosen = true;
                return true;
            }
            else if (orderhour >= 21 && orderhour <= 23)
            {
                if (currenthour + 24 >= orderhour + 2 && currentmin >= ordermin)
                {
                    chosenlocation = locval;
                    return true;
                }
            }
            else if (currenthour >= orderhour + 2 && currentmin >= ordermin)
            {
                chosenlocation = locval;
                return true;
            }
            return false;
        }
        public Location GetLocation()
        {
            return chosenlocation;
        }
    }
}
