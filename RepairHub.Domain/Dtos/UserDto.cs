using RepairHub.Database.Entities.Base;
using System.ComponentModel;

namespace RepairHub.Domain.Dtos
{
    public class UserDto : Entity
    {
        [DisplayName("Роль пользователя")]
        public int RoleId { get; set; }
        [DisplayName("Логин")]
        public string Login { get; set; } = null!;
        [DisplayName("Хэш пароля")]
        public string HashPassword { get; set; } = null!;
        [DisplayName("Имя")]
        public string FirstName { get; set; } = null!;
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = null!;
        [DisplayName("Отчество")]
        public string MiddleName { get; set; } = null!;

    }
}
