using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentAPI
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=Sindesmos")
        {

        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //ToTable => Configure table name
            modelBuilder.Entity<Department>().ToTable("Dept");
            modelBuilder.Entity<Department>().HasKey(d => d.DeptId);
            base.OnModelCreating(modelBuilder);


            // Property Configuration "Employee" entity
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeId).HasDatabaseGeneratedOption
                (DatabaseGeneratedOption.None);

            modelBuilder.Entity<Employee>().Property(e => e.EmpName).HasColumnName("Ename")
                                                                    .IsRequired()
                                                                    .HasMaxLength(50)
                                                                    .HasColumnType("varchar");
            modelBuilder.Entity<Employee>().Property(e => e.PrimaryContact).IsRequired()
                                                                         .HasMaxLength(10);
            // one to one relationship between Employee and EmployeeAddress
            modelBuilder.Entity<EmployeeAddress>().HasKey(ea => ea.EmployeeId);
            modelBuilder.Entity<Employee>().HasOptional(e => e.EmployeeAddress).WithRequired(a => a.Employee);

            // one to many relationship between Employee and Department
            modelBuilder.Entity<Department>().HasMany(d => d.Employee)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DeptId);

            // zero to many relationship between Employee and Team
            // with nullable foreign key
            // team has many employees 
            modelBuilder.Entity<Team>().HasMany(t => t.Employees)
                .WithOptional(e => e.Team)
                .HasForeignKey(e => e.TeamId);


            // many to many relationship 
            // many employees can have many projects
            // many projects can have many employees
            // Left Table means whichever you define first
            // Right Table means whichever you define later
            // HasMany WithMany
            modelBuilder.Entity<Employee>().HasMany(e => e.Projects)
                .WithMany(e => e.Employees)
                .Map(ep =>
                {
                    ep.MapLeftKey("EmployeeID");
                    ep.MapRightKey("ProjectID");
                    ep.ToTable("ProjectsOfEmployees");
                });

        }

        /*
         * PROPERTY CONFIGURATION
         * 
         * The EntityTypeConfiguration object, returns the property method
         * This method is used to configure the attributes of the selected entity.
         * The Configuration object has methods, which can be used to configure the Property as shown 
         * 
         * 
         */
    }
}
