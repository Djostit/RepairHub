using MapsterMapper;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Commands.DeleteEntity;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.DeleteEntity
{
    internal class DeleteUserByIdCommandHandler(IEntityService<User> service) : DeleteEntityByIdCommandHandler<User>(service)
    {
    }
    internal class DeleteApplicationByIdCommandHandler(IEntityService<Application> repository) : DeleteEntityByIdCommandHandler<Application>(repository)
    {
    }

    internal class DeleteEmployeeByIdCommandHandler(IEntityService<Employee> service) : DeleteEntityByIdCommandHandler<Employee>(service)
    {
    }

    internal class DeleteEquipmentByIdCommandHandler(IEntityService<Equipment> service) : DeleteEntityByIdCommandHandler<Equipment>(service)
    {
    }

    internal class DeleteProblemByIdCommandHandler(IEntityService<Problem> service) : DeleteEntityByIdCommandHandler<Problem>(service)
    {
    }

    internal class DeleteRoleByIdCommandHandler(IEntityService<Role> service) : DeleteEntityByIdCommandHandler<Role>(service)
    {
    }

    internal class DeleteStatusByIdCommandHandler(IEntityService<Status> service) : DeleteEntityByIdCommandHandler<Status>(service)
    {
    }

    internal class DeleteWorkStatusByIdCommandHandler(IEntityService<WorkStatus> service) : DeleteEntityByIdCommandHandler<WorkStatus>(service)
    {
    }
}
