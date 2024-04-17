using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Context;
using RepairHub.Domain.Dtos;

namespace RepairHub.Mvc.Infrastructure.Extensions
{
    public class ScaffoldRepairHubContext(DbContextOptions<RepairHubContext> options) : RepairHubContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=127.0.0.1;Port=5432;database=repair;username=repair;password=123");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<UserDto>? UserDto { get; set; }
        public DbSet<ApplicationDto>? ApplicationDto { get; set; }
        public DbSet<RepairHub.Domain.Dtos.EquipmentDto> EquipmentDto { get; set; } = default!;
    }
}
