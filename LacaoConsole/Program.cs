using System.ComponentModel;
using System.Data.SqlTypes;
using StoreAppService;
using StoreModels;
namespace Lacao
{
 //GianLACAO
 //Console UI Layer
    internal class Program
    {
        static StoreService service = new StoreService();
         

        static void Main(string[] args)
        {
          
            
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
                Console.WriteLine($"ID:{store.StoreId}");
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
            ViewStores();
            Console.Write("Enter Store ID: ");
            Guid id = Guid.Parse(Console.ReadLine());

            Store updated = new Store();
            updated.StoreId = id;

            Console.Write("New Name: ");
            updated.Name = Console.ReadLine();

            Console.Write("New Location: ");
            updated.Location = Console.ReadLine();

            Console.Write("New Profit: ");
            updated.Profit = Convert.ToDouble(Console.ReadLine());

            Console.Write("New Expenses: ");
            updated.Expenses = Convert.ToDouble(Console.ReadLine());

            Console.Write("New Employees: ");
            updated.Employees = Convert.ToInt32(Console.ReadLine());

            Console.Write("New Products: ");
            updated.Products = Convert.ToInt32(Console.ReadLine());

            if (service.UpdateStore(updated))
                Console.WriteLine("Updated!");
            else
                Console.WriteLine("Store not found!");
        }
        static void DeleteStore()
        {
            ViewStores();

            Console.Write("Enter Store ID: ");
            Guid id = Guid.Parse(Console.ReadLine());

            if (service.DeleteStore(id))
                Console.WriteLine("Deleted!");
            else
                Console.WriteLine("Store not found!");
        }
    }
}