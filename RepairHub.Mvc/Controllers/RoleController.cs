using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;

namespace RepairHub.Mvc.Controllers
{
    [Authorize(Roles = "1")]
    public class RoleController : Base.EntityController<RoleDto, Role>
    {
    }
}
