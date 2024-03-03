using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            modelBuilder.Entity<Application>().SeedData();
        }
    }
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
    internal static partial class WorkStatusExtensions
    {
        public static DataBuilder<WorkStatus> SeedData(this EntityTypeBuilder<WorkStatus> modelBuilder)
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
    internal static partial class EquipmentExtensions
    {
        public static DataBuilder<Equipment> SeedData(this EntityTypeBuilder<Equipment> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    Name = "Ok",
                    SerialNumber = "12312"
                },
                new()
                {
                    Id = 2,
                    Name = "Not ok",
                    SerialNumber = "1223122"
                }
            ]);
    }
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
    internal static partial class UserExtensions
    {
        public static DataBuilder<User> SeedData(this EntityTypeBuilder<User> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test",
                    MiddleName = "Test",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("Test"),
                    Login = "Test",
                    RoleId = 1
                },
                new()
                {
                    Id = 2,
                    FirstName = "Test",
                    LastName = "Test",
                    MiddleName = "Test",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("Test"),
                    Login = "Test",
                    RoleId = 2
                }
            ]);
    }
    internal static partial class RoleExtensions
    {
        public static DataBuilder<Role> SeedData(this EntityTypeBuilder<Role> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    Name = "Admin"
                },
                new()
                {
                    Id = 2,
                    Name = "Member"
                }
            ]);
    }
}
