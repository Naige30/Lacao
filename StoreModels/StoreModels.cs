using System;
using System.Collections.Generic;
using System.Text;

namespace StoreModels
{
    public class Store
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public double Profit { get; set; }
        public double Expenses{ get; set; }
        public int Employees { get; set; }
        public int Products { get; set; }
    }
}
