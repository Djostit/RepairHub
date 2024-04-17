using MapsterMapper;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Commands.EditEntity;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.EditEntity
{
    internal class EditUserCommandHandler(IEntityService<User> service, IMapper mapper) : EditEntityCommandHandler<UserDto, User>(service, mapper)
    {
    }

    internal class EditApplicationCommandHandler(IEntityService<Application> repository, IMapper mapper) : EditEntityCommandHandler<ApplicationDto, Application>(repository, mapper)
    {
    }

    internal class EditEmployeeCommandHandler(IEntityService<Employee> service, IMapper mapper) : EditEntityCommandHandler<EmployeeDto, Employee>(service, mapper)
    {
    }

    internal class EditEquipmentCommandHandler(IEntityService<Equipment> service, IMapper mapper) : EditEntityCommandHandler<EquipmentDto, Equipment>(service, mapper)
    {
    }

    internal class EditProblemCommandHandler(IEntityService<Problem> service, IMapper mapper) : EditEntityCommandHandler<ProblemDto, Problem>(service, mapper)
    {
    }

    internal class EditRoleCommandHandler(IEntityService<Role> service, IMapper mapper) : EditEntityCommandHandler<RoleDto, Role>(service, mapper)
    {
    }

    internal class EditStatusCommandHandler(IEntityService<Status> service, IMapper mapper) : EditEntityCommandHandler<StatusDto, Status>(service, mapper)
    {
    }

    internal class EditWorkStatusCommandHandler(IEntityService<WorkStatus> service, IMapper mapper) : EditEntityCommandHandler<WorkStatusDto, WorkStatus>(service, mapper)
    {
    }
}
