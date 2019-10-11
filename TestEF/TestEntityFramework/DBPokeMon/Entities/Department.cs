using System;
using System.Collections.Generic;

namespace DBPokeMon.Entities
{
    public partial class Department
    {
        public Department()
        {
            Employee1 = new HashSet<Employee1>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee1> Employee1 { get; set; }
    }
}
