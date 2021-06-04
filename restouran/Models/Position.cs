using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace restouran.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }
        [Display(Name = "Код должности")]
        public long PositionId { get; set; }
        [Display(Name = "Наимонование должности")]
        public string JobName { get; set; }
        [Display(Name = "Оклад")]
        public long Salary { get; set; }
        [Display(Name = "Обязаности")]
        public string Responsibilities { get; set; }
        [Display(Name = "Требования")]
        public string Requirements { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
