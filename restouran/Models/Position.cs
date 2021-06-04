using System;
using System.Collections.Generic;

#nullable disable

namespace restouran.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public long PositionId { get; set; }
        public string JobName { get; set; }
        public long Salary { get; set; }
        public string Responsibilities { get; set; }
        public string Requirements { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
