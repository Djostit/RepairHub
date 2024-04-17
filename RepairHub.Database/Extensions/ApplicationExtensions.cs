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
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    Comment = null,
                    FirstName = "Test",
                    LastName = "Test",
                    MiddleName = "Test",
                    Cost = 2499.99f,
                    TimeWork = TimeSpan.FromDays(2)
                },
                new()
                {
                    Id = 2,
                    StatusId = 2,
                    ProblemId = 2,
                    EquipmentId = 2,
                    WorkStatusId = 2,
                    DateAddition = DateOnly.FromDateTime(DateTime.Now),
                    DateEnd = null,
                    Comment = null,
                    FirstName = "Test",
                    LastName = "Test",
                    MiddleName = "Test",
                    Cost = 2499.99f,
                    TimeWork = TimeSpan.FromDays(2)
                }
            ]);
    }
}
