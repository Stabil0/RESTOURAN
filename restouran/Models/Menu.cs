using System;
using System.Collections.Generic;

#nullable disable

namespace restouran.Models
{
    public partial class Menu
    {
        public long DishCode { get; set; }
        public string DishName { get; set; }
        public string Volume1 { get; set; }
        public string Volume2 { get; set; }
        public string Volume3 { get; set; }
        public long Cost { get; set; }
        public DateTime TimeForPreparing { get; set; }
        public long IngredientCode1 { get; set; }
        public long IngredientCode2 { get; set; }
        public long IngredientCode3 { get; set; }

        public virtual Warehouse IngredientCode1Navigation { get; set; }
        public virtual Warehouse IngredientCode2Navigation { get; set; }
        public virtual Warehouse IngredientCode3Navigation { get; set; }
    }
}
