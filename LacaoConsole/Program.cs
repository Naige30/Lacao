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

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid choice! \nEnter choice: ");
                }

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
            double profit;
            while (!double.TryParse(Console.ReadLine(), out profit))
            {
                Console.Write("Invalid input! Enter a valid number for profit: ");
            }
            store.Profit = profit;
            Console.Write("Enter store expenses: ");
            double expenses;
            while (!double.TryParse(Console.ReadLine(), out expenses))
            {
                Console.Write("Invalid input! Enter a valid number for expenses: ");
            }
            store.Expenses = expenses;
            Console.Write("Enter store employees: ");
            int employees;
            while (!int.TryParse(Console.ReadLine(), out employees))
            {
                Console.Write("Invalid input! Enter a valid number for employees: ");
            }
            store.Employees = employees;
            Console.Write("Enter store products: ");
            int products;
            while (!int.TryParse(Console.ReadLine(), out products))
            {
                Console.Write("Invalid input! Enter a valid number for products: ");
            }
            store.Products = products;

            if (ConfirmAction("Do you want to add this store?"))
            {
                service.AddStore(store);
                Console.WriteLine("Store added successfully");
            }
            else
            {
                Console.WriteLine("Store addition cancelled");

            }
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
            
            Guid id;
            while (true)
            {
                Console.Write("Enter Store ID: ");
                string input = Console.ReadLine();

                if (Guid.TryParse(input, out id))
                    break;

                Console.WriteLine("Invalid ID format! Try again.");
            }

            Store updated = new Store();
            updated.StoreId = id;

            Console.Write("New Name: ");
            updated.Name = Console.ReadLine();

            Console.Write("New Location: ");
            updated.Location = Console.ReadLine();

            Console.Write("New Profit: ");
            double profit;
            while (!double.TryParse(Console.ReadLine(), out profit))
            {
                Console.Write("Invalid input! Enter valid profit: ");
            }
            updated.Profit = profit;

            Console.Write("New Expenses: ");
            double expenses;
            while (!double.TryParse(Console.ReadLine(), out expenses))
            {
                Console.Write("Invalid input! Enter valid expenses: ");
            }
            updated.Expenses = expenses;

            Console.Write("New Employees: ");
            int employees;
            while (!int.TryParse(Console.ReadLine(), out employees))
            {
                Console.Write("Invalid input! Enter valid employees: ");
            }
            updated.Employees = employees;

            Console.Write("New Products: ");
            int products;
            while (!int.TryParse(Console.ReadLine(), out products))
            {
                Console.Write("Invalid input! Enter valid products: ");
            }
            updated.Products = products;

            if (ConfirmAction("Do you want to update this store?"))
            {
                if (service.UpdateStore(updated))
                    Console.WriteLine("Updated!");
                else
                    Console.WriteLine("Store not found!");
            }
            else
            {
                    Console.WriteLine("Store update cancelled");
            }

        }
        static void DeleteStore()
        {
            ViewStores();

           
            Guid id;
            while (true)
            {
                Console.Write("Enter Store ID: ");
                string input = Console.ReadLine();

                if (Guid.TryParse(input, out id))
                    break;

                Console.WriteLine("Invalid ID format! Try again.");
            }



            if (ConfirmAction("Do you want to delete this store?"))
            {
                if (service.DeleteStore(id))
                    Console.WriteLine("Deleted!");
                else
                    Console.WriteLine("Store not found!");
            }
            else
            {
                    Console.WriteLine("Store deletion cancelled");

            }
        }

        static bool ConfirmAction(string message) 
        {
            Console.Write($"{message}(y/n): ");
            string input= Console.ReadLine().ToLower();

            return input == "y" || input == "yes";

        }

    }
}