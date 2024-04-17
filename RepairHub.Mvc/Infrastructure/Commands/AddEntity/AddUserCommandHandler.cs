using MapsterMapper;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Queries.GetData;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.AddEntity
{
    internal class AddUserCommandHandler(IEntityService<User> service, IMapper mapper) : AddEntityCommandHandler<UserDto, User>(service, mapper)
    {
    }
}
