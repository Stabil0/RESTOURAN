using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace restouran.Models
{
    public partial class Employee
    {
        [Display(Name = "Код сотрудника")]
        public long EmployeeCode { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Возраст")]
        public long Old { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Адресс")]
        public string Adress { get; set; }
        [Display(Name = "Телефон")]
        public long Phone { get; set; }
        [Display(Name = "Паспотные данные")]
        public string PassportData { get; set; }
        public long PositionId { get; set; }
        [Display(Name = "Код должности")]

        public virtual Position Position { get; set; }
    }
}
