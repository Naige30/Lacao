using Microsoft.Data.SqlClient;
using StoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUDStoreDataService
{
    public class StoreDBData : IStoreDataService
    {
        private string connectionString = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = StoreManagement; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public StoreDBData()
        {
            sqlConnection= new SqlConnection(connectionString);
            AddSeeds();
        }
        
        private void AddSeeds()
        {
            var existing = GetStores();
            if (existing.Count == 0)
            {
                Add(new Store { StoreId = Guid.NewGuid(), Name = "Ligaya Store", Location = "Makati City", Profit = 100000, Expenses = 50000, Employees = 150, Products = 500 });
                Add(new Store { StoreId = Guid.NewGuid(), Name = "Amaranth Store", Location = "Muntinlupa City", Profit = 999999, Expenses = 42490, Employees = 89, Products = 300 });
                Add(new Store { StoreId = Guid.NewGuid(), Name = "Rizen Store", Location = "San Pedro Laguna", Profit = 670000, Expenses = 300509, Employees = 67, Products = 900 });
            }
        }
        
        public void Add(Store store)
        {
            var insert = @"INSERT INTO Stores Values(@Id,@Name,@Location,@Profit,@Expenses,@Employees,@Products)";
            SqlCommand cmd=new SqlCommand(insert, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", store.StoreId);
            cmd.Parameters.AddWithValue("@Name", store.Name);
            cmd.Parameters.AddWithValue("@Location", store.Location);
            cmd.Parameters.AddWithValue("@Profit", store.Profit);
            cmd.Parameters.AddWithValue("@Expenses", store.Expenses);
            cmd.Parameters.AddWithValue("@Employees", store.Employees);
            cmd.Parameters.AddWithValue("@Products", store.Products);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Store> GetStores()
        {
            string query = "SELECT*FROM Stores";
            SqlCommand cmd= new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader=cmd.ExecuteReader();
            List<Store> stores = new List<Store>();

            while (reader.Read())
            {
                Store s =new Store {
                    StoreId = Guid.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Location = reader["Location"].ToString(),
                    Profit = Convert.ToDouble(reader["Profit"]),
                    Expenses = Convert.ToDouble(reader["Expenses"]),
                    Employees = Convert.ToInt16(reader["Employees"]),
                    Products = Convert.ToInt16(reader["Products"])
                };
            stores.Add(s);
            }
            sqlConnection.Close();
            return stores;
        }
        public Store? GetById(Guid id)
        {
            string query = "SELECT*FROM Stores WHERE StoreId=@Id";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Store store = null;
            while(reader.Read())
            {
                store = new Store
                {
                    StoreId = Guid.Parse(reader["StoreId"].ToString()),
                    Name = reader["Name"].ToString(),
                    Location = reader["Location"].ToString(),
                    Profit = Convert.ToDouble(reader["Profit"]),
                    Expenses = Convert.ToDouble(reader["Expenses"]),
                    Employees = Convert.ToInt16(reader["Employees"]),
                    Products = Convert.ToInt16(reader["Products"])
                };
            }
            sqlConnection.Close();
            return store;
        }

        public void Update(Store store)
        {
            string update= @"UPDATE Stores SET Name=@Name, Location=@Location, Profit=@Profit, Expenses=@Expenses, Employees=@Employees, Products=@Products WHERE StoreId=@Id";
       
        SqlCommand cmd = new SqlCommand(update, sqlConnection);
        cmd.Parameters.AddWithValue("@Id", store.StoreId);
        cmd.Parameters.AddWithValue("@Name", store.Name);
        cmd.Parameters.AddWithValue("@Location", store.Location);
        cmd.Parameters.AddWithValue("Profit", store.Profit);
        cmd.Parameters.AddWithValue("@Expenses", store.Expenses);   
        cmd.Parameters.AddWithValue("@Employees", store.Employees);
        cmd.Parameters.AddWithValue("@Products", store.Products);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();





        }

        public bool Delete(Guid id)
        {
            string delete= @"DELETE FROM Stores WHERE StoreId=@Id";

            SqlCommand cmd = new SqlCommand(delete, sqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            int rows=cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return rows > 0;
        }
    
    }
}
