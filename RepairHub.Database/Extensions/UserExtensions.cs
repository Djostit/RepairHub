using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
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
                    Login = "Testt",
                    RoleId = 2
                }
            ]);
    }
}
