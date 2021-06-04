using System;
using System.Collections.Generic;

#nullable disable

namespace restouran.Models
{
    public partial class Employee
    {
        public long EmployeeCode { get; set; }
        public string FullName { get; set; }
        public long Old { get; set; }
        public string Gender { get; set; }
        public string Adress { get; set; }
        public long Phone { get; set; }
        public string PassportData { get; set; }
        public long PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
