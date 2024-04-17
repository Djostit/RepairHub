using RepairHub.Database.Entities.Base;
using System.ComponentModel;

namespace RepairHub.Domain.Dtos
{
    public partial class ApplicationDto : Entity
    {
        [DisplayName("Статус")]
        public int StatusId { get; set; }
        [DisplayName("Проблема")]
        public int ProblemId { get; set; }
        [DisplayName("Оборудование")]
        public int EquipmentId { get; set; }
        [DisplayName("Статус работы")]
        public int WorkStatusId { get; set; }
        [DisplayName("Сотрудник")]
        public int EmployeeId { get; set; }
        [DisplayName("Дата добавления")]
        public DateOnly DateAddition { get; set; }
        [DisplayName("Дата окончания")]
        public DateOnly? DateEnd { get; set; }
        [DisplayName("Комментарий")]
        public string? Comment { get; set; } = null;
        [DisplayName("Имя")]
        public string FirstName { get; set; } = null!;
        [DisplayName("Фамилия")]
        public string LastName { get; set; } = null!;
        [DisplayName("Отчество")]
        public string MiddleName { get; set; } = null!;
        [DisplayName("Стоимость")]
        public float Cost { get; set; }
        [DisplayName("Время работы")]
        public TimeSpan TimeWork { get; set; }
    }
}
