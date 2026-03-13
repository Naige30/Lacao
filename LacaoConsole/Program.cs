using System.ComponentModel;
using System.Data.SqlTypes;
using StoreAppService;
using StoreModels;
namespace Lacao
{
 //GianLACAO
    internal class Program
    {
        static StoreService service = new StoreService();
         

        static void Main(string[] args)
        {
           service.PopulateDefaultStores();
            
            while (true)
            {
                Console.WriteLine("===STORE MENU===");
                Console.WriteLine("1. Add Store");
                Console.WriteLine("2. View Store");
                Console.WriteLine("3. Update Store");
                Console.WriteLine("4. Delete Store");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice:");

                int choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStore();
                        break;
                    case 2:
                        ViewStores();
                        break;
                    case 3:
                        UpdateStore();
                        break;
                    case 4:
                        DeleteStore();
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        return;
                        
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        

        static void AddStore()
        {
            Store store = new Store();
           Console.Write("Enter store name:");
            store.Name = Console.ReadLine();
            Console.Write("Enter store location:");
            store.Location = Console.ReadLine();
            Console.Write("Enter store profits: ");
            store.Profit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter store expenses: ");
            store.Expenses = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter store employees: ");
            store.Employees = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter store products: ");
            store.Products = Convert.ToInt16(Console.ReadLine());
            service.AddStore(store);
            Console.WriteLine("Store added successfully");


        }

        static void ViewStores()
        {
            var stores = service.ViewStores();
            if (stores.Count == 0)
            {
                Console.WriteLine("No stores found");
                return;
            }
            int i = 1;
            foreach (var store in stores)
            {
                Console.WriteLine($"Store {i++}:");
                Console.WriteLine($"Name: {store.Name}");
                Console.WriteLine($"Location: {store.Location}");
                Console.WriteLine($"Profit: {store.Profit}");
                Console.WriteLine($"Expenses: {store.Expenses}");
                Console.WriteLine($"Employees: {store.Employees}");
                Console.WriteLine($"Products: {store.Products}");
               
            }

        }
        static void UpdateStore()
        {
            Console.Write("Enter store name to update:");
            string name = Console.ReadLine();

            Store newStore = new Store();
            Console.Write("Enter new store Name:");
            newStore.Name = Console.ReadLine();
            Console.Write("Enter new store location:");
            newStore.Location = Console.ReadLine();
            Console.Write("Enter new store profits: ");
            newStore.Profit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter new store expenses: ");
            newStore.Expenses = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter new store employees: ");
            newStore.Employees = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter new store products: ");
            newStore.Products = Convert.ToInt16(Console.ReadLine());

            if (service.UpdateStore(name, newStore))
            {
                Console.WriteLine("Store Updated successfully");
            }
            else
            {
                Console.WriteLine("Store Does not Exist");
            }
        }
        static void DeleteStore()
        {
            Console.Write("Enter store name to delete:");
            string name = Console.ReadLine();
            if(service.DeleteStore(name))
                Console.WriteLine("Store Deleted successfully");
            else
                Console.WriteLine("Store Does not Exist");
        }
    }
}
