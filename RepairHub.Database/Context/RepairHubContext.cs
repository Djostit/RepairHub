using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Entities;
using RepairHub.Database.Extensions;

namespace RepairHub.Database.Context
{
    public partial class RepairHubContext(DbContextOptions<RepairHubContext> options) : DbContext(options)
    {
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
