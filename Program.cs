using System.ComponentModel;
using System.Data.SqlTypes;

namespace Lacao
{
 
    internal class Program
    {
        static List<string> storeNames = new List<string>();
        static List<string> locations = new List<string>();
        static List<double> profits = new List<double>();
        static List<double> expenses = new List<double>();
        static List<int> products = new List<int>();
        static List<int> employees = new List<int>();

        static void Main(string[] args)
        {
            PopulateDefaultStores();
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
                        ViewStore();
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
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        static void PopulateDefaultStores()
        {
            storeNames.Add("Ligaya Store");
            storeNames.Add("Amaranth Store");
            storeNames.Add("Rizen Store");

            locations.Add("Makati City");
            locations.Add("Muntinlupa City");
            locations.Add("San Pedro Laguna");

            profits.Add(100000);
            profits.Add(999999);
            profits.Add(670000);

            expenses.Add(50000);
            expenses.Add(42490);
            expenses.Add(300509);

            employees.Add(150);
            employees.Add(89);
            employees.Add(67);

            products.Add(500);
            products.Add(300);
            products.Add(900);
        }

        static void AddStore()
        {
            
            Console.Write("Enter store name:");
            storeNames.Add(Console.ReadLine());
            Console.Write("Enter store location:");
            locations.Add(Console.ReadLine());
            Console.Write("Enter store profits: ");
            profits.Add(Convert.ToDouble(Console.ReadLine()));
            Console.Write("Enter store expenses: ");
            expenses.Add(Convert.ToDouble(Console.ReadLine()));
            Console.Write("Enter store employees: ");
            employees.Add(Convert.ToInt16(Console.ReadLine()));
            Console.Write("Enter store products: ");
            products.Add(Convert.ToInt16(Console.ReadLine()));
            Console.WriteLine("Store added successfully");


        }

        static void ViewStore()
        {
            if (storeNames.Count == 0)
            {
                Console.WriteLine("No Stores Registered");
                return;
            }
            Console.WriteLine("\n===STORE LIST===");
            for(int i=0;i<storeNames.Count; i++ )
            {
                Console.WriteLine($"\nSTORE #{i + 1}");
                Console.WriteLine("Name: " + storeNames[i]);
                Console.WriteLine("Location: " + locations[i]);
                Console.WriteLine("Profits: " + profits[i]);
                Console.WriteLine("Expenses: " + expenses[i]);
                Console.WriteLine("Employees: " + employees[i]);
                Console.WriteLine("Products: " + products[i]);
            }
            
        }
        static void UpdateStore()
        {
            Console.Write("Enter store name to update:");
            string name = Console.ReadLine();
            foreach (var s in stores)
            {
                if (s.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("New Location: ");
                    s.Location = Console.ReadLine();
                    Console.Write("Updated Profit: ");
                    s.Profits = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Updated Expenses: ");
                    s.Expenses = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Number of Employees: ");
                    s.Employees = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Number of Products: ");
                    s.Products = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Store Details Updated Successfully");
                    return;

                }
            }
            Console.WriteLine("Store not Found");
        }
        static void DeleteStore()
        {
            Console.Write("Enter store name to delete:");
            string Name = Console.ReadLine();

            for (int i = 0; i < stores.Count; i++)
            {
                if (stores[i].Name.Equals(Name, StringComparison.OrdinalIgnoreCase))
                {
                    stores.RemoveAt(i);
                    Console.WriteLine("Store Removed from database");
                    return;
                }
            }
            Console.WriteLine("Store Does not Exist");
        }
    }
}
