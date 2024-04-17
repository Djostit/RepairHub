using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
    internal static partial class StatusExtensions
    {
        public static DataBuilder<Status> SeedData(this EntityTypeBuilder<Status> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    Name = "Ok"
                },
                new()
                {
                    Id = 2,
                    Name = "Not ok"
                }
            ]);
    }
}
