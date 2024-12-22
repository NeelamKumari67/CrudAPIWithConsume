using Microsoft.EntityFrameworkCore;

namespace CrudAPI8.Model
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options) 
        {
                
        }
        public DbSet<Employee>  Employees { get; set; }
    }
}
