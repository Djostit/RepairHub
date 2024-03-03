using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RepairHub.Database.Entities;
using RepairHub.Domain.Dtos;
using RepairHub.Mvc.Infrastructure.Services.Interfaces;

namespace RepairHub.Mvc.Infrastructure.Queries.GetData
{
    internal record AuthenticationQuery(string Login, string Password) : IRequest<UserDto>;
    internal class AuthenticationQueryValidator : AbstractValidator<AuthenticationQuery>
    {
        public AuthenticationQueryValidator(IEntityService<User> service)
        {
            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Обязательно");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Обязательно");

            RuleFor(x => x)
                .MustAsync(async (value, cancel) =>
                {
                    var user = await service.Items.FirstOrDefaultAsync(x => x.Login == value.Login, cancel);
                    return user != null && BCrypt.Net.BCrypt.Verify(user.HashPassword, value.Password);
                }).WithMessage("Неверные учетные данные");

        }
    }
    internal class AuthenticationQueryHandler(IEntityService<User> service, IMapper mapper) : IRequestHandler<AuthenticationQuery, UserDto>
    {
        private readonly IEntityService<User> _service = service;
        private readonly IMapper _mapper = mapper;
        public async Task<UserDto> Handle(AuthenticationQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserDto>(await _service.Items.FirstAsync(x => x.Login == request.Login, cancellationToken));
        }
    }
}
