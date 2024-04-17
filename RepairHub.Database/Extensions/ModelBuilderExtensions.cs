using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
    internal static partial class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().SeedData();
            modelBuilder.Entity<User>().SeedData();
            modelBuilder.Entity<Status>().SeedData();
            modelBuilder.Entity<Problem>().SeedData();
            modelBuilder.Entity<Equipment>().SeedData();
            modelBuilder.Entity<WorkStatus>().SeedData();
            modelBuilder.Entity<Employee>().SeedData();
            modelBuilder.Entity<Application>().SeedData();
        }
    }
}
