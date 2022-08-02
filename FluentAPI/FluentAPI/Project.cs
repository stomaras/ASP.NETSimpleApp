using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjName { get; set; }
        public string ProjLanguage { get; set; }
        public string Database { get; set; }

        // navigation property
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
