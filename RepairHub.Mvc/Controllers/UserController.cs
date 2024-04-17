using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Controllers.Base;

namespace RepairHub.Mvc.Controllers
{
    [Authorize(Roles = "1")]
    public class UserController : EntityController<UserDto, User>
    {
    }
}
