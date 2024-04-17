using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Controllers.Base;

namespace RepairHub.Mvc.Controllers
{
    [Authorize]
    public class ApplicationController : EntityController<ApplicationDto,  Application>
    {
    }
}
