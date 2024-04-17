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
                    Name = "Набор инструментов для ремонта ноутбуков",
                    SerialNumber = "TOOLKIT001"
                },
                new()
                {
                    Id = 2,
                    Name = "Паяльная станция Weller WLC100",
                    SerialNumber = "SOLDER001"
                },
                new()
                {
                    Id = 3,
                    Name = "Мультиметр Fluke 115",
                    SerialNumber = "MULTI001"
                },
                new()
                {
                    Id = 4,
                    Name = "Отвертка Phillips 2.0x100",
                    SerialNumber = "SCREWDRIVER001"
                },
                new()
                {
                    Id = 5,
                    Name = "Термоклейовка UHU 37205",
                    SerialNumber = "GLUEGUN001"
                }
            ]);
    }
}
