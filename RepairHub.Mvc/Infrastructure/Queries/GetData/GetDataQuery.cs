using Humanizer;
using MapsterMapper;
using MediatR;
using RepairHub.Database.Entities;
using RepairHub.Database.Entities.Base.Interface;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Queries.GetData
{
    internal record GetDataQuery<TModel, TBase> : IRequest<List<TModel>>
        where TModel : IEntity
        where TBase : IEntity
    {
    }
    internal class GetDataQueryHandler<TModel, TBase>(IEntityService<TBase> service, IMapper mapper) : IRequestHandler<GetDataQuery<TModel, TBase>, List<TModel>>
        where TModel : IEntity
        where TBase : IEntity
    {
        private readonly IEntityService<TBase> _service = service;
        private readonly IMapper _mapper = mapper;
        public async Task<List<TModel>> Handle(GetDataQuery<TModel, TBase> request, CancellationToken cancellationToken)
        {
            var data = await _service.GetAll(cancellationToken);
            var dto = _mapper.Map<List<TModel>>(data);
            return dto;
        }
    }
    #region Using

    internal class GetUsersQueryHandler(IEntityService<User> service, IMapper mapper) : GetDataQueryHandler<UserDto, User>(service, mapper)
    {
    }

    internal class GetApplicationQueryHandler(IEntityService<Application> service, IMapper mapper) : GetDataQueryHandler<ApplicationDto, Application>(service, mapper)
    {
    }

    internal class GetEmployeeQueryHandler(IEntityService<Employee> service, IMapper mapper) : GetDataQueryHandler<EmployeeDto, Employee>(service, mapper)
    {
    }

    internal class GetEquipmentQueryHandler(IEntityService<Equipment> service, IMapper mapper) : GetDataQueryHandler<EquipmentDto, Equipment>(service, mapper)
    {
    }

    internal class GetProblemQueryHandler(IEntityService<Problem> service, IMapper mapper) : GetDataQueryHandler<ProblemDto, Problem>(service, mapper)
    {
    }

    internal class GetRoleQueryHandler(IEntityService<Role> service, IMapper mapper) : GetDataQueryHandler<RoleDto, Role>(service, mapper)
    {
    }

    internal class GetStatusQueryHandler(IEntityService<Status> service, IMapper mapper) : GetDataQueryHandler<StatusDto, Status>(service, mapper)
    {
    }

    internal class GetWorkStatusQueryHandler(IEntityService<WorkStatus> service, IMapper mapper) : GetDataQueryHandler<WorkStatusDto, WorkStatus>(service, mapper)
    {
    }

    #endregion
}
