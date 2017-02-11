namespace EmployeeManager.Web.Domain
{
    using Microsoft.EntityFrameworkCore;

    public class EmployeeDataContext : DbContext
    {

        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}