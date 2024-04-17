using MapsterMapper;
using MediatR;
using RepairHub.Database.Entities.Base.Interface;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.AddEntity
{
    internal record AddEntityCommand<TModel, TBase> : IRequest<TBase>
        where TModel : IEntity
        where TBase : IEntity
    {
        public TModel Model { get; set; }
        public AddEntityCommand(TModel model)
        {
            Model = model;
        }
    }
    internal class AddEntityCommandHandler<TModel, TBase>(IEntityService<TBase> service, IMapper mapper) : IRequestHandler<AddEntityCommand<TModel, TBase>, TBase>
        where TModel : IEntity
        where TBase : IEntity
    {
        private IEntityService<TBase> _service = service;
        private readonly IMapper _mapper = mapper;
        public async Task<TBase> Handle(AddEntityCommand<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TBase>(request.Model);
            var result = await _service.Add(entity, cancellationToken);
            return result;
        }
    }
}
