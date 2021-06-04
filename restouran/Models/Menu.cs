using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace restouran.Models
{
    public partial class Menu
    {
        [Display(Name = "Код блюда")]
        public long DishCode { get; set; }
        [Display(Name = "Наименование блюда")]
        public string DishName { get; set; }
        [Display(Name = "Объём ингредиента 1")]
        public string Volume1 { get; set; }
        [Display(Name = "Объём ингредиента 2")]
        public string Volume2 { get; set; }
        [Display(Name = "Объём ингредиента 3")]
        public string Volume3 { get; set; }
        [Display(Name = "Стоимось")]
        public long Cost { get; set; }
        [Display(Name = "Время приготовления")]
        public DateTime TimeForPreparing { get; set; }
        public long IngredientCode1 { get; set; }
       
        public long IngredientCode2 { get; set; }
        
        public long IngredientCode3 { get; set; }
        [Display(Name = "Код ингрдиента 1")]
        public virtual Warehouse IngredientCode1Navigation { get; set; }
        [Display(Name = "Код ингрдиента 2")]
        public virtual Warehouse IngredientCode2Navigation { get; set; }
        [Display(Name = "Код ингрдиента 3")]
        public virtual Warehouse IngredientCode3Navigation { get; set; }
    }
}
