using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Код ингредиента")]
        public long IngredientCode { get; set; }
        [Display(Name = "Наименование ингредиента")]
        public string IngredientName { get; set; }
        [Display(Name = "Дата")]
        public DateTime Data { get; set; }
        [Display(Name = "Объём")]
        public string Volume { get; set; }
        [Display(Name = "Срок годности")]
        public DateTime ShelfLife { get; set; }
        [Display(Name = "Стоимость")]
        public long Cost { get; set; }
        [Display(Name = "Поставщик")]
        public string Provider { get; set; }
        [Display(Name = "Код ингрдиента 1")]
        public virtual ICollection<Menu> MenuIngredientCode1Navigations { get; set; }
        [Display(Name = "Код ингрдиента 2")]
        public virtual ICollection<Menu> MenuIngredientCode2Navigations { get; set; }
        [Display(Name = "Код ингрдиента 3")]
        public virtual ICollection<Menu> MenuIngredientCode3Navigations { get; set; }
    }
}
