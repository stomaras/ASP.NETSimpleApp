using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    // Department has 1..many employees
    // Employee will have only one department
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        // Navigation Property
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
