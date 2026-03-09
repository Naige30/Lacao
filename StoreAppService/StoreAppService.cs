using System;
using System.Collections.Generic;
using System.Text;
using StoreModels;
using CRUDStoreDataService;

namespace StoreAppService
{
    public class StoreService
    {
        private StoreRepository repo = new StoreRepository();

        public void PopulateDefaultStores()
        {
            repo.AddStore(new Store { Name = "Ligaya Store", Location = "Makati City", Profit = 100000, Expenses = 50000, Employees = 150, Products = 500 });
            repo.AddStore(new Store { Name = "Amaranth Store", Location = "Muntinlupa City", Profit = 999999, Expenses = 42490, Employees = 89, Products = 300 });
            repo.AddStore(new Store { Name = "Rizen Store", Location = "San Pedro Laguna", Profit = 670000, Expenses = 300509, Employees = 67, Products = 900 });


        }
        public void AddStore(Store store)
        {
            repo.AddStore(store);
        }
        public List<Store> ViewStores()
        {
            return repo.GetAllStores();
        }
        public bool DeleteStore(string name)
        {
            return repo.DeleteStore(name);
        }
        public bool UpdateStore(string name, Store newStore)
        {
            Store current = repo.FindStore(name);
            if (current != null)
            {
                current.Name = newStore.Name;
                current.Location = newStore.Location;
                current.Profit = newStore.Profit;
                current.Expenses = newStore.Expenses;
                current.Employees = newStore.Employees;
                current.Products = newStore.Products;
                return true;
            }
            return false;
        }
    }


}