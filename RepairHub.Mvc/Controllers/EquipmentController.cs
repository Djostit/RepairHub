﻿using Microsoft.AspNetCore.Authorization;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;

namespace RepairHub.Mvc.Controllers
{
    [Authorize(Roles = "1, 3")]
    public class EquipmentController : Base.EntityController<EquipmentDto, Equipment>
    {
    }
}
