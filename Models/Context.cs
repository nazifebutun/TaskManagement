using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Models
{
    public class Context : DbContext
    {
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BTPersonnel> BTPersonnels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NAZIFEBUTUN\\SQLEXPRESS; Database=TaskManagment; Integrated Security=True; TrustServerCertificate=True");
        }

    }
}
