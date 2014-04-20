using System;

namespace URLRouting.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public Nullable<decimal> UnitPrice { get; set; }
    }
}