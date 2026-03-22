using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModels;

namespace CRUDStoreDataService
{
    public interface IStoreDataService
    {
        void Add(Store store);
        List<Store> GetStores();
        Store? GetById(Guid id);
        void Update(Store store);
        bool Delete(Guid id);
    }
}
