using Microsoft.AspNetCore.Mvc;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Controllers.Base;

namespace RepairHub.Mvc.Controllers
{
    public class UserController : EntityController<UserDto, User>
    {
    }
}
