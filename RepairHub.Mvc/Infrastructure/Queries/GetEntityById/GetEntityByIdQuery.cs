using MapsterMapper;
using MediatR;
using RepairHub.Database.Entities;
using RepairHub.Database.Entities.Base.Interface;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Queries.GetEntityById
{
    internal record GetEntityByIdQuery<TModel, TBase> : IRequest<TModel>
        where TModel : IEntity
        where TBase : IEntity
    {
        public int Id { get; }

        public GetEntityByIdQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetEntityByIdQueryHandler<TModel, TBase>(IEntityService<TBase> repository, IMapper mapper) : IRequestHandler<GetEntityByIdQuery<TModel, TBase>, TModel>
       where TModel : IEntity
       where TBase : IEntity
    {
        private readonly IEntityService<TBase> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<TModel> Handle(GetEntityByIdQuery<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id, cancellationToken);
            return _mapper.Map<TModel>(entity);
        }
    }

    #region Using

    internal class GetUserByIdQueryHandler(IEntityService<User> repository, IMapper mapper) : GetEntityByIdQueryHandler<UserDto, User>(repository, mapper)
    {
    }

    internal class GetApplicationByIdQueryHandler(IEntityService<Application> repository, IMapper mapper) : GetEntityByIdQueryHandler<ApplicationDto, Application>(repository, mapper)
    {
    }

    #endregion
}
