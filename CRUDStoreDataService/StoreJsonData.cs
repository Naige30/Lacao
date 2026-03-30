using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StoreModels;

namespace CRUDStoreDataService
{
    public class StoreJsonData : IStoreDataService
    {
        private List<Store> stores = new List<Store>();
        private string _jsonFileName;

    public StoreJsonData()
        {
            _jsonFileName= $"{AppDomain.CurrentDomain.BaseDirectory}stores.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
           RetrieveDataFromJsonFile();
            if (stores.Count <= 0)
            {
                stores.Add(new Store { StoreId = Guid.NewGuid(), Name = "Ligaya Store", Location = "Makati City", Profit = 100000, Expenses = 50000, Employees = 150, Products = 500 });
                stores.Add(new Store { StoreId = Guid.NewGuid(), Name = "Amaranth Store", Location = "Muntinlupa City", Profit = 999999, Expenses = 42490, Employees = 89, Products = 300 });
                stores.Add(new Store { StoreId = Guid.NewGuid(), Name = "Rizen Store", Location = "San Pedro Laguna", Profit = 670000, Expenses = 300509, Employees = 67, Products = 900 });

                SaveDataToJsonFile();
            }
        }
        private void SaveDataToJsonFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(stores, options);

            System.IO.File.WriteAllText(_jsonFileName, json);
        }
        private void RetrieveDataFromJsonFile()
        {
            if (!System.IO.File.Exists(_jsonFileName))
            {
                stores=new List<Store>();
                return;
            }
            using (var reader = System.IO.File.OpenText(_jsonFileName)) 
            {
                var content = reader.ReadToEnd();
                if(!string.IsNullOrWhiteSpace(content))
                {
                    stores= JsonSerializer.Deserialize<List<Store>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Store>();
                }
            }
        }

        public void Add(Store store)
        {
            stores.Add(store);
            SaveDataToJsonFile();
        }
        public List<Store> GetStores()
        {
            RetrieveDataFromJsonFile();
            return stores;

        }
        public Store? GetById(Guid id) {
            RetrieveDataFromJsonFile();
            return stores.FirstOrDefault(s => s.StoreId == id);
        }

        public void Update(Store store)
        {
            RetrieveDataFromJsonFile();
            var existing=stores.FirstOrDefault(s => s.StoreId == store.StoreId);

            if(existing != null)
            {
                existing.Name = store.Name;
                existing.Location = store.Location;
                existing.Profit = store.Profit;
                existing.Expenses = store.Expenses;
                existing.Employees = store.Employees;
                existing.Products = store.Products;
                
            }
            SaveDataToJsonFile();
        }
        public bool Delete(Guid id)
        {
            RetrieveDataFromJsonFile();
            var store=stores.FirstOrDefault(s => s.StoreId == id);

            if (store != null)
            {
                stores.Remove(store);
                SaveDataToJsonFile();
                return true;
            }
            return false;
        }
    }
}
