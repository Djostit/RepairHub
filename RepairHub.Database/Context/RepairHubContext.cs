using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Entities;
using RepairHub.Database.Extensions;

namespace RepairHub.Database.Context
{
    public partial class RepairHubContext(DbContextOptions<RepairHubContext> options) : DbContext(options)
    {
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Problem> Problems { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<WorkStatus> WorkStatuses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
