using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
    internal static partial class EmployeeExtensions
    {
        public static DataBuilder<Employee> SeedData(this EntityTypeBuilder<Employee> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    Name = "Bob"
                },
                new()
                {
                    Id = 2,
                    Name = "Tom"
                }
            ]);
    }
}
