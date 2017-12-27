using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public Location(string Nameval, string addval)
        {
            Name = Nameval;
            Address = addval;
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
        //public List<Pizza> FetchInventory(string query)
        //{
        //    string connectionstr = "Data Source=jacobsqlweek2.database.windows.net;Initial Catalog=JacobSqlWeek2;User ID=sqladmin;Password=password123!";


        //    List<Pizza> pizzas = new List<Pizza>();

        //    SqlCommand cmd = new SqlCommand(query);
        //    SqlDataReader dr;
        //    using (SqlConnection con = new SqlConnection(connectionstr))
        //    {
        //        con.Open();
        //        cmd.Connection = con;
        //        dr = cmd.ExecuteReader();
        //        foreach (var item in dr)
        //        {
        //            //if (dr.Read())
        //            //{
        //                pizzas.Add(new Pizza(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()));
        //            //}
        //        }
        //    }

        //    return pizzas;
        //}
    }
}
