using RepairHub.Database.Entities.Base;

namespace RepairHub.Domain.Dtos
{
    public class UserDto : Entity
    {
        public string Login { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
