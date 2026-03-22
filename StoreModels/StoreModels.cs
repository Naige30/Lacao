using System;
using System.Collections.Generic;
using System.Text;

namespace StoreModels
{
    //GianLACAO
    //Models Layer
    public class Store
    {
        public Guid StoreId { get; set; }= Guid.NewGuid();
        public string Name { get; set; }
        public string Location { get; set; }
        public double Profit { get; set; }
        public double Expenses { get; set; }
        public int Employees { get; set; }
        public int Products { get; set; }
    }
}