using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
    internal static partial class UserExtensions
    {
        public static DataBuilder<User> SeedData(this EntityTypeBuilder<User> modelBuilder)
            => modelBuilder.HasData(
            [
                new User()
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "Test",
                    MiddleName = "Test",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("Test"),
                    Login = "Test",
                    IdRole = 1
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Test",
                    LastName = "Test",
                    MiddleName = "Test",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("Test"),
                    Login = "Test",
                    IdRole = 2
                }
            ]);
    }
}
