using System;
using System.Collections.Generic;

#nullable disable

namespace restouran.Models
{
    public partial class Order
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string CustomersName { get; set; }
        public long Phone { get; set; }
        public long Cost { get; set; }
        public string Check { get; set; }
        public long CustomerId { get; set; }
        public long DishCode1 { get; set; }
        public long DishCode2 { get; set; }
        public long DishCode3 { get; set; }

        public virtual Employee Customer { get; set; }
        public virtual Menu DishCode1Navigation { get; set; }
        public virtual Menu DishCode2Navigation { get; set; }
        public virtual Menu DishCode3Navigation { get; set; }
    }

    internal class KeyAttribute : Attribute
    {
    }
}
