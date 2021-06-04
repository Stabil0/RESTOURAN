using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace restouran.Models
{
    public partial class Order
    {
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Display(Name = "Время")]
        public DateTime Time { get; set; }
        [Display(Name = "Имя покупателя")]
        public string CustomersName { get; set; }
        [Display(Name = "Телефон")]
        public long Phone { get; set; }
        [Display(Name = "Стоимость")]
        public long Cost { get; set; }
        [Display(Name = "Отметка о выполнении")]
        public string Check { get; set; }
        [Display(Name = "Код покупателя")]
        public long CustomerId { get; set; }
        [Display(Name = "Код блюда 1")]
        public long DishCode1 { get; set; }
        [Display(Name = "Код блюда 2")]
        public long DishCode2 { get; set; }
        [Display(Name = "Код блюда 3")]
        public long DishCode3 { get; set; }


        public virtual Employee Customer { get; set; }
        [Display(Name = "Код ингрдиента 1")]
        public virtual Menu DishCode1Navigation { get; set; }
        [Display(Name = "Код ингрдиента 2")]
        public virtual Menu DishCode2Navigation { get; set; }
        [Display(Name = "Код ингрдиента 3")]
        public virtual Menu DishCode3Navigation { get; set; }
    }
}
