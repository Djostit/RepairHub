using RepairHub.Database.Entities.Base;
using System.ComponentModel;

namespace RepairHub.Domain.Dtos
{
    public class EquipmentDto : Entity
    {
        [DisplayName("Наименование")]
        public string Name { get; set; } = null!;
        [DisplayName("Серийный номер")]
        public string SerialNumber { get; set; } = null!;
    }
}
