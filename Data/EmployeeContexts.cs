using aim_sol.Models;
using Microsoft.EntityFrameworkCore;

namespace aim_sol.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }

       // public static IEnumerable<object> Department { get; internal set; }

        public DbSet<Employee> Employees { get; set; }
        // public DbSet<pkManager> pkManagers { get; set; }
        public DbSet<Department> Departments { get; set; }

    }




}
