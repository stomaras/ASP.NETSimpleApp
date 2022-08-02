using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyDbContext db = new MyDbContext();
                Department d = new Department();
                d.DeptId = 1;
                d.DeptName = "Development";
                db.Departments.Add(d);
                db.SaveChanges();
                Console.WriteLine("DB created");
            }catch(Exception ex)
            {
                Console.WriteLine("Error" + ex.ToString());
            }
        }
    }
}
