using System;
using System.Collections.Generic;

namespace DBPokeMon.Entities
{
    public partial class EmpDetails
    {
        public int EmpId { get; set; }
        public decimal Salary { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public virtual Employee1 Emp { get; set; }
    }
}
