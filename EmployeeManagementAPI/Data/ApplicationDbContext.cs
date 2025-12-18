using EmployeeManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Department>()
                        .HasOne(d => d.Manager)
                        .WithOne(m => m.Department)
                        .HasForeignKey<Manager>(m => m.DepartmentId);

            
            modelBuilder.Entity<Department>()
                        .HasMany(d => d.Employees)
                        .WithOne(e => e.Department)
                        .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Manager>()
                        .HasMany(m => m.Employees)
                        .WithOne(e => e.Manager)
                        .HasForeignKey(e => e.ManagerId);
        }
    }
}
