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
                    Name = "Александр Иванов"
                },
                new()
                {
                    Id = 2,
                    Name = "Екатерина Смирнова"
                },
                new()
                {
                    Id = 3,
                    Name = "Дмитрий Петров"
                },
                new()
                {
                    Id = 4,
                    Name = "Анна Сергеева"
                },
                new()
                {
                    Id = 5,
                    Name = "Сергей Козлов"
                }
            ]);
    }
}
