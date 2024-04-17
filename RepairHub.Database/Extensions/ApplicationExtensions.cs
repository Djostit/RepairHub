using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
    internal static partial class ApplicationExtensions
    {
        public static DataBuilder<Application> SeedData(this EntityTypeBuilder<Application> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    StatusId = 1,
                    ProblemId = 1,
                    EquipmentId = 1,
                    WorkStatusId = 1,
                    EmployeeId = 1,
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    Cost = 2000f,
                    TimeWork = TimeSpan.FromDays(2)
                },
                new()
                {
                    Id = 2,
                    StatusId = 2,
                    ProblemId = 2,
                    EquipmentId = 2,
                    WorkStatusId = 2,
                    EmployeeId = 2,
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    FirstName = "Петр",
                    LastName = "Петров",
                    MiddleName = "Петрович",
                    Cost = 1800f,
                    TimeWork = TimeSpan.FromDays(2)
                },
                new()
                {
                    Id = 3,
                    StatusId = 1,
                    ProblemId = 3,
                    EquipmentId = 3,
                    WorkStatusId = 1,
                    EmployeeId = 3,
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    FirstName = "Сергей",
                    LastName = "Сергеев",
                    MiddleName = "Сергеевич",
                    Cost = 2200f,
                    TimeWork = TimeSpan.FromDays(2)
                },
                new()
                {
                    Id = 4,
                    StatusId = 2,
                    ProblemId = 4,
                    EquipmentId = 4,
                    WorkStatusId = 2,
                    EmployeeId = 4,
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    FirstName = "Алексей",
                    LastName = "Алексеев",
                    MiddleName = "Алексеевич",
                    Cost = 2400f,
                    TimeWork = TimeSpan.FromDays(2)
                },
                new()
                {
                    Id = 5,
                    StatusId = 1,
                    ProblemId = 5,
                    EquipmentId = 5,
                    WorkStatusId = 1,
                    EmployeeId = 5,
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    FirstName = "Елена",
                    LastName = "Еленова",
                    MiddleName = "Еленовна",
                    Cost = 2100f,
                    TimeWork = TimeSpan.FromDays(2)
                },
                new()
                {
                    Id = 6,
                    StatusId = 2,
                    ProblemId = 1,
                    EquipmentId = 2,
                    WorkStatusId = 2,
                    EmployeeId = 3,
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    FirstName = "Ольга",
                    LastName = "Олегова",
                    MiddleName = "Олеговна",
                    Cost = 1900f,
                    TimeWork = TimeSpan.FromDays(2)
                }
            ]);
    }
}
