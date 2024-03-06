using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data_Model
{
    public class EmployeeDbContextcs :DbContext
    {
        public EmployeeDbContextcs(DbContextOptions<EmployeeDbContextcs> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { set; get; }

    }
}
