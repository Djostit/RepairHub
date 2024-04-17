using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;
using System.Net.Sockets;

namespace RepairHub.Database.Extensions
{
    internal static partial class RoleExtensions
    {
        public static DataBuilder<Role> SeedData(this EntityTypeBuilder<Role> modelBuilder)
            => modelBuilder.HasData(
            [
                new()
                {
                    Id = 1,
                    Name = "Администратор"
                },
                new() 
                {
                    Id = 2,
                    Name = "Пользователь"
                },
                new()
                {
                    Id = 3,
                    Name = "Менеджер"
                }
            ]);
    }
}
