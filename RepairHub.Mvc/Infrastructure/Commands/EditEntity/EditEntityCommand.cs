using MapsterMapper;
using MediatR;
using RepairHub.Database.Entities.Base.Interface;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Commands.EditEntity
{
    internal class EditEntityCommand<TModel, TBase> : IRequest<TBase>
        where TModel : IEntity
        where TBase : IEntity
    {
        public TModel Model { get; set; }
        public EditEntityCommand(TModel model)
        {
            Model = model;
        }
    }
    internal class EditEntityCommandHandler<TModel, TBase>(IEntityService<TBase> service, IMapper mapper) : IRequestHandler<EditEntityCommand<TModel, TBase>, TBase>
        where TModel : IEntity
        where TBase : IEntity
    {
        private readonly IEntityService<TBase> _service = service;
        private readonly IMapper _mapper = mapper;
        public async Task<TBase> Handle(EditEntityCommand<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TBase>(request.Model);
            var result = await _service.Update(entity, cancellationToken);
            return result;
        }
    }
}
