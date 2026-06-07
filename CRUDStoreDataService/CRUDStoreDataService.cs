 using StoreModels;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace CRUDStoreDataService
{
    //GianLACAO
    //Data Logic Layer
    public class StoreRepository
    {
        IStoreDataService _dataService;
        public StoreRepository(IStoreDataService storeDataService)
        {
            _dataService = storeDataService;
        }
        private List<Store> stores = new List<Store>();
        public List<Store> GetAllStores()
        {
            return stores;
        }

        public void AddStore(Store store)
        {
            stores.Add(store);
        }
        public Store FindStore(string name)
        {
            return stores.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool DeleteStore(string name)
        {
            Store store = FindStore(name);
            if (store != null)
            {
                stores.Remove(store);
                return true;
            }
            return false;
        }
        public StoreModels.Store? GetById(Guid id)
        {
            return _dataService.GetById(id);
        }
      
    }
}