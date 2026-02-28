namespace Lacao
{
    class Store
    {
        public string Name;
        public string Location;
        public double Profits;
        public double Expenses;
        public int Employees;
        public int Products;
    }
    internal class Program
    {

        static List<Store> stores = new List<Store>()
        {
            new Store{Name="Ligaya Store",Location="Muntinlupa City",Profits=500000,Expenses=200000,Employees=150,Products=1000},
            new Store{Name="Boni Store",Location="Mandaluyong City",Profits=300000,Expenses=100000,Employees=100,Products=500},
            new Store{Name="Ledezma Enterprise",Location="Pasig City",Profits=400000,Expenses=150000,Employees=120,Products=800}
        };


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
                Console.WriteLine("Enter your choice:");

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

        static void AddStore()
        {
            Store s = new Store();
            Console.WriteLine("Enter store name:");
            s.Name = Console.ReadLine();
            Console.WriteLine("Enter store location:");
            s.Location = Console.ReadLine();
            Console.WriteLine("Enter store profits: ");
            s.Profits = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter store expenses: ");
            s.Expenses = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter store employees: ");
            s.Employees = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter store products: ");
            s.Products = Convert.ToInt16(Console.ReadLine());
            stores.Add(s);
            Console.WriteLine("Store added successfully");


        }

        static void ViewStore()
        {
            Console.WriteLine("Enter store name to view:");
            string name = Console.ReadLine();
            foreach (var s in stores)
            {
                if (s.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nName: " + s.Name);
                    Console.WriteLine("Location: " + s.Location);
                    Console.WriteLine("Profits: " + s.Profits);
                    Console.WriteLine("Expenses: " + s.Expenses);
                    Console.WriteLine("Employees: " + s.Employees);
                    Console.WriteLine("Products: " + s.Products);
                    return;
                }
            }
            Console.WriteLine("Store not found or not Registered");

        }
        static void UpdateStore()
        {
            Console.WriteLine("Enter store name to update:");
            string name = Console.ReadLine();
            foreach (var s in stores)
            {
                if (s.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("New Location: ");
                    s.Location = Console.ReadLine();
                    Console.WriteLine("Updated Profit: ");
                    s.Profits = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Updated Expenses: ");
                    s.Expenses = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Number of Employees: ");
                    s.Employees = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Number of Products: ");
                    s.Products = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Store Details Updated Successfully");
                    return;

                }
            }
            Console.WriteLine("Store not Found");
        }
        static void DeleteStore()
        {
            Console.WriteLine("Enter store name to delete:");
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
