using Microsoft.EntityFrameworkCore;
using FinalKhushpreetKaur.Models;


namespace FinalKhushpreetKaur.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "HR" },
                new Department { DepartmentId = 2, DepartmentName = "IT" },
                new Department { DepartmentId = 3, DepartmentName = "Project Office" },
                new Department { DepartmentId = 4, DepartmentName = "Sales" }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, EmployeeName = "Rachel", JobTitle = "Software Developer", DepartmentID = 1 },
                new Employee { EmployeeID = 2, EmployeeName = "Ross", JobTitle = "HR Coordinator", DepartmentID = 1 },
                new Employee { EmployeeID = 3, EmployeeName = "Monica", JobTitle = "Network Technician", DepartmentID = 2 },
                new Employee { EmployeeID = 4, EmployeeName = "Chandler", JobTitle = "Project Manager", DepartmentID = 3 },
                new Employee { EmployeeID = 5, EmployeeName = "Phoebe", JobTitle = "Sales Manager", DepartmentID = 4 },
                new Employee { EmployeeID = 6, EmployeeName = "Joey", JobTitle = "Sales Associate", DepartmentID = 4 }
            );
        }
    }
}
