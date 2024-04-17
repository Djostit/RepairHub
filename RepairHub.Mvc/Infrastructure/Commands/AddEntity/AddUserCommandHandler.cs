using MapsterMapper;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Queries.GetEntityById;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.AddEntity
{
    internal class AddUserCommandHandler(IEntityService<User> service, IMapper mapper) : AddEntityCommandHandler<UserDto, User>(service, mapper)
    {
    }

    internal class AddApplicationByIdCommandHandler(IEntityService<Application> repository, IMapper mapper) : AddEntityCommandHandler<ApplicationDto, Application>(repository, mapper)
    {
    }

    internal class AddEmployeeCommandHandler(IEntityService<Employee> service, IMapper mapper) : AddEntityCommandHandler<EmployeeDto, Employee>(service, mapper)
    {
    }

    internal class AddEquipmentCommandHandler(IEntityService<Equipment> service, IMapper mapper) : AddEntityCommandHandler<EquipmentDto, Equipment>(service, mapper)
    {
    }

    internal class AddProblemCommandHandler(IEntityService<Problem> service, IMapper mapper) : AddEntityCommandHandler<ProblemDto, Problem>(service, mapper)
    {
    }

    internal class AddRoleCommandHandler(IEntityService<Role> service, IMapper mapper) : AddEntityCommandHandler<RoleDto, Role>(service, mapper)
    {
    }

    internal class AddStatusCommandHandler(IEntityService<Status> service, IMapper mapper) : AddEntityCommandHandler<StatusDto, Status>(service, mapper)
    {
    }

    internal class AddWorkStatusCommandHandler(IEntityService<WorkStatus> service, IMapper mapper) : AddEntityCommandHandler<WorkStatusDto, WorkStatus>(service, mapper)
    {
    }
}
