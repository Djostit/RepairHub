using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
    internal static partial class WorkStatusExtensions
    {
        public static DataBuilder<WorkStatus> SeedData(this EntityTypeBuilder<WorkStatus> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    Name = "Выполнено"
                },
                new()
                {
                    Id = 2,
                    Name = "Не выполнено"
                },
                new()
                {
                    Id = 3,
                    Name = "В процессе"
                },
                new()
                {
                    Id = 4,
                    Name = "На утверждении"
                }
            ]);
    }
}
