using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Extensions;

namespace RepairHub.Database.Context
{
    public partial class RepairHubContext(DbContextOptions<RepairHubContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
