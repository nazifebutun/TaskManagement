using Microsoft.EntityFrameworkCore;
using TaskManagement.Models.Authentication;

namespace TaskManagement.Models.Data
{
    public class Context : DbContext
    {
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BTPersonnel> BTPersonnels { get; set; }
        public DbSet<Register> Register { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NAZIFEBUTUN\\SQLEXPRESS; Database=TaskManagment; Integrated Security=True; TrustServerCertificate=True");
            optionsBuilder.EnableSensitiveDataLogging();
        }

    }
}
