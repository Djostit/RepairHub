using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
    internal static partial class ProblemExtensions
    {
        public static DataBuilder<Problem> SeedData(this EntityTypeBuilder<Problem> modelBuilder)
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
