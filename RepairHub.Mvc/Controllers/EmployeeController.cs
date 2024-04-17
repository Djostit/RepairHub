using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;

namespace RepairHub.Mvc.Controllers
{
    [Authorize(Roles = "1, 3")]
    public class EmployeeController : Base.EntityController<EmployeeDto, Employee>
    {
    }
}
