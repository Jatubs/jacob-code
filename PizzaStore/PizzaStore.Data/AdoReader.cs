using PizzaStore.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Data
{
    public class AdoReader
    {
        string connectionstr = "Data Source=jacobsqlweek2.database.windows.net;Initial Catalog=PizzaStoreDB;User ID=sqladmin;Password=password123!";

        public List<Pizza> GetInventory()
        {
            string query = "SELECT * FROM PizzaStore.Inventory";

            List<Pizza> pizzas = new List<Pizza>();

            SqlCommand cmd = new SqlCommand(query);
            SqlDataReader dr;
            using (SqlConnection con = new SqlConnection(connectionstr))
            {
                con.Open();
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    //if (dr.Read())
                    //{
                    pizzas.Add(new Pizza(dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToInt32(dr[5]), dr[6].ToString()));
                    //}
                }
            }

            return pizzas;
        }
        public bool AddUser(String Username, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionstr))
            {
                string query = "INSERT INTO PizzaStore.UserAccount (Username, UserPassword) VALUES (@Name, @Pass)";

                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                SqlParameter param2 = new SqlParameter("@Pass", SqlDbType.VarChar, 50);

                param1.Value = Username;
                param2.Value = password;

                SqlCommand cmd = new SqlCommand(query);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                con.Open();
                cmd.Connection = con;
                cmd.Prepare();
                try
                {
                    if (VerifyUserAccount(Username, password) == false)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;

                    throw;

                }

                return true;
            }
        }
        public int GetLocationID(string LocName)
        {
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string query = "Select InventoryID from PizzaStore.Location where LocationName = @Name";
                int returnval = 0;

                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar, 50);

                param1.Value = LocName;
                SqlCommand cmd = new SqlCommand(query);

                cmd.Parameters.Add(param1);
                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();
                try
                {
                    returnval = (int)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;

                }

                return returnval;
            }
        }
        public int GetInventoryID(string productName)
        {
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string query = "Select InventoryID from PizzaStore.Inventory where PizzaName = @Name";
                int returnval = 0;

                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar, 50);

                param1.Value = productName;
                SqlCommand cmd = new SqlCommand(query);

                cmd.Parameters.Add(param1);
                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();

                try
                {
                    returnval = (int)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;

                }

                return returnval;
            }
        }
        public int GetCustomerID(string Username)
        {
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string query = "Select InventoryID from PizzaStore.UserAccount where Username = @Name";
                int returnval = 0;

                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar, 50);

                param1.Value = Username;
                SqlCommand cmd = new SqlCommand(query);

                cmd.Parameters.Add(param1);
                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();

                try
                {
                    returnval = (int)cmd.ExecuteScalar();
                }
                catch (Exception)
                {
                    throw;

                }

                return returnval;
            }
        }
        public bool AddSale(int LocationID, int InventoryID, int NumSold, float TotalPrice, int CustomerID)
        {
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string query = "INSERT INTO PizzaStore.LocationSales ([LocationID],[InventoryID],[NumSold],[TotalPrice] ,[CustomerID]) VALUES (@LocationID, @InventoryID, @NumSold, @TotalPrice, @CusID)";

                SqlParameter param2 = new SqlParameter("@LocationID", SqlDbType.Int, 50);
                SqlParameter param3 = new SqlParameter("@InventoryID", SqlDbType.Int, 50);
                SqlParameter param4 = new SqlParameter("@NumSold", SqlDbType.Int, 50);
                SqlParameter param5 = new SqlParameter("@TotalPrice", SqlDbType.Float, 50);
                SqlParameter param6 = new SqlParameter("@CusID", SqlDbType.Int, 50);

                param2.Value = LocationID;
                param3.Value = InventoryID;
                param4.Value = NumSold;
                param5.Value = TotalPrice;
                param6.Value = CustomerID;

                SqlCommand cmd = new SqlCommand(query);

                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);

                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;

                    throw;

                }

                return true;

            }
        }
        public List<Location> GetAllLocations()
        {
            string query = "SELECT * FROM PizzaStore.Location";

            List<Location> locations = new List<Location>();
            SqlCommand cmd = new SqlCommand(query);
            SqlDataReader dr;
            using (SqlConnection con = new SqlConnection(connectionstr))
            {
                con.Open();
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                foreach (var item in dr)
                {
                    locations.Add(new Location(dr[1].ToString(), dr[2].ToString()));
                }
            }

            return locations;
        }
        public bool VerifyUserAccount(string Username, string Password)
        {
            using (SqlConnection conn = new SqlConnection(connectionstr))
            {
                string query = "Select Username, UserPassword from PizzaStore.UserAccount where Username = @Name and UserPassword = @Pass";

                SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                SqlParameter param2 = new SqlParameter("@Pass", SqlDbType.VarChar, 50);


                param1.Value = Username;
                param2.Value = Password;

                SqlCommand cmd = new SqlCommand(query);

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                conn.Open();
                cmd.Connection = conn;
                cmd.Prepare();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                try
                {
                    foreach (var item in dr)
                    {
                        if (dr.GetValue(0).ToString() == Username && dr.GetValue(1).ToString() == Password)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }

                return false;
            }
        }
    }
}
