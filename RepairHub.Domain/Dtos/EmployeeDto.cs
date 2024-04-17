﻿using RepairHub.Database.Entities.Base;
using System.ComponentModel;

namespace RepairHub.Domain.Dtos
{
    public class EmployeeDto : Entity
    {
        [DisplayName("Наименование")]
        public string Name { get; set; } = null!;
    }
}
