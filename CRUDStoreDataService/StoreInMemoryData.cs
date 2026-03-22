using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StoreModels;

namespace CRUDStoreDataService
{
    public class StoreInMemoryData : IStoreDataService
    {
        public List<Store> dummyStores = new List<Store>();
        public StoreInMemoryData()
        {
            dummyStores.Add(new Store
            {
                StoreId = Guid.NewGuid(),
                Name = "Ligaya Store",
                Location = "Makati City",
                Profit = 100000,
                Expenses = 50000,
                Employees = 150,
                Products = 500
            });

            dummyStores.Add(new Store
            {
                StoreId = Guid.NewGuid(),
                Name = "Amaranth Store",
                Location = "Muntinlupa City",
                Profit = 999999,
                Expenses = 42490,
                Employees = 89,
                Products = 300
            });

            dummyStores.Add(new Store
            {
                StoreId = Guid.NewGuid(),
                Name = "Rizen Store",
                Location = "San Pedro Laguna",
                Profit = 670000,
                Expenses = 300509,
                Employees = 67,
                Products = 900
            });
          

        }

        public void Add(Store store)
        {
            dummyStores.Add(store);
        }
        public List<Store> GetStores()
        {
            return dummyStores;

        }
        public Store? GetById(Guid id)
        {
            return dummyStores.FirstOrDefault(s => s.StoreId == id);

        }

        public void Update(Store store)
        {
            var existing = GetById(store.StoreId);
            if (existing != null)
            {
                existing.Name = store.Name;
                existing.Location = store.Location;
                existing.Profit = store.Profit;
                existing.Expenses = store.Expenses;
                existing.Employees = store.Employees;
                existing.Products = store.Products;
            }
        }

        public bool Delete(Guid id)
        {
            var store= GetById(id);
            if(store!= null)
            {
                dummyStores.Remove(store);
                return true;
            }
            return false;
        }
    }
}

