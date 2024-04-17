using MediatR;
using RepairHub.Database.Entities.Base.Interface;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.DeleteEntity
{
    internal record DeleteEntityByIdCommand<TBase> : IRequest
         where TBase : IEntity
    {
        public int Id { get; }
        public DeleteEntityByIdCommand(int id)
        {
            Id = id;
        }
    }
    internal class DeleteEntityByIdCommandHandler<TBase>(IEntityService<TBase> service) : IRequestHandler<DeleteEntityByIdCommand<TBase>>
         where TBase : IEntity
    {
        private readonly IEntityService<TBase> _service = service;
        public async Task Handle(DeleteEntityByIdCommand<TBase> request, CancellationToken cancellationToken)
        {
            await _service.DeleteById(request.Id, cancellationToken);
        }
    }
}
