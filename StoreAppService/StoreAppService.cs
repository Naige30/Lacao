using CRUDStoreDataService;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace StoreAppService
{
    //GianLACAO
    //Business Logic Layer
    public class StoreService
    {
        private StoreJsonData repo = new StoreJsonData();

        public void AddStore(Store store)
        {
            repo.Add(store);
        }

        public List<Store> ViewStores()
        {
            return repo.GetStores();

        }

        public bool DeleteStore(Guid id)
        {
            return repo.Delete(id);
        }

        public bool UpdateStore(Store store)
        {
            var existing = repo.GetById(store.StoreId);

            if (existing!=null)
            {
                repo.Update(store);
                return true;
            }
            return false;
        }
    }
}   