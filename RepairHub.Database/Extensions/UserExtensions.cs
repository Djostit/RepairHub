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
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("password"),
                    Login = "ivan",
                    RoleId = 1 // Администратор
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    MiddleName = "Петрович",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("password"),
                    Login = "petr",
                    RoleId = 2 // Обычный пользователь
                },
                new User()
                {
                    Id = 3,
                    FirstName = "Алексей",
                    LastName = "Алексеев",
                    MiddleName = "Алексеевич",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("password"),
                    Login = "alex",
                    RoleId = 2 // Обычный пользователь
                },
                new User()
                {
                    Id = 4,
                    FirstName = "Мария",
                    LastName = "Мариева",
                    MiddleName = "Мариевна",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("password"),
                    Login = "maria",
                    RoleId = 3 // Менеджер
                },
                new User()
                {
                    Id = 5,
                    FirstName = "Елена",
                    LastName = "Еленова",
                    MiddleName = "Еленовна",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("password"),
                    Login = "elena",
                    RoleId = 3 // Менеджер
                }
            ]);
    }
}
