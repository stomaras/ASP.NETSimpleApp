using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class EmployeeAddress
    {
        public int EmployeeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        // naviagtion property
        // EmployeeAddress has required Employee
        public virtual Employee Employee { get; set; }
    }
}
