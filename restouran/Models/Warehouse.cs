using System;
using System.Collections.Generic;

#nullable disable

namespace restouran.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            MenuIngredientCode1Navigations = new HashSet<Menu>();
            MenuIngredientCode2Navigations = new HashSet<Menu>();
            MenuIngredientCode3Navigations = new HashSet<Menu>();
        }

        public long IngredientCode { get; set; }
        public string IngredientName { get; set; }
        public DateTime Data { get; set; }
        public string Volume { get; set; }
        public DateTime ShelfLife { get; set; }
        public long Cost { get; set; }
        public string Provider { get; set; }

        public virtual ICollection<Menu> MenuIngredientCode1Navigations { get; set; }
        public virtual ICollection<Menu> MenuIngredientCode2Navigations { get; set; }
        public virtual ICollection<Menu> MenuIngredientCode3Navigations { get; set; }
    }
}
