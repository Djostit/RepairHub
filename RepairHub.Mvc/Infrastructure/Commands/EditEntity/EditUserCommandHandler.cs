using MapsterMapper;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.EditEntity
{
    internal class EditUserCommandHandler : EditEntityCommandHandler<UserDto, User>
    {
        public EditUserCommandHandler(IEntityService<User> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
