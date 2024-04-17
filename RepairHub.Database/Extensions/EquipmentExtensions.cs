using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairHub.Database.Entities;

namespace RepairHub.Database.Extensions
{
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
}
