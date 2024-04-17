using RepairHub.Database.Entities;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.DeleteEntity
{
    internal class DeleteUserCommandHandler(IEntityService<User> service) : DeleteEntityByIdCommandHandler<User>(service)
    {
    }
}
