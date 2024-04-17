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
                    Name = "Проблема с загрузкой операционной системы"
                },
                new()
                {
                    Id = 2,
                    Name = "Проблема с батареей"
                },
                new()
                {
                    Id = 3,
                    Name = "Проблема с дисплеем"
                },
                new()
                {
                    Id = 4,
                    Name = "Проблема с клавиатурой"
                },
                new()
                {
                    Id = 5,
                    Name = "Проблема с зарядкой"
                }
            ]);
    }
}
